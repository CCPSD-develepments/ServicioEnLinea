using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado'
    public partial class ConsultaEstado : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado.Page_Load(object, EventArgs)'
        {
            //Capturando el postback
            if (IsPostBack) return;

            //Inicializando la interfaz
            InitInterface();

            this.Form.DefaultButton = this.btnConsultar.UniqueID;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado.InitInterface()'
        protected void InitInterface()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado.InitInterface()'
        {
            //Dropdown de camaras
            var camaraCtrl = new Comun.CamarasController();
            var camaras = this.User.IsInRole("Testers")
                              ? camaraCtrl.FetchAll()
                              : camaraCtrl.FetchAllActivas();
            this.ddlCamara.BindCollection(camaras,
                Comun.Camaras.PropColumns.ID, Comun.Camaras.PropColumns.Nombre, (Request["id"] == null) ? Helper.IdCamaraPrincipal : Helper.IdCamaraSecundaria);


        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado.btnConsultar_Click(object, EventArgs)'
        protected void btnConsultar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsultaEstado.btnConsultar_Click(object, EventArgs)'
        {
            //Limpieza de variables
            LimpiarLiterals();

            //ID de la transaccion
            var transIdStr = this.txtTransaccionId.Text;
            Int32 transId;
            if (!Int32.TryParse(transIdStr, out transId))
            {
                this.GenerateCustomError("El número de transacción no es válido");
                return;
            }

            //Si el usuario selecciono la opción de transaccion por internet, se revisa primero la BD CamaraWebsite
            if (chkInternet.Checked)
                LlenarInformacionesWebsite(transId);
            else
                //Si el usuario no eligio la opción del checked, quiere decir que buscaremos en la cámara directamente
                LlenarInformacionesSrm(this.ddlCamara.SelectedValue, transId);
        }


        /// <summary>
        /// Método que asiste en la limpieza de todos los literals en el formulario
        /// </summary>
        private void LimpiarLiterals()
        {
            this.litErrores.Text = String.Empty;
            this.litComentariosAdicionales.Text = String.Empty;
            this.litEstadoActual.Text = String.Empty;
            this.litFechaRecepcion.Text = String.Empty;
            this.litRazonSocial.Text = String.Empty;
        }


        /// <summary>
        /// Busca las informaciones de seguimiento en la base de datos CamaraSRM y los despliega en pantalla
        /// </summary>
        /// <param name="transaccionId">ID de la transacción en CamaraWebsite</param>
        private void LlenarInformacionesWebsite(int transaccionId)
        {
            var dbWebsite = new OFV.CamaraWebsiteEntities();
            var transaccion = dbWebsite.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId);

            //Se revisa que existe la transacción, sino se muestra un mensaje de error
            if (transaccion == null)
            {
                this.litErrores.Text = "No se localizó ninguna orden realizada por internet con el número digitado.";
                this.mvConsulta.SetActiveView(vError);
                return;
            }

            //Variables con informacion en CamaraWebsite
            var registro = dbWebsite.Registros.FirstOrDefault(r => r.RegistroId == transaccion.RegistroId);
            var sociedad = dbWebsite.Sociedades.FirstOrDefault(s => s.RegistroId == transaccion.RegistroId);

            //Informaciones generales de la orden
            this.litFechaRecepcion.Text = transaccion.Fecha.ToStringDom();
            this.litRazonSocial.Text = sociedad != null ? sociedad.NombreSocial : String.Empty;

            //Se revisa que la transacción haya sido cargada al SRM
            if (!transaccion.bLoadedInSRM.HasValue || transaccion.bLoadedInSRM == false ||
                !transaccion.SrmTransaccionId.HasValue || transaccion.SrmTransaccionId == 0)
            {

                //La transaccion no ha sido cargada al SRM, se muestra la información de recepción desde el website)
                this.litEstadoActual.Text = "Solicitud enviada vía Web. No recibida en la cámara";
                this.litComentariosAdicionales.Text =
                    "La solicitud ha sido generada exitosamente. Pero aún no ha sido enviada para ser procesada " +
                    "por un analista. Esto puede deberse a que aún no se ha realizado el pago correspondiente o falta de depósito de " +
                    "documentos necesarios. Para más información visitar el área de usuarios donde inició su transacción y seleccionar " +
                    "la transacción que desea consultar";
            }
            else
            {
                LlenarInformacionesSrm(transaccion.CamaraId, transaccion.SrmTransaccionId.Value);
            }

            this.mvConsulta.SetActiveView(vResultados);
        }

        /// <summary>
        /// Busca las informaciones de seguimiento en la base de datos CamaraSRM y los despliega en pantalla
        /// </summary>
        /// <param name="camaraId">Instancia de CamaraSRM a acceder</param>
        /// <param name="transaccionId">ID de la transacción en el SRM</param>
        private void LlenarInformacionesSrm(string camaraId, int transaccionId)
        {
            //Acceso a datos
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            //Se revisa que la transacción tenga un número de seguimiento en el SRM
            var transSrm = dbSrm.Transacciones.FirstOrDefault(t => t.TransaccionId == transaccionId);
            if (transSrm == null)
            {
                //Si no existe en el SRM se muestra un error
                this.GenerateCustomError("No se localizó la transacción. Por favor contactar " +
                    "al personal de la cámara para revisar su expediente.");
                return;
            }
            else
            {
                //Variables con informacion en SRM
                var listaEstados = dbSrm.EstatusTransacciones.ToList();
                
                var estatusVisibles = WebConfigurationManager.AppSettings["ShowOnlyStatus"].Split(',').Select(int.Parse).ToList(); ;

                var sociedadId = transSrm.TransaccionesSociedades != null && transSrm.TransaccionesSociedades.SociedadId > 0
                                 ? transSrm.TransaccionesSociedades.SociedadId
                                 : 0;

                var sociedad = sociedadId > 0
                               ? dbSrm.Sociedades.FirstOrDefault(s => s.SociedadId == sociedadId)
                               : null;
                
                var seguimiento = (from est in dbSrm.EstatusTransacciones
                                   join seg in dbSrm.SeguimientoTransacciones on est.EstatusTransId equals seg.Estado
                                   where seg.TransaccionId == transSrm.TransaccionId && estatusVisibles.Contains(seg.Estado)
                                   orderby seg.FechaModificacion
                                   select new
                                   {
                                       Descripcion = est.EstatusTransaccion,
                                       seg.Estado,
                                       seg.FechaModificacion,
                                       seg.Comentario
                                   }).ToList();


                var seguimientoFormat = seguimiento.Select(s =>
                    new
                    {
                        s.Descripcion,
                        Estado = listaEstados.FirstOrDefault(l => l.EstatusTransId == s.Estado).EstatusTransaccion,
                        FechaModificacion = s.FechaModificacion.ToStringDomConHora(),
                        s.Comentario
                    });

                //el estado actual sera el ultimo estado del seguimiento.
                var estadoActual = seguimientoFormat.LastOrDefault();

                //Resumen de la transacción
                this.litFechaRecepcion.Text = this.litFechaRecepcion.Text.Length > 0
                                                ? this.litFechaRecepcion.Text
                                                : transSrm.Fecha.ToStringDomConHora();
                this.litRazonSocial.Text = this.litRazonSocial.Text.Length > 0
                                                ? this.litRazonSocial.Text
                                                : (sociedad != null ? sociedad.NombreSocial : transSrm.CustomString1);

                if (estadoActual != null && !String.IsNullOrEmpty(estadoActual.Descripcion))
                    this.litEstadoActual.Text = estadoActual.Descripcion;

                //Grid con fechas de seguimiento
                this.rgSeguimiento.DataSource = seguimientoFormat;
                this.rgSeguimiento.DataBind();

            }

            this.mvConsulta.SetActiveView(vResultados);
        }


    }
}