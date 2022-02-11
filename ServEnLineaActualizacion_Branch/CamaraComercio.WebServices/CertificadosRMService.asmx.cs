using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.SRM;
using Microsoft.Reporting.WebForms;

namespace CamaraComercio.WebServices
{
    /// <summary>
    /// Servicio de generación de los Certificados de Registro Mercantil.
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CertificadosRMService : WebService
    {
        /// <summary>
        /// Genera el un arreglo de bytes con la información del Certificado de Registro Mercantil.
        /// </summary>
        /// <param name="numeroCertificacion">Número de Registro.</param>
        /// <param name="camaraId">Identificador de la Camara que se esta conectando.</param>
        /// <param name="formato">Tipo <see cref="FormatoCertificadoRM"/> que define el formato de creación del Certificado de Registro Mercantil.</param>
        /// <returns></returns>
        [WebMethod]
        public byte[] GenerarCertificado(int numeroRegistro, string camaraId, FormatoCertificadoRM formato)
        {
            var viewer = new ReportViewer { ProcessingMode = ProcessingMode.Local };
            using (var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
            {
                var sociedadesRegistros = (from reg in db.cvw_SociedadesRegistros
                                           where reg.NumeroRegistro == numeroRegistro
                                           select reg);

                if (sociedadesRegistros.Count() == 0)
                    throw new Exception("Este número de registro no existe.");

                var sr = sociedadesRegistros.First();
                var productos = (from prod in db.ViewRegistrosProductos
                                 where prod.RegistroId == sr.RegistroId
                                 select prod);
                var registroSocios = (from socio in db.ViewRegistrosSocios
                                      where socio.RegistroId == sr.RegistroId
                                      select socio);
                var comerciales = (from comer in db.ReferenciasComerciales
                                   where comer.RegistroId == sr.RegistroId
                                   select comer);
                var bancos = (from bank in db.ViewReferenciasBancarias
                              where bank.RegistroId == sr.RegistroId
                              select bank);
                var direcciones = (from dir in db.ViewDirecciones
                                   where dir.DireccionId == sr.DireccionId
                                   select dir);
                var oposiciones = (from opo in db.ViewRegistrosOposiciones
                                   where opo.RegistroId == sr.RegistroId
                                   select opo);

                var ccdb = new CamaraComunEntities();
                var nomenclatura = ccdb.Nomenclaturas.Where(o => o.CamaraId == camaraId && o.TipoNomenclatura == "S");
                var camaras = ccdb.Camaras.Where(o => o.ID == camaraId);
                var tipoCertificadoRM = (TipoCertificadoRM)(sr.TipoSociedadId.HasValue ? sr.TipoSociedadId.Value : 1);
                viewer.LocalReport.ReportPath = ReportesHelper.GetCertificadoRmPath(tipoCertificadoRM);

                viewer.LocalReport.DataSources.Add(new ReportDataSource("Productos", productos));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("RegistrosSocios", registroSocios));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("ReferenciasComerciales", comerciales));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("ReferenciasBancarias", bancos));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("Direcciones", direcciones));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("SociedadesRegistros", sociedadesRegistros));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("RegistrosOposiciones", oposiciones));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("Nomenclaturas", nomenclatura));
                viewer.LocalReport.DataSources.Add(new ReportDataSource("Camaras", camaras));
                viewer.LocalReport.SetParameters(ReportesHelper.GetReportParameter(sr));

                Warning[] warnings;
                string[] streamIds;
                string mimeType, encoding, extension;
                byte[] bytes = viewer.LocalReport.Render(ReportesHelper.GetFormatoCertificadoRm(formato), null,
                                                         out mimeType,
                                                         out encoding, out extension, out streamIds, out warnings);
                return bytes;
            }
        }

        /// <summary>
        /// Devuelve la definición del Reporte del Certificado de Registro Mercantil.
        /// </summary>
        /// <param name="tipoCertificadoRM">Tipo Certificado RM.</param>
        /// <returns></returns>
        [WebMethod (Description = "Retorna la definición del reporte del certificado del registro mercantil")]
        public string GetReportRdl(int tipoCertificadoRM)
        {
            var path = Server.MapPath(ReportesHelper.GetCertificadoRmPath((TipoCertificadoRM)tipoCertificadoRM));
            if (!File.Exists(path)) return "No Existe el archivo especificado.";
            var fileContent = File.ReadAllText(path);
            return fileContent;
        }
    }
}