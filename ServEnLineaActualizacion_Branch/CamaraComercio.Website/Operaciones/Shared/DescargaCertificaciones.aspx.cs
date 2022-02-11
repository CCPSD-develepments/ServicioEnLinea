using System;


namespace CamaraComercio.Website.Operaciones.Shared
{
    /// <summary>
    /// Descarga de certificaciones
    /// </summary>
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
    public partial class DescargaCertificaciones : EnvioDatosPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DescargaCertificaciones.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DescargaCertificaciones.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            lbDescargar.NavigateUrl = "~/Operaciones/Shared/DescargaCert.aspx" + DefaultQueryString;
            hlVerSolicitud.NavigateUrl = "~/Empresas/ImprimirSolicitud.aspx" + DefaultQueryString;
            hlNuevaSolicitud.NavigateUrl = "~/Operaciones/Shared/Certificaciones.aspx" + DefaultQueryString;
            hlVerFactura.NavigateUrl = "/Empresas/ImprimirFactura.aspx" + DefaultQueryString;
        }
    }
}