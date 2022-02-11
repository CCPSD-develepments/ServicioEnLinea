using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.Website.DTO;

namespace CamaraComercio.Website.TarjetaCredito
{
    /// <summary>
    /// Muestra la factura en una pagina en blanco
    /// </summary>
    public partial class Factura : SecurePage
    {
        /// <summary>
        /// Carga los datos en la pantalla al iniciar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var transValida = int.TryParse(Request.QueryString["transId"], out int transId);

            if (transValida)
            {
                var dbWebSite = new CamaraWebsiteEntities();
                var dbComun = new CamaraComunEntities();

                var trans = dbWebSite.Transacciones.FirstOrDefault(
                            t => t.TransaccionId == transId && t.UserName == User.Identity.Name);

                var nombreSocial = String.Empty;
                if (trans.NumeroRegistro.HasValue)
                {
                    var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(trans.CamaraId);
                    var soc = dbSRM.SociedadesRegistros.Where(s => s.NumeroRegistro == trans.NumeroRegistro).FirstOrDefault();
                    if (soc != null)
                        nombreSocial = soc.Sociedades.NombreSocial;
                }
                else
                {
                    var registro = dbWebSite.Sociedades
                        .Where(s => s.RegistroId == trans.RegistroId)
                        .FirstOrDefault();
                    nombreSocial = registro != null
                                       ? registro.NombreSocial
                                       : trans.NombreSocialPersona;
                }

                var tipoEmpresa = String.Empty;
                if (trans.TipoSociedadId > 0)
                {
                    var obj = dbComun.TipoSociedad.Where(c => c.TipoSociedadId == trans.TipoSociedadId).First();
                    if (obj != null)
                        tipoEmpresa = obj.Etiqueta;
                }

                this.lbRegistroNo.Text = trans.NumeroRegistro.HasValue ? trans.NumeroRegistro.ToString() : String.Empty;
                this.lbDenominacion.Text = nombreSocial;
                this.lbTipoDeEmpresa.Text = tipoEmpresa;

                LoadDetalleFactura(trans);

            }
            else
            {
                ErrorMessage = "Numero de solicitud invalido o no existe.";
                Response.Redirect("~/Empresas/Oficina.aspx");
            }


        }

        private void LoadDetalleFactura(Transacciones tnx)
        {
            var detalle = new List<DetalleServicio>();
            var repTransaccion = new OFV.TransaccionesRepository();
            var dbComun = new CamaraComunEntities();

            var repServicio = new ServicioRepository();
           // tnx.Prioridad = chkExpress.Checked ? (byte)1 : (byte)0;

            var considerarMods = true;
            var servicio = dbComun.Servicio.First(s => s.ServicioId == tnx.ServicioId);
            detalle.Add(
                new DetalleServicio()
                {
                    Descripcion = servicio.DescripcionWeb ?? servicio.Descripcion,
                    Costo = repTransaccion.GetCostoTransaccionCabecera(tnx, Helper.PorcentajeVIP)
                }
                );
            if (!servicio.SeCobraEnSubTransaccion && servicio.TransaccionJerarquia > 0 ||
                Helper.ServiciosHeaderIds.Contains(servicio.ServicioId))
                considerarMods = false;

            if (tnx.SubTransacciones.Count() > 0)
            {

                foreach (var subtnx in tnx.SubTransacciones)
                {
                    var detalleFact = new DetalleServicio
                    {
                        Descripcion = subtnx.NombreServicio,
                        Costo = repTransaccion.GetCostoTransaccionSub
                                                  (subtnx, Helper.PorcentajeVIP, considerarMods, tnx.Prioridad == 1)

                    };
                    if (detalleFact.Costo > 0)
                    {
                        servicio = dbComun.Servicio.First(s => s.ServicioId == subtnx.ServicioId);
                        detalleFact.Descripcion = servicio.DescripcionWeb ?? servicio.Descripcion;
                        detalle.Add(detalleFact);
                    }

                    if (considerarMods)
                    {
                        var repTemp = new ServicioRepository();
                        //var subtotal = 0M;
                        var service = repTemp.GetServicio(subtnx.ServicioId).FirstOrDefault();
                        if (service != null && !service.SeCobraEnSubTransaccion && service.TransaccionJerarquia > 0)
                            considerarMods = false;
                    }
                }
            }


            //detalle.Add(new DetalleServicio
            //{
            //    Descripcion = "Registro de Documentos",
            //    Costo = GetCostoDocumentos(this.DocumentosSeleccionados, (tnx.Prioridad == 1))
            //});



            rpDetalles.DataSource = detalle;
            rpDetalles.DataBind();

            if (detalle.Count > 0)
                ((Label)this.rpDetalles.FindControlInFooter("txtCostoTotalTransaccion")).Text =
                    String.Format("{0:n}",
                                  detalle.Sum(d => d.Costo));

           // this.CostoTransaccion = detalle.Sum(d => d.Costo);
        }

    }
}