﻿using System;
using System.Globalization;
using System.Linq;
using CamaraComercio.Website.Operaciones.Modificaciones;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using CamaraComun = CamaraComercio.DataAccess.EF.CamaraComun;
using EF = CamaraComercio.DataAccess.EF;
using System.Web.Security;
using System.Text;
using System.Collections.Generic;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud'
    public partial class ImprimirSolicitud : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.IdTransaciones'
        public int IdTransaciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.IdTransaciones'
        {
            get { return Session["IdTransacciones"] != null ? int.Parse(Session["IdTransacciones"].ToString()) : 0; }
            set { Session["IdTransacciones"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.FacturaId'
        protected int FacturaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.FacturaId'
        {
            get
            {
                return Session["FacturaId"] != null ? int.Parse(Session["FacturaId"].ToString()) : 0;
            }
            set { Session["FacturaId"] = value; }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.SectoresList'
        public List<Sectores> SectoresList;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.SectoresList'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.CiudadesList'
        public List<Ciudades> CiudadesList;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.CiudadesList'

        #region Manejo de Eventos

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ImprimirSolicitud.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            InitInterface();

            //SendMailSolicitud();
            //SendMailFactura();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para inicializar toda la informacion de la solicitud para impresion.
        /// </summary>
        protected void InitInterface()
        {
            var dbCamaraWebSite = new OFV.CamaraWebsiteEntities();
            var dbComunEntities = new CamaraComunEntities();
            var dbUsers = new CamaraComercio.DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            int result;
            int.TryParse(Request.QueryString["nSolicitud"], out result);
            IdTransaciones = result > 0 ? result : IdTransaciones;


            //Cargando Entidades
            var transacion = dbCamaraWebSite.Transacciones.FirstOrDefault(a =>
                                                                          a.TransaccionId == IdTransaciones);
            //&& a.UserName == User.Identity.Name
            //Si es el usuario padre puede imprimir esta solicitud
            var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == this.User.Identity.Name.ToLower()).Select(c => c.UsuarioPadre).FirstOrDefault();
            uPadre = uPadre == null ? this.User.Identity.Name.ToLower() : uPadre.ToLower();

            if (transacion == null && (!this.User.Identity.Name.Equals(uPadre) && !transacion.UserName.Equals(User.Identity.Name.ToLower())))
            {
                mv1.SetActiveView(v2);
                return;
            }


            mv1.SetActiveView(v1);

            var fact = transacion.Facturas.FirstOrDefault();
            if (this.FacturaId == 0 && fact != null)
                this.FacturaId = fact.FacturaId;

            //var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transacion.CamaraId);
            var servicio = dbComunEntities.Servicio.FirstOrDefault(a => a.ServicioId == transacion.ServicioId);

            var nombretiposoc = new CamaraComunEntities().TipoSociedad
                .FirstOrDefault(a => a.TipoSociedadId == transacion.TipoSociedadId);

            string nombreTipoSociedad = string.Empty;

            if (nombretiposoc != null)
                nombreTipoSociedad = nombretiposoc.Descripcion;

            #region Solicitud
            //Llenando Info de Interfaz
            lblFechaCita.Text = transacion.Fecha.ToStringDom();
            lblNoCita.Text = transacion.TransaccionId.ToString();

            litTipoSolicitud.Text = String.Format("{0} - {1}", servicio.TipoServicio.DescripcionWeb,
                                                  nombreTipoSociedad);

            litNoRegistro.Text = transacion.TransaccionId.ToString();

            litTipoServicio.Text = String.Format("{0} - {1}", servicio.DescripcionWeb,
                                                  nombreTipoSociedad);

            litServicio.Text = String.Format("{0} - {1}", servicio.TipoServicio.DescripcionWeb,
                                                  nombreTipoSociedad);

            litExpress.Visible = Convert.ToBoolean(transacion.Prioridad);

            LiteralComentario.Text = transacion.Comentario;

            #endregion

            litDenomSocial.Text = transacion.NombreSocialPersona;



            #region Solicitante

            var usuarioActual = OficinaVirtualUserProfile.GetUserProfile(transacion.UserName);
            litNombreContacto.Text = transacion.NombreContacto;
            litCedulaContacto.Text = transacion.RNCSolicitante;

            var user = Membership.GetUser(User.Identity.Name);
            if (user != null)
                litEmail.Text = user.Email;


            #endregion

            #region BarCode Image

            imgCodigoBarras.ImageUrl = "~/GetImage.axd?ID=" + transacion.TransaccionId;

            #endregion

            #region Empresa Solicitada

            var servicioObj = dbComunEntities.Servicio.FirstOrDefault(t => t.ServicioId == transacion.ServicioId);
            //if (servicioObj != null &&  servicioObj.TipoServicioId != Helper.TipoServicioId)
            //{
            //    this.pnlInfoEmpresa.Visible = false;
            //    this.gvSociosT.Visible = false;
            //    this.gvDocumentos.Visible = false;
            //    return;
            //}


            if (transacion.RegistroId > 0)
            {
                //var empresa = dbSrm.ViewSociedadesRegistros.FirstOrDefault(a => a.NumeroRegistro == transacion.NumeroRegistro);

                //if (empresa != null)
                //{
                var soc = dbCamaraWebSite.Sociedades.Where(s => s.RegistroId == transacion.RegistroId).FirstOrDefault();
                var reg = dbCamaraWebSite.Registros.Where(r => r.RegistroId == transacion.RegistroId).FirstOrDefault();
                if (soc != null && reg != null)
                {
                    ltRegistroMercantil.Text = reg.RegistroMercantil > 0 ? reg.RegistroMercantil.ToString() : "N/A";

                    litNombreComercial.Text = reg.NombreComercial;
                    litRegistroOnapi.Text = reg.RegistroNombreComercial;

                    var tipoSociedad = dbComunEntities.TipoSociedad
                        .Where(ts => ts.TipoSociedadId == soc.TipoSociedadId).FirstOrDefault();
                    litTipoEmpresa.Text = tipoSociedad != null ? tipoSociedad.Descripcion : "";

                    if (soc.FechaConstitucion.HasValue)
                    {
                        litFechaConstitucion.Text = soc.FechaConstitucion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        litFechaConstitucion.Visible = false;
                        litFechaConstitucionTit.Visible = false;
                    }

                    if (reg != null)
                    {
                        litDireccion.Text = string.Format("{0} No {1},", reg.DireccionCalle, reg.DireccionNumero);
                        litTelefonoPrimario.ToSpan(reg.DireccionTelefonoOficina.FormatTelefono());
                        litTelefonoSecundario.ToSpan(reg.DireccionTelefonoCasa.FormatTelefono());
                        litFax.ToSpan(reg.DireccionFax.FormatTelefono());
                        litEmail.ToSpan(reg.DireccionEmail);
                        litWebsite.ToSpan(reg.DireccionSitioWeb);
                    }

                    litCapitalSocial.Text = reg.CapitalSocial.HasValue && reg.CapitalSocial > 0
                                                ? reg.CapitalSocial.Value.ToString("n")
                                                : "-";
                    litCapitalSuscrito.Text = reg.CapitalPagado.HasValue && reg.CapitalPagado > 0
                                                  ? reg.CapitalPagado.Value.ToString("n")
                                                  : "-";
                    //DATOS DE LA SOCIEDAD
                    litCapitalSocial.ToSpan(reg.CapitalSocial > 0
                                                ? "RD$" + reg.CapitalSocial.Value2().ToString("n")
                                                : "SIN CAPITAL SOCIAL");

                    litCapitalSuscrito.ToSpan(reg.CapitalPagado > 0
                                                ? "RD$" + reg.CapitalPagado.Value2().ToString("n")
                                                : String.Empty);
                    litBienesRaices.ToSpan("RD$" + reg.BienesRaices.Value2().ToString("n"));
                    litActivos.ToSpan("RD$" + reg.Activos.Value2().ToString("n"));

                    //Otros
                    int duracionSociedad;
                    Int32.TryParse(soc.DuracionSociedad, out duracionSociedad);
                    litDuracionSociedad.ToSpan(duracionSociedad > 0 ? soc.DuracionSociedad : "INDEFINIDA");

                    var pais = dbComunEntities.Paises.Where(p => p.PaisId == soc.NacionalidadId).FirstOrDefault();
                    if (pais != null)
                        this.litNacionalidad.Text = pais.Nombre;

                    if (soc.DuraccionDirectiva.HasValue && soc.DuraccionDirectiva > 0)
                        litDuracionConsejo.ToSpan(soc.DuraccionDirectiva);
                    else
                    {
                        soc.DuraccionDirectiva = 0;
                        litDuracionConsejo.Text = "-";
                    }

                    //Revisión de fechas para evitar error de MinDate
                    if (reg.FechaInicioOperacion.HasValue && reg.FechaInicioOperacion != DateTime.MinValue)
                        litFechaInicio.ToSpan(Utils.FormatearFecha(reg.FechaInicioOperacion.Value2()));

                    if (soc.FechaAsamblea.HasValue && soc.FechaAsamblea != DateTime.MinValue)
                        litFechaAsamblea.ToSpan(Utils.FormatearFecha(soc.FechaAsamblea.Value2()));

                    //Entes Regulados
                    var sbEnteRegulado = new StringBuilder();
                    if (soc.EsEnteRegulado && soc.TipoEnteReguladoId > 0)
                    {
                        var descEnteRegulado = dbComunEntities.TiposEnteRegulado.Where(
                                                t => t.TipoEnteReguladoId == soc.TipoEnteReguladoId)
                                                .FirstOrDefault();
                        sbEnteRegulado.Append(String.Format("{0} - {1}", soc.NoResolucion, descEnteRegulado.Descripcion));
                    }
                    else
                    {
                        sbEnteRegulado.Append("Ente no regulado");
                    }
                    litregulacion.ToSpan(sbEnteRegulado.ToString());

                    var strEmpleados = String.Format("M: {0} / F: {1}",
                                                           reg.EmpleadosMasculinos,
                                                           reg.EmpleadosFemeninos);
                    litEmpleados.ToSpan(strEmpleados);

                    //Referencias =s
                    var refBancariasIds = reg.ReferenciasBancarias.Select(r => r.BancoId).Distinct().ToList();
                    var refBancarias = dbComunEntities.Bancos.Where(b => refBancariasIds.Contains(b.BancoId)).ToList();
                    var sbRefBancarias = new StringBuilder();
                    foreach (var refBancaria in refBancarias)
                    {
                        sbRefBancarias.Append(refBancaria.Descripcion + "<br/>");
                    }
                    litReferenciasBancarias.ToSpan(sbRefBancarias.ToString());

                    //Referencias Comerciales
                    var sbRefComerciales = new StringBuilder();
                    foreach (var refComercial in reg.ReferenciasComerciales)
                    {
                        sbRefComerciales.Append(refComercial.Descripcion + "<br/>");
                    }
                    litReferenciasComerciales.ToSpan(sbRefComerciales.ToString());


                    var socios = dbCamaraWebSite.Socios.Where(s => s.RegistroId == transacion.RegistroId).ToList();
                    var socioTempList = socios.Select(s => s.Id).ToList();
                    //var personas = dbSrm.Personas.Where(p => socioTempList.Contains(p.PersonaId)).ToList();

                    var socioList = from s in socios
                                    select new SociosDTO()
                                    {
                                        ID = s.Id,
                                        TipoSocio = s.TipoSocio,
                                        TipoRelacion = s.TipoRelacion,
                                        CargoId = s.CargoId,
                                        TipoDocumento = s.TipoDocumento,
                                        Documento = s.Documento,
                                        PersonaPrimerNombre = s.PersonaPrimerNombre,
                                        PersonaSegundoNombre = s.PersonaSegundoNombre,
                                        PersonaPrimerApellido = s.PersonaPrimerApellido,
                                        PersonaSegundoApellido = s.PersonaSegundoApellido,
                                        CantidadAcciones = s.CantidadAcciones,
                                        Direccion = string.Format("{0} No {1}", s.DireccionCalle, s.DireccionNumero),
                                        RepresentanteId = s.RepresentanteId,
                                       
                                    };

                    if (socioList.Count() <= 0)
                    {
                        socioList = from sociedad in dbCamaraWebSite.Socios
                                    where sociedad.RegistroId.Equals(soc.RegistroId)
                                    select new SociosDTO
                                    {
                                        ID = sociedad.Id,
                                        TipoSocio = sociedad.TipoSocio,
                                        TipoRelacion = sociedad.TipoRelacion,
                                        CargoId = sociedad.CargoId,
                                        TipoDocumento = sociedad.TipoDocumento,
                                        Documento = sociedad.Documento,
                                        PersonaPrimerNombre = sociedad.PersonaPrimerNombre,
                                        PersonaSegundoNombre = sociedad.PersonaSegundoNombre,
                                        PersonaPrimerApellido = sociedad.PersonaPrimerApellido,
                                        PersonaSegundoApellido = sociedad.PersonaSegundoApellido,
                                        CantidadAcciones = sociedad.CantidadAcciones,
                                        Direccion = sociedad.DireccionCalle,
                                        RepresentanteId = sociedad.RepresentanteId
                                    };
                    }
                    try
                    {
                        //Listado de IDs unicos
                        var socioListGrid = new List<SociosGridDTO>();
                        var sociosDistinct = socioList.Select(s => new { s.TipoDocumento, s.Documento }).Distinct().ToList();
                        //var ids = socioList.Select(c => c.ID).Distinct();
                        var cargosList = dbComunEntities.Cargos.ToList();
                        var tipoSocios = dbComunEntities.TipoSociedadSocio
                                        .Where(ts => ts.TipoSociedadId == soc.TipoSociedadId).ToList();

                        foreach (var socioId in sociosDistinct)
                        {
                            var socioenGrid = new SociosGridDTO();
                            var socio = socioList.Select(s=>s).Where(s => s.Documento == socioId.Documento && s.TipoDocumento == socioId.TipoDocumento);

                            socioenGrid.Nombre = FormatearNombreSocio(socio.FirstOrDefault());
                            socioenGrid.Direccion = socio.FirstOrDefault().Direccion;
                            socioenGrid.Documento = socio.First().Representante == null ? socio.First().Documento : socio.First().Representante.Documento;

                            var accionista = socio.Where(s => s.TipoRelacion == "A").FirstOrDefault();
                            if (accionista != null)
                                socioenGrid.Cuotas = accionista.CantidadAcciones;

                            socioenGrid.Cargos = FormatearCargosSocio(socio, tipoSocios, cargosList);
                            socioListGrid.Add(socioenGrid);
                        }

                        this.gvSociosT.DataSource = socioListGrid;
                        this.gvSociosT.DataBind();

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    //}

                }
                //else
                //{
                //    var empresa = dbCamaraWebSite.Registros.FirstOrDefault(a => a.RegistroId == transacion.RegistroId);
                //    var soc = dbCamaraWebSite.Sociedades.FirstOrDefault(a => a.RegistroId == transacion.RegistroId);

                //    if (soc != null)
                //    {
                //        //Numero de registro
                //        ltRegistroMercantil.Text = empresa.RegistroMercantil.HasValue && empresa.RegistroMercantil > 0
                //                                       ? empresa.RegistroMercantil.ToString()
                //                                       : "N/A";

                //        //Tipo de sociedad
                //        var tipoSoc = dbComunEntities.TipoSociedad
                //            .Where(ts => ts.TipoSociedadId == soc.TipoSociedadId)
                //            .FirstOrDefault().Descripcion;
                //        litTipoEmpresa.Text = !String.IsNullOrEmpty(tipoSoc) ? tipoSoc : "N/A";

                //        //Fecha Constitucion
                //        if (soc.FechaConstitucion.HasValue)
                //        {
                //            litFechaConstitucion.Text = soc.FechaConstitucion.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                //        }
                //        else
                //        {
                //            litFechaConstitucion.Visible = false;
                //            litFechaConstitucionTit.Visible = false;
                //        }

                //        //Direccion
                //        var reg = dbCamaraWebSite.Registros.Where(r => r.RegistroId == soc.RegistroId).First();
                //        if (reg != null)
                //            litDireccion.Text = Utils.ConstruirDireccion(reg, null);

                //        litNombreComercial.Text = reg.NombreComercial;
                //        litRegistroOnapi.Text = reg.RegistroNombreComercial;
                //        litTelefonoPrimario.ToSpan(reg.DireccionTelefonoOficina.FormatTelefono());
                //        litTelefonoSecundario.ToSpan(reg.DireccionTelefonoCasa.FormatTelefono());
                //        litFax.ToSpan(reg.DireccionFax.FormatTelefono());
                //        litEmail.ToSpan(reg.DireccionEmail);
                //        litWebsite.ToSpan(reg.DireccionSitioWeb);

                //        //Datos de sociedad
                //        litCapitalSocial.ToSpan(reg.CapitalSocial > 0
                //                                    ? "RD$" + reg.CapitalSocial.Value2().ToString("n")
                //                                    : "SIN CAPITAL SOCIAL");

                //        litCapitalSuscrito.ToSpan(reg.CapitalPagado > 0
                //                                    ? "RD$" + reg.CapitalPagado.Value2().ToString("n")
                //                                    : String.Empty);

                //        litBienesRaices.ToSpan("RD$" + reg.BienesRaices.Value2().ToString("n"));
                //        litActivos.ToSpan("RD$" + reg.Activos.Value2().ToString("n"));

                //        //Otros
                //        var pais = dbComunEntities.Paises.Where(p => p.PaisId == soc.NacionalidadId).FirstOrDefault();
                //        if (pais != null)
                //            this.litNacionalidad.Text = pais.Nombre;

                //        int duracionSociedad;
                //        Int32.TryParse(soc.DuracionSociedad, out duracionSociedad);
                //        litDuracionSociedad.ToSpan(duracionSociedad > 0 ? soc.DuracionSociedad : "INDEFINIDA");

                //        if (soc.DuraccionDirectiva.HasValue && soc.DuraccionDirectiva > 0)
                //            litDuracionConsejo.ToSpan(soc.DuraccionDirectiva);
                //        else
                //        {
                //            soc.DuraccionDirectiva = 0;
                //            litDuracionConsejo.Text = "-";
                //        }

                //        //Revisión de fechas para evitar error de MinDate
                //        if (reg.FechaInicioOperacion.HasValue && reg.FechaInicioOperacion != DateTime.MinValue)
                //            litFechaInicio.ToSpan(Utils.FormatearFecha(reg.FechaInicioOperacion.Value2()));

                //        if (soc.FechaAsamblea.HasValue && soc.FechaAsamblea != DateTime.MinValue)
                //            litFechaAsamblea.ToSpan(Utils.FormatearFecha(soc.FechaAsamblea.Value2()));

                //        //Entes Regulados
                //        var sbEnteRegulado = new StringBuilder();
                //        if (soc.EsEnteRegulado && soc.TipoEnteReguladoId > 0)
                //        {
                //            var descEnteRegulado = dbComunEntities.TiposEnteRegulado.Where(
                //                                    t => t.TipoEnteReguladoId == soc.TipoEnteReguladoId)
                //                                    .FirstOrDefault();
                //            sbEnteRegulado.Append(String.Format("{0} - {1}", soc.NoResolucion, descEnteRegulado.Descripcion));
                //        }
                //        else
                //        {
                //            sbEnteRegulado.Append("Ente no regulado");
                //        }
                //        litregulacion.ToSpan(sbEnteRegulado.ToString());

                //        var strEmpleados = String.Format("M: {0} / F: {1}",
                //                                               reg.EmpleadosMasculinos,
                //                                               reg.EmpleadosFemeninos);

                //        var refBancariasIds = reg.ReferenciasBancarias.Select(r => r.BancoId).Distinct().ToList();
                //        var refBancarias = dbComunEntities.Bancos.Where(b => refBancariasIds.Contains(b.BancoId)).ToList();
                //        var sbRefBancarias = new StringBuilder();
                //        foreach (var refBancaria in refBancarias)
                //        {
                //            sbRefBancarias.Append(refBancaria.Descripcion + "<br/>");
                //        }
                //        litReferenciasBancarias.ToSpan(sbRefBancarias.ToString());

                //        //Referencias Comerciales
                //        var sbRefComerciales = new StringBuilder();
                //        foreach (var refComercial in reg.ReferenciasComerciales)
                //        {
                //            sbRefComerciales.Append(refComercial.Descripcion + "<br/>");
                //        }
                //        litReferenciasComerciales.ToSpan(sbRefComerciales.ToString());


                //        litEmpleados.ToSpan(strEmpleados);
                //        var socios = dbCamaraWebSite.Socios.Where(r => r.RegistroId == empresa.RegistroId).ToList();
                //        var socioList = socios.Select(
                //        s => new SociosDTO()
                //        {
                //            ID = s.Id,
                //            TipoSocio = s.TipoSocio,
                //            TipoRelacion = s.TipoRelacion,
                //            CargoId = s.CargoId,
                //            TipoDocumento = s.TipoDocumento,
                //            Documento = s.Documento,
                //            SociedadNombreSocial = s.SociedadNombreSocial,
                //            PersonaPrimerNombre = s.PersonaPrimerNombre,
                //            PersonaSegundoNombre = s.PersonaSegundoNombre,
                //            PersonaPrimerApellido = s.PersonaPrimerApellido,
                //            PersonaSegundoApellido = s.PersonaSegundoApellido,
                //            CantidadAcciones = s.CantidadAcciones,
                //            Direccion = FormatearDireccion(s.DireccionCalle, s.DireccionNumero, s.DireccionCiudadId, s.DireccionSectorId)
                //        });

                //        //Listado de IDs unicos
                //        var socioListGrid = new List<SociosGridDTO>();
                //        var sociosDistinct = socioList.Select(s => new { s.TipoDocumento, s.Documento }).Distinct().ToList();
                //        var cargosList = dbComunEntities.Cargos.ToList();
                //        var tipoSocios = dbComunEntities.TipoSociedadSocio
                //                        .Where(ts => ts.TipoSociedadId == soc.TipoSociedadId).ToList();
                //        foreach (var socioId in sociosDistinct)
                //        {
                //            var socioenGrid = new SociosGridDTO();
                //            var socio = socioList.Where(s => s.Documento == socioId.Documento && s.TipoDocumento == socioId.TipoDocumento);

                //            socioenGrid.Nombre = FormatearNombreSocio(socio.First());
                //            socioenGrid.Documento = socio.First().Representante == null ? socio.First().Documento : socio.First().Representante.Documento;

                //            var accionista = socio.Where(s => s.TipoRelacion == "A").FirstOrDefault();
                //            if (accionista != null)
                //                socioenGrid.Cuotas = accionista.CantidadAcciones;

                //            socioenGrid.Direccion = socio.FirstOrDefault().Direccion;
                //            socioenGrid.Cargos = FormatearCargosSocio(socio, tipoSocios, cargosList);
                //            socioListGrid.Add(socioenGrid);
                //        }

                //        this.gvSociosT.DataSource = socioListGrid;
                //        this.gvSociosT.DataBind();
                //    }
                //}
            #endregion

                #region Documentos Requeridos

                var docIds = transacion.TransaccionDocSeleccionado.Select(t => t.TipoDocumentoId).ToList();
                var tiposDocs = dbComunEntities.TipoDocumento.Where(t => docIds.Contains(t.TipoDocumentoId)).ToList();
                var docs = from d in transacion.TransaccionDocSeleccionado
                           join t in tiposDocs on d.TipoDocumentoId equals t.TipoDocumentoId
                           select new
                           {
                               t.TipoDocumentoId,
                               t.Nombre,
                               FechaDocumento = d.FechaDocumento.HasValue ? d.FechaDocumento.Value.ToString("dd MMM yyyy", new CultureInfo("es-DO")) : String.Empty,
                               d.CantidadCopia,
                               d.CantidadOriginal
                           };

                gvDocumentos.DataSource = docs;
                gvDocumentos.DataBind();

                #endregion

            }
        }
        private void SendMailSolicitud()
        {
            //buscar documentos requeridos
            var transacion = new OFV.CamaraWebsiteEntities().Transacciones.
                FirstOrDefault(a => a.TransaccionId == this.IdTransaciones &&
                                    a.UserName == User.Identity.Name.ToLower());
            if (transacion == null) return;

            //Armar el correo a enviar
            var parametros = new Dictionary<string, string>
                                 {
                                     {"[NoSolicitud]", this.lblNoCita.Text},
                                     {"[FechaSolicitud]", this.lblFechaCita.Text},
                                     {"[TipoSolicitud]", this.litTipoSolicitud.Text},
                                     {"[TipoServicio]", this.litTipoServicio.Text},
                                     {"[NoRegistroMercatil]", ltRegistroMercantil.Text},
                                     {"[RazonSocial]", this.litDenomSocial.Text},
                                     {"[TipoEmpresa]", this.litTipoEmpresa.Text},
                                     {"[FechaConstitucion]", this.litFechaConstitucion.Text},
                                     {"[NombreSolicitante]", this.litNombreContacto.Text},
                                     {"[TelefonoPrimario]", this.litTelefonoPrimario.Text},
                                     {"[EmailSolicitante]", this.litEmail.Text},
                                     {"[NombreServicioTitulo]", this.litServicio.Text}
                                 };


            //Esto elimnialo porque arriba ahace esta busqueda despues lo arreglas
            var docs1 = ServicioDocumentosRequeridosControler.GetDocumentosRequeridos(transacion.ServicioId, transacion.TipoSociedadId);

            //armar html de <li> para mail
            var htmlDocs = new StringBuilder();

            foreach (var doc in docs1)
                htmlDocs.Append(String.Format("<li style=\"border-bottom: solid 1px #d5e2ed;padding: 5px 0;\">{0}</li>", doc.TipoDocumento.Nombre));

            parametros.Add("[DocumentosRequeridos]", htmlDocs.ToString());

            //buscar el header de la camara.
            var comunDB = new CamarasController();
            var header = comunDB.FetchByID(transacion.CamaraId).FirstOrDefault().HeaderImpresiones;

            //agregar el header a los parametros de la camara.
            parametros.Add("[Header]", header);

            //buscar el usuario
            var user = Membership.GetUser(User.Identity.Name.ToLower());
            if (user == null) return;

            //enviar por correo.
            MailBot.MailBot.SendMail(user.Email, null, null, Helper.FromEmailCorreoCamara, "IDS",
                Helper.MailServer, 1, parametros);
        }
        private void SendMailFactura()
        {
            var entities = new OFV.CamaraWebsiteEntities();
            var dbComun = new CamaraComunEntities();
            var factura = entities.Facturas.FirstOrDefault(a => a.FacturaId == this.FacturaId &&
                                                                a.Transacciones.UserName == User.Identity.Name.ToLower());

            if (factura == null) return;


            var capAutorizado = factura.Transacciones.CapitalSocial.HasValue
                                       ? factura.Transacciones.CapitalSocial.Value.ToString("N")
                                       : 0M.ToString("N");

            var modificacionCap = factura.Transacciones.ModificacionCapital.HasValue
                                       ? factura.Transacciones.ModificacionCapital.Value.ToString("N")
                                       : 0M.ToString("N");

            var parametros = new Dictionary<string, string>();
            if (factura.Transacciones.NumeroRegistro.HasValue)
            {
                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(factura.Transacciones.CamaraId);

                var registro = dbSrm.SociedadesRegistros
                    .FirstOrDefault(a => a.NumeroRegistro == factura.Transacciones.NumeroRegistro);

                //Inicializo variables.
                parametros.Add("[NoRegistro]", registro.NumeroRegistro.ToString());
                parametros.Add("[Caja]", String.Empty);
            }
            else
            {
                var registro = entities.Registros.FirstOrDefault(a => a.RegistroId == factura.Transacciones.RegistroId);

                //Inicializando variables.
                parametros.Add("[NoRegistro]",
                               registro.RegistroMercantil.HasValue && registro.RegistroMercantil > 0
                                   ? registro.RegistroMercantil.Value.ToString()
                                   : String.Empty);
                parametros.Add("[Caja]", String.Empty);


            }
            CultureInfo info = new CultureInfo("es-DO");
            parametros.Add("[Cliente]", factura.Transacciones.Solicitante);
            parametros.Add("[RNC/Cedula]", factura.Transacciones.RNCSolicitante);
            parametros.Add("[RegistroSolicitado]", factura.Transacciones.NombreSocialPersona);

            var nombreProducto = dbComun.Servicio.FirstOrDefault(a => a.ServicioId == factura.Transacciones.ServicioId).Descripcion;
            var nombreTipoSociedad = dbComun.TipoSociedad.
                                     FirstOrDefault(a => a.TipoSociedadId == factura.Transacciones.TipoSociedadId).Descripcion;

            if (nombreProducto != null && !String.IsNullOrEmpty(nombreTipoSociedad))
                parametros.Add("[Producto]", info.TextInfo.ToTitleCase(nombreProducto.ToLower()) + " - " + info.TextInfo.ToTitleCase(nombreTipoSociedad.ToLower()));

            parametros.Add("[CapitalAutorizado]", capAutorizado);
            parametros.Add("[CapitalModificado]", modificacionCap);
            parametros.Add("[Tran]", factura.Transacciones.TransaccionId.ToString());
            parametros.Add("[Fecha]", factura.Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            parametros.Add("[NCF]", factura.Ncf);



            //Binding Servicios Solicitados

            var result = factura.TransaccionDetalle.Select(
                a =>
                new
                {
                    TransaccionDetalle = a,
                    TotalDescuento = factura.TransaccionDetalle.Sum(td => td.Descuento),
                    TotalPagar = factura.TransaccionDetalle.Sum(tp => tp.TotalBruto)
                });

            var sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.Append(
                    String.Format(
                        @"<tr><td>{0:N}</td>
                                   <td style=""text-align: right;"">{1}</td>
                                   <td style=""text-align: right;"">{2:N}</td>
                                   <td style=""text-align: right;"">{3:N}</td>
                                   <td style=""text-align: right;"">{4:N}</td>
                                  </tr>",
                       info.TextInfo.ToTitleCase(item.TransaccionDetalle.Detalle.ToLower()),
                        item.TransaccionDetalle.Cantidad, item.TransaccionDetalle.PrecioUnitario,
                        item.TransaccionDetalle.Descuento, item.TransaccionDetalle.TotalBruto));
            }

            parametros.Add("[ServiciosSolicitados]", sb.ToString());

            parametros.Add("[Total]", String.Format("{0:N}", result.Sum(a => a.TransaccionDetalle.TotalBruto)));
            parametros.Add("[Descuento]", String.Format("{0:N}", result.FirstOrDefault().TotalDescuento));
            parametros.Add("[TotalPagar]", String.Format("{0:N}", result.FirstOrDefault().TotalPagar - result.FirstOrDefault().TotalDescuento));

            //buscar el header en base a la camara
            var comunDb = new CamarasController();
            var header = comunDb.FetchByID(factura.CamaraId).FirstOrDefault().HeaderImpresiones;

            //seteaer el header
            parametros.Add("[Header]", header);

            //buscar el usuario
            var user = Membership.GetUser(User.Identity.Name);
            if (user == null) return;

            //enviar por correo.
            MailBot.MailBot.SendMail(user.Email, null, null, Helper.FromEmailCorreoCamara, "IDF",
                Helper.MailServer, 1, parametros);
        }
        #endregion

        #region Formateo de grids
        /// <summary>
        /// Formatea el nombre del socio
        /// </summary>
        /// <param name="socio"></param>
        /// <returns></returns>
        private static string FormatearNombreSocio(SociosDTO socio)
        {
            var sb = new StringBuilder();
            if (socio.RepresentanteId.HasValue)
            {
                var dbWeb = new OFV.CamaraWebsiteEntities();
                //Empresas y menores de edad
                if (socio.TipoSocio == "S")
                    sb.AppendFormat("{0} ", socio.PersonaPrimerNombre.Trim());
                else
                    sb.AppendFormat("{0} {1} ", socio.PersonaPrimerNombre.Trim(), socio.PersonaPrimerApellido.Trim());

                var persona = (from per in dbWeb.Personas
                               where per.PersonaId.Equals(socio.RepresentanteId.Value)
                               select per).FirstOrDefault();

                sb.AppendFormat("(Representado por {0} {1})", persona.PrimerNombre,
                                persona.PrimerApellido);
            }
            else
            {
                //Personas físicas
                if (socio.PersonaPrimerNombre != null)
                    sb.Append(socio.PersonaPrimerNombre + " ");

                if (socio.PersonaSegundoNombre != null)
                    if (socio.PersonaSegundoNombre.Length > 0)
                        sb.Append(socio.PersonaSegundoNombre);

                if (socio.PersonaPrimerApellido != null)
                    sb.Append(socio.PersonaPrimerApellido + " ");

                if (socio.PersonaSegundoApellido != null)
                    if (socio.PersonaSegundoApellido.Length > 0)
                        sb.Append(socio.PersonaSegundoApellido);
            }
            return sb.ToString();
        }

#pragma warning disable CS1573 // Parameter 'sectorId' has no matching param tag in the XML comment for 'ImprimirSolicitud.FormatearDireccion(string, string, int?, int?)' (but other parameters do)
        /// <summary>
        /// Formatea la dirección de un socio
        /// </summary>
        /// <param name="calle"></param>
        /// <param name="numero"></param>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        private string FormatearDireccion(string calle, string numero, int? ciudadId, int? sectorId)
#pragma warning restore CS1573 // Parameter 'sectorId' has no matching param tag in the XML comment for 'ImprimirSolicitud.FormatearDireccion(string, string, int?, int?)' (but other parameters do)
        {
            CamaraComunEntities dbComun = null;
            if (this.SectoresList == null || this.SectoresList.Count == 0)
            {
                dbComun = new CamaraComunEntities();
                this.SectoresList = dbComun.Sectores.ToList();
            }
            if (this.CiudadesList == null || this.CiudadesList.Count == 0)
            {
                if (dbComun == null)
                    dbComun = new CamaraComunEntities();

                this.CiudadesList = dbComun.Ciudades.ToList();
            }

            var sb = new StringBuilder();
            if (calle.Length > 0)
            {
                sb.Append(calle);
                if (numero.Length > 0)
                    sb.Append(" " + numero + ". ");
            }

            if (sectorId.HasValue && sectorId > 0)
            {
                var sector = this.SectoresList.Where(s => s.SectorId == sectorId).FirstOrDefault();
                if (sector != null && !String.IsNullOrEmpty(sector.Nombre))
                    sb.Append(sector.Nombre + ", ");
            }

            if (ciudadId.HasValue && ciudadId > 0)
            {
                var ciudad = this.CiudadesList.Where(c => c.CiudadId == ciudadId).FirstOrDefault();
                if (ciudad != null && !string.IsNullOrEmpty(ciudad.Nombre))
                    sb.Append(ciudad.Nombre);
            }

            return sb.ToString();
        }
        #endregion

        #region Despliegue de Socios
        private static string FormatearCargosSocio(IEnumerable<SociosDTO> socioList,
            IEnumerable<TipoSociedadSocio> tipoSociosList,
            IEnumerable<Cargos> tipoCargoList)
        {
            var sb = new StringBuilder();
            foreach (var socio in socioList)
            {
                var tipoSocio = tipoSociosList.Where(ts => ts.TipoSocioId == socio.TipoRelacion).FirstOrDefault();
                var tipoCargo = tipoCargoList.Where(tc => tc.CargoId == socio.CargoId).FirstOrDefault();

                if (tipoSocio == null) continue;

                var cargo = tipoCargo != null ? tipoCargo.Descripcion : String.Empty;

                if (tipoSocio.TipoSocioId == "C")
                    sb.AppendFormat("{0} - {1}, ", tipoSocio.Descripcion, cargo);
                else
                    sb.Append(tipoSocio.Descripcion + ", ");
            }
            return sb.ToString().Trim().TrimEnd(',');
        }

        #endregion

    }
    //Clase de socios para la parde de imprimir solicitud(no se le pose columna de modificado).
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosGridDTO'
    public class SociosGridDTO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosGridDTO'
    {
        ///<summary>
        /// Nombre formateado del socio
        ///</summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Dirección del socio
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Número de documento
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Cantidad de acciones que el socio posee
        /// </summary>
        public int? Cuotas { get; set; }

        /// <summary>
        /// Cargos ocupados en el consejo de dirección
        /// </summary>
        public string Cargos { get; set; }

        
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/// <summary>
        /// Indica que se modificó un socio a nivel de UI
        /// </summary>
        //public bool Modificado { get; set; }
    }
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
}