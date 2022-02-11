using System;
using System.Text;
using System.Web;
using CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.Website.Operaciones.Registro
{
    ///<summary>
    /// Impresión de solicitud
    ///</summary>
    public partial class Imprimir : FormularioPage
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Imprimir.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Imprimir.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.Params["Citaid"]))
                {
                    //Quiere decir que un usuario gestor esta imprimiendo una cita
                    int paramCitaId = Convert.ToInt32(Request.Params["Citaid"]);
                    string usuarioActual = HttpContext.Current.Profile.UserName.ToLower();
                }

                if (this.RegistroNuevo == null || this.RegistroNuevo.RegistroId == 0)
                {
                    throw new ArgumentException("Se intento llamar la pantalla de impresion sin objetos en sesion");
                }

                #region Datos Generales

                litNoRegistro.ToSpan(this.RegistroNuevo.RegistroMercantil);
                litRnc.ToSpan(this.SociedadRegistroNuevo.Rnc);
                litRazonSocial.ToSpan(this.SociedadRegistroNuevo.NombreSocial);

                //TODO: Cambiar esto para que use el EF
                //litTipoEmpresa.ToSpan(new TiposSociedadController().GetNombreTipoSociedad(this.SociedadRegistroNuevo.TipoSociedadId.Value));
                litFechaEmision.ToSpan(Utils.FormatearFecha(this.RegistroNuevo.FechaEmision.Value, false));
                litFechaVencimiento.ToSpan(Utils.FormatearFecha(this.RegistroNuevo.FechaVencimiento.Value, false));

                string nacionalidad = this.SociedadRegistroNuevo.EsNacional ? "Empresa Local" : "Empresa Extranjera";
                litNacionalidad.ToSpan(nacionalidad);

                litTelefonoPrimario.ToSpan(this.RegistroNuevo.DireccionTelefonoOficina);
                litTelefonoSecundario.ToSpan(this.RegistroNuevo.DireccionTelefonoCasa);
                litFax.ToSpan(this.RegistroNuevo.DireccionFax);
                litEmail.ToSpan(this.RegistroNuevo.DireccionEmail);
                litDescripcionNegocio.ToSpan(this.RegistroNuevo.ActividadNegocio);
                litDireccion.ToSpan(Utils.ConstruirDireccion(this.RegistroNuevo, null));

                #endregion

                #region Datos de la Sociedad

                litCapitalSocial.ToSpan("RD$" + this.RegistroNuevo.CapitalSocial.Value.ToString("n"));
                litCapitalSuscrito.ToSpan("RD$" + this.RegistroNuevo.CapitalPagado.Value.ToString("n"));
                litBienesRaices.ToSpan("RD$" + this.RegistroNuevo.BienesRaices.Value.ToString("n"));
                litActivos.ToSpan("RD$" + this.RegistroNuevo.Activos.Value.ToString("n"));
                litFechaInicio.ToSpan(Utils.FormatearFecha(this.RegistroNuevo.FechaInicioOperacion.Value, false));
                litFechaAsamblea.ToSpan(Utils.FormatearFecha(this.SociedadRegistroNuevo.FechaAsamblea.Value, false));
                litDuracionSociedad.ToSpan(this.SociedadRegistroNuevo.DuracionSociedad);
                litDuracionConsejo.ToSpan(this.SociedadRegistroNuevo.DuraccionDirectiva);
                
                
                //Empleados
                var rangosEmpleados = RangosCantidadEmpresas.Diccionario;
                var cantEmpleados = this.RegistroNuevo.EmpleadosMasculinos;
                var strEmpleados = String.Empty;
                if (cantEmpleados.HasValue)
                {rangosEmpleados.TryGetValue(cantEmpleados.Value, out strEmpleados);}
                
                
                litEmpleados.ToSpan(strEmpleados);
                litNombreComercial.ToSpan(this.RegistroNuevo.NombreComercial);
                litMarcaFabrica.ToSpan(this.RegistroNuevo.MarcaFabrica);
                litPatente.ToSpan(this.RegistroNuevo.PatenteInvencion);

                #endregion

                #region Datos en Colecciones

                StringBuilder sbRefBancarias = new StringBuilder();
                foreach (var refbancaria in this.ReferenciasBancariasRegistro)
                {
                    sbRefBancarias.Append(refbancaria.NombreBanco + "<br/>");
                }
                litReferenciasBancarias.ToSpan(sbRefBancarias.ToString());

                StringBuilder sbRefComerciales = new StringBuilder();
                foreach (var refComercial in this.ReferenciasComercialesRegistro)
                {
                    sbRefComerciales.Append(refComercial.Descripcion + "<br/>");
                }
                litReferenciasComerciales.ToSpan(sbRefComerciales.ToString());

                StringBuilder sbEnteRegulado = new StringBuilder();
                if (this.SociedadRegistroNuevo.EsEnteRegulado)
                {
                    sbEnteRegulado.Append("Ente Regulado<br/>");
                    sbEnteRegulado.Append(String.Format("{0} - {1}", this.SociedadRegistroNuevo.NoResolucion,
                                                        this.SociedadRegistroNuevo.EsEnteRegulado));
                }
                else
                {
                    sbEnteRegulado.Append("Ente no regulado");
                }
                litregulacion.ToSpan(sbEnteRegulado.ToString());

                StringBuilder sbProductos = new StringBuilder();
                foreach (var producto in this.ProductosEnRegistro)
                {
                    sbProductos.Append(producto.Descripcion + "<br/>");
                }
                litPrincipalesProductos.ToSpan(sbProductos.ToString());

                //TODO: Actualizar para el EF
                StringBuilder sbActividades = new StringBuilder();
                //TipoActividadController actividadController = new TipoActividadController();
                foreach (var actividad in this.ActividadesEnRegistro)
                {
                    //sbActividades.AppendLine(actividadController.GetNombreActividad(actividad.AtividadId) + "<br/>");
                }
                litActividades.ToSpan(sbActividades.ToString());

                StringBuilder sbSucursales = new StringBuilder();
                foreach (var sucursal in this.SucursalesRegistro)
                {
                    sbSucursales.Append(sucursal.Descripcion + "<br/>");
                }
                litSucursales.ToSpan(sbSucursales.ToString());

                //TODO: Faltan los socios

                #endregion

                #region Otros Datos

                string citaId = string.Empty;
                this.lblNoCita.Text = citaId;
                this.lblFechaCita.Text = Utils.FormatearFecha(DateTime.Now, true);
                this.imgCodigoBarras.ImageUrl = "/GetImage.aspx?id=" + citaId;

                this.lblSolicitante.Text = this.RegistroNuevo.NombreSolicitante;
                this.lblSolicitanteCargo.Text = this.RegistroNuevo.CargoSolicitante;
                #endregion

                #region CodigoDeBarra
                if (this.TransaccionesEnRegistro.Count > 0)
                    imgCodigoBarras.ImageUrl = "~/GetImage.axd?ID=" + this.TransaccionesEnRegistro[this.TransaccionIdIndex];
                #endregion
            }
        }
    }
}
