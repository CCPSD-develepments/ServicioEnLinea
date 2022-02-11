using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Optimo'
    public partial class Optimo : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Optimo'
    {
        CamaraWebsiteEntities dbOFV = null;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Optimo.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Optimo.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            var tr = new OFV.SociedadesRepository().GetNuevasSociedadesPendientes(HttpContext.Current.User.Identity.Name.ToLower());
            var dbWeb = new OFV.CamaraWebsiteEntities();
            List<OFV.SociedadesRepository.SociedadOfvDTO> result = new List<OFV.SociedadesRepository.SociedadOfvDTO>();

            foreach (var item in tr)
            {
                var fecha = item.FechaSolicitud;
                DateTime.TryParse(fecha.ToString(), out DateTime notNullFecha);
                var hoy = DateTime.Today;
                TimeSpan dif = hoy - notNullFecha;
                int t = dif.Days;
                if (t > 30 && item.EstatusId == 40)
                {
                    if (!dbWeb.Facturas.Any(x => x.TransaccionId == item.TransaccionID))
                    {
                        result.Add(item);
                    }
                }
            }
            if (result.Count() == 0)
            {
                Response.Redirect("~/Empresas/Oficina.aspx");
            }

            rgridAborrar.DataSource = "";
            rgridAborrar.DataSource = result;
            rgridAborrar.VirtualItemCount = result.Count();

            this.lblMensaje.Text = "Nota: Todo trámite en el estado “Solicitud Incompleta” será cancelado automáticamente por el portal al cumplir 30 días desde su fecha de creación.";
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Optimo.rgridAborrar_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        protected void rgridAborrar_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Optimo.rgridAborrar_NeedDataSource(object, GridNeedDataSourceEventArgs)'
        {
            var tr = new OFV.SociedadesRepository().GetNuevasSociedadesPendientes(HttpContext.Current.User.Identity.Name.ToLower());
            var dbWeb = new OFV.CamaraWebsiteEntities();
            List<OFV.SociedadesRepository.SociedadOfvDTO> result = new List<OFV.SociedadesRepository.SociedadOfvDTO>();

            foreach (var item in tr)
            {
                var fecha = item.FechaSolicitud;
                DateTime.TryParse(fecha.ToString(), out DateTime notNullFecha);
                var hoy = DateTime.Today;
                TimeSpan dif = hoy - notNullFecha;
                int t = dif.Days;
                if (t > 30 && item.EstatusId == 40)
                {
                    if (!dbWeb.Facturas.Any(x => x.TransaccionId == item.TransaccionID))
                    {
                        result.Add(item);
                    }
                }
            }
            rgridAborrar.DataSource = "";
            rgridAborrar.DataSource = result;
            rgridAborrar.VirtualItemCount = result.Count();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Optimo.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Optimo.btnContinuar_Click(object, EventArgs)'
        {
            var tr = new OFV.SociedadesRepository().GetNuevasSociedadesPendientes(HttpContext.Current.User.Identity.Name.ToLower());
            var dbWeb = new OFV.CamaraWebsiteEntities();
            List<OFV.SociedadesRepository.SociedadOfvDTO> result = new List<OFV.SociedadesRepository.SociedadOfvDTO>();

            foreach (var item in tr)
            {
                var fecha = item.FechaSolicitud;
                DateTime.TryParse(fecha.ToString(), out DateTime notNullFecha);
                var hoy = DateTime.Today;
                TimeSpan dif = hoy - notNullFecha;
                int t = dif.Days;
                if (t > 30 && item.EstatusId == 40)
                {
                    if (!dbWeb.Facturas.Any(x => x.TransaccionId == item.TransaccionID))
                    {
                        result.Add(item);
                    }
                }
            }
            this.lblMensaje.Text = $"Se van a borrar {result.Count}...";
            foreach (var item in result)
            {
                delete(item.TransaccionID);
            }

            Response.Redirect("~/Empresas/Oficina.aspx");

        }

        void delete(int noSolicitud)
        {
            dbOFV = new OFV.CamaraWebsiteEntities();
            var dbUsers = new CamaraComercio.DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            bool saved = false;

            // aqui se busca la transaccion que se va a borrar.
            var transaccion = (from tr in dbOFV.Transacciones
                               where tr.TransaccionId.Equals(noSolicitud)
                               select tr).FirstOrDefault();

            //Determinar usuario padre
            var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == this.User.Identity.Name.ToLower()).Select(c => c.UsuarioPadre).FirstOrDefault();
            uPadre = uPadre == null ? this.User.Identity.Name.ToLower() : uPadre.ToLower();

            if ((!transaccion.UserName.Equals(this.User.Identity.Name.ToLower().ToString()) && !this.User.Identity.Name.ToLower().Equals(uPadre)) || transaccion.bPagada || transaccion.SrmTransaccionId.HasValue)
            {
                this.lblMensaje.Text = $"Usted no puede borrar esta transaccion {transaccion.TransaccionId}";
                return;
            }
            //Creo un transaccion scope por si da error borrando en alguna tabla no se realice el cambio.
            using (TransactionScope tsTransScope = new TransactionScope())
            {
                GrabarTransaccionesCanceladas(transaccion);
                BorrarTransaccion(transaccion);
                saved = dbOFV.SaveChanges() > 0;

                bool r = true;
                if (!string.IsNullOrEmpty(transaccion.FolderId))
                {
                        r = BorrarFolderEnShareBase(transaccion.FolderId);
                }

                if (r)
                {
                    this.lblMensaje.Text=(string.Format("No Solicitud: {0} Cancelado", transaccion.TransaccionId));
                }

                else
                {
                    this.lblMensaje.Text="No se pudo eliinar la transaccion.";
                    return;
                }

                tsTransScope.Complete();
            }
        }
        private void GrabarTransaccionesCanceladas(Transacciones transaccion)
        {
            TransaccionesCanceladas tr = new TransaccionesCanceladas();

            tr.ApellidoPersona = transaccion.ApellidoPersona;
            tr.bLoadedInSRM = transaccion.bLoadedInSRM;
            tr.bPagada = transaccion.bPagada;
            tr.CamaraId = transaccion.CamaraId;
            tr.CapitalSocial = transaccion.CapitalSocial;
            tr.Comentario = transaccion.Comentario;
            tr.DestinoTraslado = transaccion.DestinoTraslado;
            //tr.EsDigital = transaccion.EsDigital;
            tr.EstatusTransId = transaccion.EstatusTransId;
            tr.FaxContacto = transaccion.FaxContacto;
            tr.Fecha = transaccion.Fecha;
            tr.FechaAsamblea = transaccion.FechaAsamblea;
            tr.FechaReciboDGII = transaccion.FechaReciboDGII;
            tr.InstanceXML = transaccion.InstanceXML;
            tr.ModificacionCapital = transaccion.ModificacionCapital;
            tr.MontoDGII = transaccion.MontoDGII;
            tr.NCF = transaccion.NCF;
            tr.NombreContacto = transaccion.NombreContacto;
            tr.NombreSocialPersona = transaccion.NombreSocialPersona;
            tr.NoReciboDGII = transaccion.NoReciboDGII;
            tr.NumeroRegistro = transaccion.NumeroRegistro;
            tr.Prioridad = transaccion.Prioridad;
            //tr.ReCheck = transaccion.ReCheck;
            tr.RegistroId = transaccion.RegistroId;
            tr.RNCSolicitante = transaccion.RNCSolicitante;
            tr.ServicioId = transaccion.ServicioId;
            tr.Solicitante = transaccion.Solicitante;
            tr.SrmTransaccionId = transaccion.SrmTransaccionId;
            tr.SubTransaccionId = transaccion.SubTransaccionId;
            tr.TelefonoContacto = transaccion.TelefonoContacto;
            tr.Tipo = transaccion.Tipo;
            tr.TipoComprobanteId = transaccion.TipoComprobanteId;
            tr.TipoModeloId = transaccion.TipoModeloId;
            tr.TipoNcf = transaccion.TipoNcf;
            tr.TipoSociedadId = transaccion.TipoSociedadId;
            tr.Token = transaccion.Token;
            tr.TransaccionId = transaccion.TransaccionId;
            tr.UserName = this.User.Identity.Name.ToLower();
            //tr.VieneProblema = transaccion.VieneProblema;

            dbOFV.TransaccionesCanceladas.AddObject(tr);
        }

        private void BorrarTransaccion(Transacciones transaccion)
        {
            BorrarTransaccionesDocumentos(transaccion.TransaccionId);
            BorrarTransaccionesDocumentoDescargas(transaccion.TransaccionId);
            BorrarTransaccionesDocumentoSeleccionado(transaccion.TransaccionId);
            BorrarTransaccionesFacturas(transaccion.TransaccionId);
            BorrarSubtransacciones(transaccion.TransaccionId);
            BorrarEmpresasPorUsuario(transaccion.TransaccionId);
            BorrarTransaccionesRegistros(transaccion.TransaccionId);

            dbOFV.Transacciones.DeleteObject(transaccion);
        }

        private void BorrarTransaccionesDocumentos(int transaccionId)
        {
            var doc = from fac in dbOFV.TransaccionesDocumentos
                      where fac.TransaccionId.Equals(transaccionId)
                      select fac;

            foreach (var item in doc)
                dbOFV.TransaccionesDocumentos.DeleteObject(item);
        }

        private void BorrarTransaccionesDocumentoDescargas(int transaccionId)
        {
            var docDescarga = from fac in dbOFV.TransaccionesDocDescargas
                              where fac.TransaccionId.Equals(transaccionId)
                              select fac;

            foreach (var item in docDescarga)
                dbOFV.TransaccionesDocDescargas.DeleteObject(item);

        }
        private void BorrarTransaccionesDocumentoSeleccionado(int transaccionId)
        {
            var trOrigen = (from transaccion in dbOFV.TransaccionDocSeleccionado
                            where transaccion.TransaccionId.Equals(transaccionId)
                            select transaccion);

            foreach (var item in trOrigen)
                dbOFV.TransaccionDocSeleccionado.DeleteObject(item);
        }
        private void BorrarTransaccionesFacturas(int transaccionId)
        {
            var factura = from fac in dbOFV.Facturas
                          where fac.TransaccionId.HasValue && fac.TransaccionId.Value.Equals(transaccionId)
                          select fac;

            foreach (var item in factura)
            {
                //BorrarFormasPagos(item.FacturaId);
                BorrarTransaccionDetalle(item.FacturaId);
                BorrarTransaccionesTarjeta(item.FacturaId);

                dbOFV.Facturas.DeleteObject(item);
            }


        }
        private void BorrarTransaccionDetalle(int facturaId)
        {
            var factura = from fac in dbOFV.TransaccionDetalle
                          where fac.FacturaId.Equals(facturaId)
                          select fac;

            foreach (var item in factura)
                dbOFV.TransaccionDetalle.DeleteObject(item);

        }
        private void BorrarTransaccionesTarjeta(int facturaId)
        {
            var factura = from fac in dbOFV.TransaccionesTarjeta
                          where fac.FacturaId.Equals(facturaId)
                          select fac;

            foreach (var item in factura)
                dbOFV.TransaccionesTarjeta.DeleteObject(item);
        }

        private void BorrarSubtransacciones(int transaccionId)
        {
            var subtransacciones = (from transaccion in dbOFV.Transacciones
                                    where transaccion.SubTransaccionId.HasValue && transaccion.SubTransaccionId.Value.Equals(transaccionId)
                                    select transaccion);

            foreach (var item in subtransacciones)
            {
                BorrarTransaccion(item);
            }

        }
        private void BorrarEmpresasPorUsuario(int transaccionId)
        {
            var empresas = (from transaccion in dbOFV.EmpresasPorUsuario
                            where transaccion.TransaccionId.HasValue && transaccion.TransaccionId.Value.Equals(transaccionId)
                            select transaccion);

            foreach (var item in empresas)
                dbOFV.EmpresasPorUsuario.DeleteObject(item);
        }
        private void BorrarTransaccionesRegistros(int transaccionId)
        {
            var reg = dbOFV.Registros.Where(x => x.TransaccionId == transaccionId);
            var sociedad = dbOFV.Sociedades.Where(x => x.TransaccionId == transaccionId);

            var socios = dbOFV.Socios.Join(reg, a => a.RegistroId, b => b.RegistroId, (a, b) => a);
            var refc = dbOFV.ReferenciasComerciales.Join(reg, a => a.RegistroId, b => b.RegistroId, (a, b) => a);
            var refb = dbOFV.ReferenciasBancarias.Join(reg, a => a.RegistroId, b => b.RegistroId, (a, b) => a);

            foreach (var item in sociedad) dbOFV.Sociedades.DeleteObject(item);
            foreach (var item in refb) dbOFV.ReferenciasBancarias.DeleteObject(item);
            foreach (var item in refc) dbOFV.ReferenciasComerciales.DeleteObject(item);
            foreach (var item in socios) dbOFV.Socios.DeleteObject(item);
            foreach (var item in reg) dbOFV.Registros.DeleteObject(item);
        }
        private bool BorrarFolderEnShareBase(string FoldId)
        {
            if (Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    var resp = client.DeleteFolderOnSharebase(long.Parse(FoldId));
                    return resp.Success;
                }
            }
            return true;
        }
    }
}