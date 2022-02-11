using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerSolicitudGeneral'
    public partial class VerSolicitudGeneral : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerSolicitudGeneral'
    {

        OFV.CamaraWebsiteEntities db = new OFV.CamaraWebsiteEntities();
       

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerSolicitudGeneral.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerSolicitudGeneral.Page_Load(object, EventArgs)'
        {

            if (!IsPostBack)
            {

                bool esDetalle = false;
                Boolean.TryParse(Request.QueryString["VerDetalle"], out esDetalle);

                if (esDetalle)
                {

                int transId = 0;
                int.TryParse(Request["nSolicitud"], out transId);
                var transaccion = GetTransaccion(transId);

                    lblFechaCita.Text = Convert.ToDateTime(transaccion.Fecha.ToString()).ToShortDateString();
                    litNoRegistro.Text = transId.ToString();
                    var dbCom = new CamaraComunEntities();
                    litTipoServicio.Text = dbCom.Servicio.First(s => s.ServicioId == transaccion.ServicioId).Descripcion;
                    DataAccess.EF.SRM.CamaraSRMEntities ctrlSociedad = new DataAccess.EF.SRM.CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(transaccion.CamaraId));

                    if (transaccion.RegistroId != 0)
                    {
                        ltRegistroMercantil.Text = ctrlSociedad.SociedadesRegistros.First(x => x.RegistroId == transaccion.RegistroId).NumeroRegistro.ToString();
                        var SociedadId = ctrlSociedad.SociedadesRegistros.First(x => x.RegistroId == transaccion.RegistroId).SociedadId;
                        litFechaConstitucion.Text = Convert.ToDateTime(ctrlSociedad.Sociedades.First(x => x.SociedadId == SociedadId).FechaConstitucion.ToString()).ToShortDateString();
                    }
                    LiteralComentario.Text = transaccion.Comentario;
                    litCapitalSocial.Text = transaccion.CapitalSocial.ToString();
                    litTelefonoPrimario.Text = transaccion.TelefonoContacto;
                    litDenomSocial.Text = transaccion.NombreSocialPersona.ToString();

                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VerSolicitudGeneral.Transaccion'
        protected OFV.Transacciones Transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VerSolicitudGeneral.Transaccion'
        {
            get
            {
                int nSol;
                int.TryParse(Request.QueryString["nSolicitud"], out nSol);
                if (nSol != 0)
                {
                    var ofvDb = new CamaraWebsiteEntities();
                    var transa = ofvDb.Transacciones.FirstOrDefault(x => x.TransaccionId == nSol);
                    if (transa != null) return transa;
                    else return new OFV.Transacciones();
                }
                else return new OFV.Transacciones();
            }
            set { Session["Transacciones"] = value; }
        }

        private OFV.Transacciones GetTransaccion(long transactionId)
        {
            var trans = (from t in db.Transacciones
                         where t.TransaccionId == transactionId
                         select t).FirstOrDefault();

            return trans;
        }

    }
}