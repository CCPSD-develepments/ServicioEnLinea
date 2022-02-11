using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ModuloPago;
using Ofv = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.WSShareBase;
using System.Globalization;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura'
    public partial class ImprimirFactura : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura'
    {     

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura.FacturaId'
        protected int FacturaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura.FacturaId'
        {
            get
            {
                return !String.IsNullOrWhiteSpace
                        (Request.QueryString["FacturaId"])
                        ? int.Parse(Request.QueryString["FacturaId"])
                        : 0;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura.bComplementaria'
        protected bool bComplementaria
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura.bComplementaria'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["bComplementaria"])
                           ? bool.Parse(Request.QueryString["bComplementaria"])
                           : false;
            }
        }
        /// <summary>
        /// Contiene el Id de la Camara.
        /// </summary>
        protected String CamaraId
        {
            get
            {
                if (Session["CamaraId"] == null)
                    Session["CamaraId"] = String.Empty;

                return Session["CamaraId"].ToString();
            }
            set
            {
                Session["CamaraId"] = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirFactura.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            //Obteniendo datos del SRM o del Website
            if (bComplementaria)
                InitInterfaceSrm();
            else
                InitInterface();

            //Inicialización del header
            InitHeader();


        }

        /// <summary>
        /// Inicializa el header con el nombre y dirección de la cámara actual
        /// </summary>
        private void InitHeader()
        {
            var cc = new CamarasController();
            var camaraActual = cc.FetchByID(this.CamaraId).FirstOrDefault();

            if (camaraActual == null) return;
            this.lblDireccionCamara.Text = camaraActual.Direccion;


        }

        /// <summary>
        /// Inicializa el form de la factura con información de una
        /// transacción guardada en la base de datos CamaraWebsite
        /// </summary>
        private void InitInterface()
        {
            if (this.FacturaId == 0)
                return;

            var entities = new Ofv.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();

            var factura = entities.Facturas
                .FirstOrDefault(a => a.FacturaId == this.FacturaId && a.Transacciones.UserName == User.Identity.Name.ToLower());

            if (factura == null) return;

            this.CamaraId = factura.CamaraId;
            var capAutorizado = factura.Transacciones.CapitalSocial.Value2();
            var modificacionCap = factura.Transacciones.ModificacionCapital.Value2();

            //Número de registro mercantil (si aplica)
            if (factura.Transacciones.NumeroRegistro.HasValue)
            {
                ltNoRegistro.Text = factura.Transacciones.NumeroRegistro > 0
                                        ? factura.Transacciones.NumeroRegistro.ToString()
                                        : String.Empty;
            }
            else
            {
                var registro = entities.Registros.FirstOrDefault(a => a.RegistroId == factura.Transacciones.RegistroId);
                if (registro != null)
                    ltNoRegistro.Text = registro.RegistroMercantil.HasValue && registro.RegistroMercantil > 0
                            ? registro.RegistroMercantil.Value.ToString()
                            : String.Empty;
            }



            var transVisanet = PagoVisanetService.GetTransVisanet(factura.Transacciones.TransaccionId,
                                                                             EnumSystemType.CamaraOnline);
            if (transVisanet != null)
            {
                LiteralAuthCode.Text = transVisanet.AuthCode;
                LiteralMaskCard.Text = transVisanet.Tarjeta;
            }

            //cuando es renovacion se le cobra los 50 pesos extra 
            //if (factura.Transacciones.ServicioId == 398)
            //{
            //    foreach (var item in factura.TransaccionDetalle)
            //    {
            //        item.TotalBruto = item.TotalBruto + 50;
            //        item.PrecioUnitario = item.PrecioUnitario + 50;
            //        item.Total = item.Total + 50;
            //        break;
            //    }

            //}

           
            //Binding Servicios Solicitados
            var result = factura.TransaccionDetalle
                    .Select(
                    a => new
                    {
                        TransaccionDetalle = a,
                        TotalDescuento = factura.TransaccionDetalle.Sum(td => td.Descuento),
                        TotalPagar = factura.TransaccionDetalle.Sum(tp => tp.TotalBruto)
                    });



            //Forma de Pago
            decimal pa;
            decimal ps;
            decimal.TryParse(factura.TransaccionDetalle.Sum(tp => tp.TotalBruto).ToString(), out pa);
            decimal.TryParse(factura.PagoAnterior.ToString(), out ps);
            LiteralPagadoConNC.Text = string.Format("{0:N}", decimal.Round((factura.PagoAnterior), 2));
            
            decimal pagadoTarjeta = pa - ps;
            if (pagadoTarjeta > 0)
            {
                LiteralPagadoConTarjeta.Text = string.Format("{0:N}", decimal.Round((pagadoTarjeta), 2));
            }
            else
            {
                LiteralPagadoConTarjeta.Text = string.Format("{0:N}", decimal.Round((0), 2));
            }

            decimal totalBruto;
            decimal.TryParse(factura.TransaccionDetalle.Sum(tp => tp.TotalBruto).ToString(), out totalBruto);

            LiteralTotalPagado.Text = string.Format("{0:N}", decimal.Round(totalBruto, 2));

            //
            var ncfId = int.Parse(factura.TipoNcf);
            var tipoNCF = dbComun.TiposNcf.Where(t => t.SiteVisible && t.TipoNcfId == ncfId).FirstOrDefault();

            lbTipoFactura.Text = tipoNCF.Descripcion;
            litCaja.Text = Helper.UsuarioCajaFactura; // String.Empty;
            ltRNC.Text = factura.Transacciones.RNCSolicitante.FormatRnc();
            ltCliente.Text = factura.Transacciones.Solicitante;
            ltRegSolicitado.Text = factura.Transacciones.NombreSocialPersona;

            var servicio = dbComun.Servicio.FirstOrDefault(a => a.ServicioId == factura.Transacciones.ServicioId);
            //var tipoServico = dbComun.TipoServicio.FirstOrDefault(a => a.TipoServicioId == servicio.TipoServicioId);

            var nombreTipoSociedad = string.Empty;
            if (factura.Transacciones.TipoSociedadId > 0)
            {
                nombreTipoSociedad = new CamaraComunEntities()
                    .TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == factura.Transacciones.TipoSociedadId)
                    .Descripcion;
            }
            ltTipoServicio.Text = servicio.TipoServicio.Descripcion;

            //Capital
            if(/*tipoServico != null &&*/ servicio != null)
            ltProducto.Text = /*tipoServico.Descripcion +" - "+*/servicio.Descripcion + " - " + nombreTipoSociedad;
            ltCapAutorizado.Text = capAutorizado > 0 ? capAutorizado.ToString("n") : "SIN CAPITAL";
            ltCapModificado.Text = modificacionCap > 0 ? modificacionCap.ToString("n") : String.Empty;
            ltCapModificadoLbl.Visible = ltCapModificado.Text.Length > 0;

            ltNoTransaccion.Text = factura.Transacciones.TransaccionId.ToString();
            ltFecha.Text = factura.Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ltNCF.Text = factura.Ncf;

            //if (factura.Transacciones.ServicioId == 398)
            //{

                //foreach (var item in result)
                //{
                //    item.TotalPagar = item.TotalPagar;
                //}

            //    factura.TotalFactura = factura.TotalFactura  + 50;

            //    rpServicios.DataSource = result;
            //    rpServicios.DataBind();
            //    ((Label)rpServicios.FindControlInFooter("lblCredito")).Text =
            //         String.Format("{0:N}", factura.PagoAnterior);

            //    ((Label)rpServicios.FindControlInFooter("lblSubTotal")).Text =
            //        String.Format("{0:N}", factura.TotalFactura);
            //    ((Label)rpServicios.FindControlInFooter("lblTotalNeto")).Text =
            //        String.Format("{0:N}", factura.TotalFactura);

            //}
            //else
            //{

                rpServicios.DataSource = result;
                rpServicios.DataBind();
                ((Label)rpServicios.FindControlInFooter("lblCredito")).Text =
                     String.Format("{0:N}", factura.PagoAnterior);
                ((Label)rpServicios.FindControlInFooter("lblSubTotal")).Text =
                    String.Format("{0:N}", result.FirstOrDefault().TotalPagar);
                ((Label)rpServicios.FindControlInFooter("lblTotalNeto")).Text =
                    String.Format("{0:N}", factura.TotalFactura);
           // }

            var db = new CamaraWebsiteEntities();


            List<DocumentosEnFactura> docSeleccionados = new List<DocumentosEnFactura>();
            var documentos = db.TransaccionesDocumentos.Where(doc => doc.TransaccionId == factura.TransaccionId).ToList();
            foreach (var item in documentos)
            {
                var doc = db.TransaccionDocSeleccionado.FirstOrDefault(d => d.TransaccionId == item.TransaccionId && d.TipoDocumentoId == item.TipoDocumentoId);

                if (doc != null)
                {
                    docSeleccionados.Add(new DocumentosEnFactura()
                    {
                        TransaccionesDocumentosId = item.TransaccionesDocumentosId,
                        NombreDocumento = item.TipoDocumento.Nombre,
                        FechaEnvio = doc.FechaDocumento != null ? string.Format("{0:dd/MM/yyyy}", doc.FechaDocumento) : "--",
                        CantidadCopia = item.CantidadCopia,
                        CantidadOriginal = item.CantidadOriginal
                    });
                }
                else
                {
                    docSeleccionados.Add(new DocumentosEnFactura()
                    {
                        TransaccionesDocumentosId = item.TransaccionesDocumentosId,
                        NombreDocumento = item.TipoDocumento.Nombre,
                        FechaEnvio = "--",
                        CantidadCopia = item.CantidadCopia,
                        CantidadOriginal = item.CantidadOriginal
                    });
                }
            }

            rpDocumentosEnviados.DataSource = docSeleccionados;
            rpDocumentosEnviados.DataBind();
        }

        /// <summary>
        /// Inicializa el form de la factura con información de una
        /// transacción guardada en la base de datos CamaraSRM
        /// </summary>
        private void InitInterfaceSrm()
        {
            var entities = new Ofv.CamaraWebsiteEntities();
            var facturaWeb = entities.Facturas.FirstOrDefault(a => a.FacturaId == this.FacturaId);

            if (facturaWeb == null) return;
            this.CamaraId = facturaWeb.CamaraId;
            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);

            var factura = dbSrm.Facturas.FirstOrDefault(a => a.FacturaId == facturaWeb.FacturaSrmId);
            this.CamaraId = factura.CamaraId;

            //Busco el registro por el numero de registro
            var registro = dbSrm.SociedadesRegistros
                .FirstOrDefault(a => a.NumeroRegistro == factura.Transacciones.CustomInt2);

            ltCapAutorizado.Text = String.Format("{0:n}", registro.Registros.CapitalAutorizado.Value2());
            ltCapModificado.Text = String.Format("{0:n}", factura.Transacciones.CustomDecimal1.Value2());

            ltCliente.Text = registro.Registros.RegistroNombreComercial;
            ltFecha.Text = factura.Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ltNCF.Text = factura.Ncf;
            ltNoRegistro.Text = registro.NumeroRegistro.ToString();
            ltNoTransaccion.Text = factura.Transacciones.TransaccionId.ToString();
            ltProducto.Text = new CamaraComunEntities()
                .Servicio.FirstOrDefault(a => a.ServicioId == factura.Transacciones.TipoServicioId).Descripcion;
            ltRegSolicitado.Text = factura.Transacciones.NombreContacto;
            ltRNC.Text = registro.Sociedades.Rnc.FormatRnc();

            //Binding Servicios Solicitados
            var result = factura.TransaccionDetalle
                .Select(a => new
                {
                    TransaccionDetalle = a,
                    TotalDescuento = factura.TransaccionDetalle.Sum(td => td.Descuento),
                    TotalPagar = factura.TransaccionDetalle.Sum(tp => tp.TotalBruto)
                });

            rpServicios.DataSource = result;
            rpServicios.DataBind();

            ((Label)rpServicios.FindControlInFooter("lblTotalNeto")).Text =
                String.Format("{0:N}", result.FirstOrDefault().TotalPagar);

        }
    }

    class DocumentosEnFactura
    {
        public int TransaccionesDocumentosId { get; set; }
        public string NombreDocumento { get; set; }
        public string FechaEnvio { get; set; }
        public int CantidadCopia { get; set; }
        public int CantidadOriginal { get; set; }
    }
}