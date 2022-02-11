using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Consultas
{
    [MembershipHelper.MenuSiteMapAttribute(SiteMapProvider = "EmpresaSiteMap")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio'
    public partial class VerDetalleSocio : SecurePage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.PersonaId'
        public int PersonaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.PersonaId'
        {
            get
            {
                int personaId;
                Int32.TryParse(Request.QueryString["personaId"], out personaId);
                return personaId;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.CamaraId'
        public string CamaraId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.CamaraId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["camaraId"])
                    ? Request.QueryString["camaraId"]
                    : String.Empty;
            }
        }

        private string Query
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["qry"])
                           ? Request.QueryString["qry"]
                           : String.Empty;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.Page_Load(object, EventArgs)'
        {
            if (this.PersonaId <= 0 || this.CamaraId.Length <= 0) return;

            this.litQuery.Text = this.Query;


            var db = new SRM.CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(CamaraId));
            var col = db.ViewPersonasEnSociedades.Where(v => v.SocioId == this.PersonaId && v.EstatusId !=5);






            //var ctrlSociedades = new SRM.SociedadesController();
            //var sociedades = ctrlSociedades.FetchByRegistroAndCamara(numRegistro, "SDQ").FirstOrDefault();


            //if (sociedades != null)
            //{
            //    infoRegistro.RazonSocial = infoRegistro.RazonSocial + " - " + sociedades.Estatus_fecha;
            //}







            var grouped = col.ToList()
                .Join(db.SociedadesRegistros, c => c.RegistroId, x => x.RegistroId, (Registro, Sociedad) => new { Sociedad, Registro })
                .GroupBy(c => new { c.Registro.RegistroId, c.Sociedad.SociedadId, c.Registro.NombreSocial, c.Registro.NumeroRegistro, c.Registro.SocioId, c.Registro.FechaConstitucion, c.Registro.Rnc, c.Registro.TipoSociedadId })
                .Select(g => new SRM.PersonaSociedadDto()
                {
                    NombreSocial = g.Key.NombreSocial,
                    NumeroRegistro = g.Key.NumeroRegistro,
                    SocioId = g.Key.SocioId,
                    FechaConstitucion = g.Key.FechaConstitucion,
                    Rnc = g.Key.Rnc,
                    RegistroId = g.Key.RegistroId,
                    SociedadId = g.Key.SociedadId,
                    TipoSociedadId = g.Key.TipoSociedadId,
                    RegistroRelacion = GetTiposAccionistaAsString(col, g.Key.SocioId, g.Key.NumeroRegistro)
                }).ToList();


            foreach (var item in grouped)
            {
                var ctrlSociedades = new SRM.SociedadesController();
                var sociedades = ctrlSociedades.FetchByRegistroAndCamara(item.NumeroRegistro, "SDQ").FirstOrDefault();

                if (sociedades != null)
                {
                    item.Estatus_fecha =  sociedades.Estatus_fecha;
                }
            }

            this.rgAccionistaEmpresas.DataSource = grouped;
            this.rgAccionistaEmpresas.DataBind();

            var repPersona = new SRM.PersonaRepository(this.CamaraId);
            var persona = repPersona.SelectByKey(SRM.Personas.PropColumns.PersonaId, this.PersonaId);

            if (persona == null) return;
            this.lblNombre.Text = !String.IsNullOrEmpty(persona.PrimerNombre) ? persona.PrimerNombre : String.Empty;
            this.lblSegundoNombre.Text = !String.IsNullOrEmpty(persona.SegundoNombre) ? persona.SegundoNombre : String.Empty;
            this.lblApellido.Text = !String.IsNullOrEmpty(persona.PrimerApellido) ? persona.PrimerApellido : String.Empty;
            this.lblSegundoApellido.Text = !String.IsNullOrEmpty(persona.SegundoApellido) ? persona.SegundoApellido : String.Empty;
            this.lblNumDocumento.Text = !String.IsNullOrEmpty(persona.Documento) ? persona.Documento : String.Empty;
            this.lblTipoDocumento.Text = !String.IsNullOrEmpty(persona.TipoDocumento) ? String.Format("({0})", persona.TipoDocumento) : String.Empty;
        }

        private static string GetTiposAccionistaAsString(IEnumerable<SRM.ViewPersonasEnSociedades> col, int socioId, int numeroRegistro)
        {
            var sb = new StringBuilder();
            var tiposRelIds = col.Where(s => s.SocioId == socioId).Where(s => s.NumeroRegistro.Equals(numeroRegistro)).Select(s => s.TipoRelacion).ToList();
            var descTipoSocios =
                    new DataAccess.EF.CamaraComun.CamaraComunEntities().TipoSocio
                    .Where(t => tiposRelIds.Contains(t.TipoSocioId)).Select(
                    t => t.Descripcion);
            foreach (var tipo in descTipoSocios)
            {
                sb.Append(tipo + ", ");
            }
            return sb.ToString().Trim().TrimEnd(',');
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.rgridEmpresas_ItemDataBound(object, GridItemEventArgs)'
        protected void rgridEmpresas_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.rgridEmpresas_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType != GridItemType.Item &&
                e.Item.ItemType != GridItemType.AlternatingItem) return;

            SRM.PersonaSociedadDto dto = e.Item.DataItem as SRM.PersonaSociedadDto;
            if (dto == null) return;

            int sociedadId = dto.SociedadId;
            int registroId = dto.RegistroId;

            var ctrl = e.Item.FindControl("lnkVerDetalleId");
            if (!(ctrl is HyperLink)) return;

            var lnk = (HyperLink)ctrl;
            lnk.NavigateUrl = String.Format("VerDetalleEmpresa.aspx?sociedadId" +
                "={0}&registroId={1}&CamaraId={2}", sociedadId, registroId, CamaraId);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.lnkCertificacion_Click(object, EventArgs)'
        protected void lnkCertificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerDetalleSocio.lnkCertificacion_Click(object, EventArgs)'
        {
            const string urlBase = "/Operaciones/Shared/Certificaciones.aspx?TipoServicioId={0}&EsPersona=1&CamaraId={1}&personaId={2}&Visible={3}";

            Response.Redirect(String.Format(urlBase, Helper.ServicioCertificacionId, this.CamaraId, Request["personaId"], "false"));
        }
    }
}