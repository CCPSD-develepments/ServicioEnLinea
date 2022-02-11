using System.Collections.Generic;
using System.Linq;
using CC = CamaraComercio.DataAccess.EF.SRM;
using Microsoft.Reporting.WebForms;

namespace CamaraComercio.WebServices
{
    public enum FormatoCertificadoRM
    {
        Pdf = 1,
        Image = 2
    }

    /// <summary>
    /// Define los tipos certificados de Registro Mercantil.
    /// </summary>
    public enum TipoCertificadoRM
    {
        /// <summary>
        /// No contiene tipo de sociedad.
        /// </summary>
        Ninguno,
        /// <summary>
        /// Representa a las Sociedades Anonimas (S.A.).
        /// </summary>
        SociedadAnonima = 1,
        /// <summary>
        /// Representa a las Sociedades de Responsabilidad Limitadas (S.R.L.).
        /// </summary>
        SociedadResponsabilidadLimitada = 2,
        /// <summary>
        /// Representa a las Sociedeades en Nombre Colectivo.
        /// </summary>
        SociedadNombreColectivo = 3,
        /// <summary>
        /// Representa a las Sociedades de Comandita Simples (S. en C.).
        /// </summary>
        SociedadComanditaSimple = 4,
        /// <summary>
        /// Representa a las Sociedades de Comandita por Acciones (S. en C. x A.).
        /// </summary>
        SociedadComanditaPorAcciones = 5,
        /// <summary>
        /// Representa a las Sociedades de Empresas Individuales de Responsabilidad Limitada (E.I.R.L.).
        /// </summary>
        EmpresaIndividualResponsabilidadLimitada = 6,
        ///// <summary>
        ///// Representa a las Personas Físicas.
        ///// </summary>
        //PersonasFisicas = 7,
        /// <summary>
        /// Representa a las Sociedades de Compañias por Acciones (C. x A.).
        /// </summary>
        CompaniaPorAcciones = 9,
        /// <summary>
        /// Representa a las Sociedades Extranjeras.
        /// </summary>
        SociedadesExtranjeras = 13,
        /// <summary>
        /// Representa las Sociedades Anonimas Simplificadas.
        /// </summary>
        SociedadAnonimaSimplificada = 16,
        /// <summary>
        /// Representa las Sociedades Anonimas de Suscripción Pública.
        /// </summary>
        SociedadAnonimaPublica = 15
    } ;


    /// <summary>
    /// Clase que contiene el diccionario de los certificados de Registro Mercantil.
    /// </summary>
    public class ReportesHelper
    {
        static readonly Dictionary<TipoCertificadoRM, string> CertificadosDictionary = new Dictionary<TipoCertificadoRM, string>();
        static readonly Dictionary<FormatoCertificadoRM, string> FormatoDictionary = new Dictionary<FormatoCertificadoRM, string>();
        /// <summary>
        /// Inicializa la instancia de la clase <see cref="Helpers"/>
        /// </summary>
        static ReportesHelper()
        {
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadAnonima, "Reportes\\SociedadAnonima.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadComanditaPorAcciones, "Reportes\\ComanditaPorAcciones.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadComanditaSimple, "Reportes\\ComanditaSimple.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadesExtranjeras, "Reportes\\SociedadesExtranjeras.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadNombreColectivo, "Reportes\\NombreColectivo.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadResponsabilidadLimitada, "Reportes\\ResponsabilidadLimitada.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.EmpresaIndividualResponsabilidadLimitada, "Reportes\\EmpresaIndividualResponsabilidadLimitada.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.CompaniaPorAcciones, "Reportes\\CompaniaPorAcciones.rdlc");
            CertificadosDictionary.Add(TipoCertificadoRM.SociedadAnonimaSimplificada, "Reportes\\SociedadAnonimaSimplificada.rdlc");

            FormatoDictionary.Add(FormatoCertificadoRM.Pdf, "PDF");
            FormatoDictionary.Add(FormatoCertificadoRM.Image, "IMAGE");
        }

        /// <summary>
        /// Obtienes el path del certificado de registro mercantil.
        /// </summary>
        /// <param name="tipoCertificadoRM">Tipo <see cref="TipoCertificadoRM"/> que representa el tipo certificado.</param>
        /// <returns></returns>
        public static string GetCertificadoRmPath(TipoCertificadoRM tipoCertificadoRM)
        {
            if (CertificadosDictionary.Count == 0) throw new KeyNotFoundException("No existen valores en el diccionario.");

            string value;
            bool b = CertificadosDictionary.TryGetValue(tipoCertificadoRM, out value);
            if (!b) throw new KeyNotFoundException("No existen valores en el diccionario con la llave seleccionada.");
            return value;
        }

        public static string GetFormatoCertificadoRm(FormatoCertificadoRM formatoCertificadoRM)
        {
            if (CertificadosDictionary.Count == 0) throw new KeyNotFoundException("No existen valores en el diccionario.");

            string value;
            bool b = FormatoDictionary.TryGetValue(formatoCertificadoRM, out value);
            if (!b) throw new KeyNotFoundException("No existen valores en el diccionario con la llave seleccionada.");
            return value;
        }

        public static ReportParameter[] GetReportParameter(CC.cvw_SociedadesRegistros sociedadesRegistros)
        {
            string descripcion = string.Empty;
            string sucursal = string.Empty;
            string nota = "";
            string estado = "";
            int num = 0;

            using (var db = new CC.CamaraSRMEntities())
            {
                var actividades = from act in db.ViewRegistrosActividades
                                  where act.RegistroId == sociedadesRegistros.RegistroId
                                  select act;

                foreach (CC.ViewRegistrosActividades row in actividades)
                {
                    if (num == 0)
                        descripcion = row.Actividad;
                    else
                        descripcion += string.Format(", {0}", row.Actividad);

                    num++;
                }

                var sucursales = from suc in db.Suscursales
                                 where suc.SociedadId == sociedadesRegistros.SociedadId
                                 select suc;
                num = 0;
                foreach (CC.Suscursales row in sucursales)
                {
                    if (num == 0)
                        sucursal = row.Descripcion;
                    else
                        sucursal += string.Format(", {0}", row.Descripcion);

                    num++;
                }

                if (!string.IsNullOrEmpty(sociedadesRegistros.Comentario2))
                {
                    nota = "VER NOTA AL DORSO";
                }
            }

            var param = new[]
                                {
                                    new ReportParameter("Actividades", descripcion),
                                    new ReportParameter("Sucursales", sucursal),
                                    new ReportParameter("NuevoEstado", estado),
                                    new ReportParameter("NotaDorso", nota),
                                    new ReportParameter("Firma", ""),
                                    new ReportParameter("FirmaPuesto", ""),
                                    new ReportParameter("ShowHeader", "False")
                                };

            return param;
        }
    }
}
