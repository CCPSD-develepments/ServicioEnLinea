using System;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Srm.Common.Reports.Certificaciones;
using System.Linq;

namespace CamaraComercio.Website.Operaciones.Shared
{
    /// <summary>
    /// Formulario que controla la descarga de certificados firmados digitalmente
    /// </summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class DescargaCert : EnvioDatosPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DescargaCert.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DescargaCert.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
                InitDescarga();
        }
        private void InitDescarga()
        {

            var transaccion = new TransaccionesRepository();
            var trans = transaccion.GetTransaccion(this.IdTransaciones, User.Identity.Name);

            if (trans == null)
            {
                SolicitudInvalida();
                return;
            }

            var transDoc = trans.TransaccionesDocDescargas.FirstOrDefault();
            if (!trans.bPagada) TransaccionNoPagada();

            if (transDoc == null || transDoc.DocContent==null)
            {
                var usr = OficinaVirtualUserProfile.GetUserProfile();
                var datosSolicitante = new DatosSolicitante
                                           {
                                               EmpresaPersona = !String.IsNullOrEmpty(trans.Solicitante) 
                                                                ? trans.Solicitante
                                                                : usr.NombreSolicitante,
                                               Rnc = trans.RNCSolicitante ?? usr.RNC,
                                               FechaEmision = DateTime.Now,
                                               CamaraId = trans.CamaraId,
                                               InfoExtra = String.Empty,
                                               NombreSociedad = transDoc != null 
                                                                ? (transDoc.NombreSocialOrComment ?? trans.NombreSocialPersona)
                                                                : trans.NombreSocialPersona
                                           };

                var criteriosBusqueda = new CriteriosBusqueda
                                            {
                                                //Campo por que se hara la busqueda.
                                                BuscarPor = BuscarPor.NumeroRegistro,
                                                //Valor a buscar
                                                ValorBuscar = trans.NumeroRegistro.GetValueOrDefault().ToString(),
                                                //Template que se generará.
                                                ModeloCertificacion = trans.TipoModeloId.GetValueOrDefault()
                                            };

                var instance = new CertificacionesEngine(datosSolicitante, criteriosBusqueda);
                var pdf = instance.GetCertificacionSignedPdf(trans.CamaraId, true);
                var repDocumentos = new TransaccionesDocDescargasRepository();

                transDoc = repDocumentos.AddDocumentoDescarga(this.IdTransaciones, User.Identity.Name, pdf);

            }

            String nombreSociedad = trans.NombreSocialPersona ?? String.Empty;

            var fileName = String.Format("{0}_{1}_{2}{3}{4}-{5}.pdf", nombreSociedad.RemoverFormato(), "Cert",
                                         DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                         trans.TransaccionId);
            Response.Clear();
            Response.AppendHeader("content-disposition",
                                  "attachment; filename=" + fileName);

            Response.ContentType = "Application/pdf";
            Response.BinaryWrite(transDoc.DocContent);
            Response.Flush();
        }

        private void TransaccionNoPagada()
        {
            Session["ErrorMessage"] = "Su Transaccion no ha sido pagada.  Verificar en el Historico de Transacciones.";
            Response.Redirect("~/Empresas/Oficina.aspx");
        }

        private void SolicitudInvalida()
        {
            Session["ErrorMessage"] = "Solicitud no Existe. Por favor verificar y trate de nuevo.";
            Response.Redirect("~/Empresas/Oficina.aspx");
        }
    }
}