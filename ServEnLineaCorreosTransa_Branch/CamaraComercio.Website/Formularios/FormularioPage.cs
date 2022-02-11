using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.Empresas;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CamaraComercio.Website.WSShareBase;
using System.Globalization;
using Direcciones = CamaraComercio.DataAccess.EF.SRM.Direcciones;
using Registros = CamaraComercio.DataAccess.EF.OficinaVirtual.Registros;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage'
    public class FormularioPage : EnvioDatos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.dbWeb'
        public CamaraWebsiteEntities dbWeb = new CamaraWebsiteEntities();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.dbWeb'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.dbCom'
        public Comun.CamaraComunEntities dbCom = new Comun.CamaraComunEntities();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.dbCom'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.FormularioTipoDocumentoId'
        public int FormularioTipoDocumentoId = 1560;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.FormularioTipoDocumentoId'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.RequiereDocs'
        public bool RequiereDocs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.RequiereDocs'
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Request.QueryString["requiereDocs"])
                            ? Request.QueryString["requiereDocs"] == "1"
                            : false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.Formulario'
        public FormularioModelView Formulario { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.Formulario'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.transaccion'
        public OFV.Transacciones transaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.transaccion'
        {
            get
            {
                return dbWeb.Transacciones.First(t => t.TransaccionId == this.IdTransaciones);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.FormularioURL'
        public string FormularioURL { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.FormularioURL'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ConfirmarDatos_Click(object, EventArgs)'
        protected void ConfirmarDatos_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.ConfirmarDatos_Click(object, EventArgs)'
        {
            var doc = new TransaccionesDocumentos
            {
                TransaccionId = transaccion.TransaccionId,
                Usuario = this.User.Identity.Name.ToLower(),
                CantidadCopia = 0,
                CantidadOriginal = 1,
                Deleted = false,
                Descripcion = "FORMULARIO DE SOLICITUD",
                DocContent = ObtenerImagenPdf(),
                DocContentType = "application/pdf",
                DocSeleccionadoId = 0,
                FechaDocumento = DateTime.Now,
                FechaEnvio = DateTime.Now,
                NombreArchivo =
                    string.Format("Formulario Solicitud {0}", IdTransaciones),
                Nombre = string.Format("FormularioSolicitud{0}.pdf", IdTransaciones),
                RowId = Guid.NewGuid(),
                TipoDocumentoId = FormularioTipoDocumentoId
            };
            dbWeb.TransaccionesDocumentos.AddObject(doc);

            var actuales = dbWeb.TransaccionesDocumentos.Where(x => x.TransaccionId == transaccion.TransaccionId && x.TipoDocumentoId == FormularioTipoDocumentoId).ToList();

            // Eliminando los formularios anteriores...
            foreach (var item in actuales)
            {
                dbWeb.DeleteObject(item);
            }

            if (Helper.ShareBaseEnabled)
            {
                foreach (var item in actuales)
                {
                    var client = new WSShareBase.OnlineChamberServiceClient();
                    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                    {
                        var httpRequestProperty = new HttpRequestMessageProperty();
                        httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                        if (item.SBDocumentId == null) continue;
                        var resp = client.DeleteDocumentOnSharebase(long.Parse(item.SBDocumentId));
                        if (!resp.Success)
                        {
                            Master.ShowMessageError("Error al procesar el formulario de solicitud");
                                return;
                        }
                    }

                }
                //var client = new OnlineChamberServiceClient();
                //using (var scope = new OperationContextScope(client.InnerChannel))
                //{
                //    var httpRequestProperty = new HttpRequestMessageProperty();
                //    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                //    // Eliminando los formularios anteriores...
                //    foreach (var item in actuales)
                //    {
                //        if (string.IsNullOrEmpty(item.SBDocumentId)) continue;
                //            client.DeleteDocumentOnSharebase(long.Parse(item.SBDocumentId));
                //    }
                //}
                //if (!val.Success)
                //{
                //    Master.ShowMessageError("Error al procesar el formulario de solicitud");
                //    return;
                //}
                //else
                //{
                //    doc.SBDocumentId = val.Entity;
                //}
            }

            dbWeb.SaveChanges();

            if (RequiereDocs)
                Response.Redirect("~/Empresas/EnvioDatos.aspx" + DefaultQueryString);
            else
                Response.Redirect("~/TarjetaCredito/PagosTarjeta.aspx" + DefaultQueryString);
        }

        private byte[] ObtenerImagenPdf()
        {
            System.IO.StringWriter _writer = new System.IO.StringWriter();
            HttpContext.Current.Server.Execute(FormularioURL, _writer, false);
            string html = _writer.ToString();

            IronPdf.HtmlToPdf renderer = new IronPdf.HtmlToPdf();
            renderer.PrintOptions.CreatePdfFormsFromHtml = false;
            byte[] data = renderer.RenderHtmlAsPdf(html).BinaryData;

            return data;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.CreateFolderOnShareBase(int)'
        public bool CreateFolderOnShareBase(int TransId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.CreateFolderOnShareBase(int)'
        {
            var db = new CamaraWebsiteEntities();
            var trans = db.Transacciones.FirstOrDefault(t => t.TransaccionId == TransId);

            if (Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                BasicOperationResultOfstring resp;
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    resp = client.CreateFolderOnSharebase(trans.TransaccionId.ToString(), Helper.NombreCarpetaShareBase);
                    trans.FolderId = resp.Entity;
                    db.SaveChanges();
                    client.Close();
                }
                return resp.Success;
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SetFormularioModelViewOFV(int, int, int)'
        public bool SetFormularioModelViewOFV(int transaccionIdOFV = 0, int registroIdSRM = 0 , int sociedaIdSRM = 0)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SetFormularioModelViewOFV(int, int, int)'
        {
            if (transaccionIdOFV < 0)
            {
                Master.ShowMessageError("La transacción no existe.");
                return false;
            }

            #region Variables
            Formulario = new FormularioModelView();
            Formulario.Socios = new List<Socio>();
            Formulario.OrganoGestion = new List<OrganoGestion>();
            Formulario.SociosComanditados = new List<SociosComanditados>();
            Formulario.SociosComanditarios = new List<SociosComanditarios>();
            Formulario.SociosFirmas = new List<SociosFirmas>();
            Formulario.ReferenciaComercial = new List<ReferenciaComercial>();
            Formulario.ReferenciaBancaria = new List<ReferenciaBancaria>();
            Formulario.Comisarios = new List<Comisario>();
            var dbContext = new SRM.CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(transaccion.CamaraId));
            string sector;
            // traerer datos de la base de datos en OFV
            var Registro = dbWeb.Registros.
                Include("ReferenciasComerciales").
                Include("ReferenciasBancarias").
                FirstOrDefault(R => R.SrmRegistroId == registroIdSRM && R.TransaccionId == transaccionIdOFV) ?? new Registros ();

            int? ad = Registro.DireccionSectorId;
            if (ad == null)
            {
                sector = "";
            }
            else
            {
                sector = dbCom.Sectores.FirstOrDefault(c => c.SectorId == Registro.DireccionSectorId).Nombre ?? "";
            }

            var Sociedad = dbWeb.Sociedades.FirstOrDefault(R => R.SrmSociedadId == sociedaIdSRM && R.TransaccionId == transaccionIdOFV)?? new OFV.Sociedades();

            var Socios = dbWeb.Socios.Where(R => R.RegistroId == Registro.RegistroId && R.TipoRelacion == "A").ToList() ?? new List<Socios>();

            var OrganoGestion = dbWeb.Socios.Where(a => a.TransaccionId == transaccionIdOFV && a.RegistroId == Registro.RegistroId && a.TipoRelacion == "C").ToList() ?? new List<Socios>();

            var SociosFirmas = dbWeb.Socios.Where(a => a.TransaccionId == transaccionIdOFV && a.RegistroId == Registro.RegistroId && a.TipoRelacion == "F").ToList() ?? new List<Socios>();

            var SociosComanditarios = dbWeb.Socios.Where(a => a.TransaccionId == transaccionIdOFV && a.RegistroId == Registro.RegistroId && a.TipoRelacion == "D").ToList() ?? new List<Socios>();

            var SociosComanditados = dbWeb.Socios.Where(a => a.TransaccionId == transaccionIdOFV && a.RegistroId == Registro.RegistroId && a.TipoRelacion == "B").ToList() ?? new List<Socios>();
            
            var Comisarios = dbWeb.Socios.Where(a => a.TransaccionId == transaccionIdOFV && a.RegistroId == Registro.RegistroId && a.TipoRelacion == "O").ToList() ?? new List<Socios>();

            var ConsejoVijilancia = dbWeb.Socios.Where(a => a.TransaccionId == transaccionIdOFV &&  a.RegistroId == Registro.RegistroId && a.TipoRelacion == "R").ToList() ?? new List<Socios>();

            #endregion
            // mapeo de los datos 
            Formulario.Registro = new Registro
            {
                RegistroId = Registro.RegistroId,
                ActividadCIUU = Registro.ActividadCIUU ?? "N/A",
                ActividadCIUU2 = Registro.ActividadCIUU2 ?? "N/A",
                ActividadIdCIUU = Registro.ActividadIdCIUU ?? "N/A",
                ActividadIdCIUU2 = Registro.ActividadIdCIUU2 ?? "N/A",
                ActividadNegocio = Registro.ActividadNegocio ?? "N/A",
                Activos = Registro.Activos,
                BienesRaices = Registro.BienesRaices,
                CapitalAutorizado = Registro.CapitalAutorizado,
                CapitalPagado = Registro.CapitalPagado,
                CapitalSocial = Registro.CapitalSocial,
                CargoSolicitante = Registro.CargoSolicitante ?? "N/A",
                DireccionApartadoPostal = Registro.DireccionApartadoPostal ?? "",
                DireccionCalle = Registro.DireccionCalle ?? "",
                DireccionCiudad = Registro.DireccionCiudad ?? "",
                DireccionCiudadId = Registro.DireccionCiudadId,
                DireccionEmail = Registro.DireccionEmail ?? "N/A",
                DireccionExtension = Registro.DireccionExtension,
                DireccionFax = Registro.DireccionFax,
                DireccionNumero = Registro.DireccionNumero,
                DireccionSectorId = Registro.DireccionSectorId,
                DireccionSitioWeb = Registro.DireccionSitioWeb ?? "N/A",
                DireccionTelefonoCasa = Registro.DireccionTelefonoCasa ?? "N/A",
                DireccionTelefonoOficina = Registro.DireccionTelefonoOficina ?? "N/A",
                EmpleadosFemeninos = Registro.EmpleadosFemeninos ?? 0,
                EmpleadosMasculinos = Registro.EmpleadosMasculinos ?? 0,
                EmpleadosTotal = Registro.EmpleadosTotal,
                EntidadActiva = Registro.EntidadActiva,
                EsNuevoRegistro = Registro.EsNuevoRegistro,
                EsRenovacion = Registro.EsRenovacion,
                FechaAsamblea1 = Registro.FechaAsamblea1,
                FechaAsamblea2 = Registro.FechaAsamblea2,
                FechaEmision = Registro.FechaEmision,
                FechaInicioOperacion = Registro.FechaInicioOperacion,
                FechaVencimiento = Registro.FechaVencimiento,
                GestorUsername = Registro.GestorUsername.ToLower(),
                Id_Cierre_Fiscal = Registro.Id_Cierre_Fiscal,
                MarcaFabrica = Registro.MarcaFabrica ?? "N/A",
                NombreComercial = Registro.NombreComercial ?? "N/A",
                NombreOperador = Registro.NombreOperador ?? "N/A",
                NombreSolicitante = Registro.NombreSolicitante ?? "N/A",
                NumeroSocios = Registro.NumeroSocios,
                PatenteInvencion = Registro.PatenteInvencion ?? "N/A",
                RegistroMarcaFabrica = Registro.RegistroMarcaFabrica ?? "N/A",
                RegistroMercantil = Registro.RegistroMercantil,
                RegistroNombreComercial = Registro.RegistroNombreComercial ?? "N/A",
                RegistroPatenteInvencion = Registro.RegistroPatenteInvencion ?? "N/A",
                SrmRegistroId = Registro.SrmRegistroId,
                TipoMonedaActivos = Registro.TipoMonedaActivos,
                TipoMonedaBienesRaices = Registro.TipoMonedaBienesRaices,
                TipoMonedaCapitalAutorizado = Registro.TipoMonedaCapitalAutorizado,
                TipoMonedaCapitalPagado = Registro.TipoMonedaCapitalPagado,
                TipoMonedaCapitalSocial = Registro.TipoMonedaCapitalSocial,
                TotalAcciones = Registro.TotalAcciones,
                TransaccionId = Registro.TransaccionId,
                DireccionSector = sector
            };
            Formulario.Sociedad = new Sociedad
            {
                RegistroId = Sociedad.RegistroId,
                AccionesNominales = Sociedad.AccionesNominales,
                AccionesNoNominales = Sociedad.AccionesNoNominales,
                DuraccionDirectiva = Sociedad.DuraccionDirectiva,
                DuracionSociedad = Sociedad.DuracionSociedad ?? "N/A",
                EsEnteRegulado = Sociedad.EsEnteRegulado,
                EsNacional = Sociedad.EsNacional,
                EstatusId = Sociedad.EstatusId,
                FechaAsamblea = Sociedad.FechaAsamblea,
                FechaConstitucion = Sociedad.FechaConstitucion,
                FechaEnteRegulado = Sociedad.FechaEnteRegulado,
                NacionalidadId = Sociedad.NacionalidadId,
                NombreSiglas = Sociedad.NombreSiglas ?? "N/A",
                NombreSocial = Sociedad.NombreSocial ?? "N/A",
                NoResolucion = Sociedad.NoResolucion ?? "N/A",
                NumeroNaveIndustrial = Sociedad.NumeroNaveIndustrial ?? "N/A",
                Rnc = Sociedad.Rnc,
                SiglasConfig = Sociedad.SiglasConfig ?? "N/A",
                SociedadId = Sociedad.SociedadId,
                SrmSociedadId = Sociedad.SrmSociedadId,
                TipoEnteReguladoId = Sociedad.TipoEnteReguladoId,
                TipoSociedadId = Sociedad.TipoSociedadId,
                TransaccionId = Sociedad.TransaccionId
            };
            if (Socios.Count() > 0)
            {
                foreach (var elSocio in Socios)
                {
                    string cargo = "";
                    string nacionalidad = "";
                    string EstasdoS = elSocio.PersonaEstadoCivil ?? "";
                    if (elSocio.CargoId != null)
                    {
                        cargo = dbCom.Cargos.FirstOrDefault(c => c.CargoId == elSocio.CargoId).Descripcion;
                    }
                    if (elSocio.NacionalidadId != null && elSocio.NacionalidadId !=0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == elSocio.NacionalidadId).Nombre;
                    }
                    if (EstasdoS.ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    var NumeroRM = dbContext.ViewRegistrosSocios.FirstOrDefault(vr => vr.SocioId == elSocio.SrmSocioId).NumeroRM;
                    var socio = new Socio
                    {
                        RegistroId = elSocio.RegistroId,
                        NumeroRM = NumeroRM,
                        CantidadAcciones = elSocio.CantidadAcciones,
                        CargoId = elSocio.CargoId,
                        CorreoElectronico = elSocio.CorreoElectronico ?? "N/A",
                        DireccionApartadoPostal = elSocio.DireccionApartadoPostal ?? "",
                        DireccionCalle = elSocio.DireccionCalle ?? "",
                        DireccionCiudadId = elSocio.DireccionCiudadId,
                        DireccionNumero = elSocio.DireccionNumero ?? "",
                        DireccionSectorId = elSocio.DireccionSectorId,
                        Documento = elSocio.Documento ?? "N/A",
                        FechaNacimiento = elSocio.FechaNacimiento,
                        Id = elSocio.Id,
                        IdentificacionTributariaPais = elSocio.IdentificacionTributariaPais ?? "",
                        NacionalidadId = elSocio.NacionalidadId,
                        Nacionalidad = nacionalidad,
                        Orden = elSocio.Orden,
                        PersonaEstadoCivil = EstasdoS,
                        PersonaPrimerApellido = elSocio.PersonaPrimerApellido,
                        PersonaPrimerNombre = elSocio.PersonaPrimerNombre,
                        PersonaProfesionId = elSocio.PersonaProfesionId,
                        PersonaSegundoApellido = elSocio.PersonaSegundoApellido,
                        PersonaSegundoNombre = elSocio.PersonaSegundoNombre,
                        RegistroMercantil = elSocio.RegistroMercantil ?? "N/A",
                        RepresentanteId = elSocio.RepresentanteId,
                        SociedadNombreSocial = elSocio.SociedadNombreSocial ?? "N/A",
                        SrmId = elSocio.SrmId,
                        SrmSocioId = elSocio.SrmSocioId,
                        Telefono1 = elSocio.Telefono1 ?? "N/A",
                        Telefono2 = elSocio.Telefono2 ?? "N/A",
                        TipoBeneficiario = elSocio.TipoBeneficiario ?? "N/A",
                        TipoDatosSocio = elSocio.TipoDatosSocio ?? "N/A",
                        TipoDocumento = elSocio.TipoDocumento ?? "N/A",
                        TipoRelacion = elSocio.TipoRelacion ?? "N/A",
                        TipoSocio = elSocio.TipoSocio,
                        Cargo = cargo ?? "N/A",
                        TransaccionId = elSocio.TransaccionId
                    };
                    if (string.IsNullOrWhiteSpace(socio.DireccionNombreCiudad))
                    {
                        if (socio.DireccionCiudadId != null)
                        {
                            socio.DireccionNombreCiudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == socio.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            socio.DireccionNombreCiudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(socio.DireccionNombreSector))
                    {
                        if (socio.DireccionSectorId != null)
                        {
                            socio.DireccionNombreSector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == socio.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            socio.DireccionNombreSector = "";
                        }
                    }
                    if (!Formulario.Socios.Any(c => c.SrmSocioId == socio.SrmSocioId))
                        Formulario.Socios.Add(socio);

                }
            }
            if (OrganoGestion.ToList().Count > 0)
            {
                foreach (var organoData in OrganoGestion)
                {
                    string cargo = "N/A";
                    string nacionalidad = "N/A";
                    if (organoData.CargoId != null)
                    {
                        cargo = dbCom.Cargos.FirstOrDefault(c => c.CargoId == organoData.CargoId).Descripcion;
                    }
                    if (organoData.NacionalidadId != null && organoData.NacionalidadId != 0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == organoData.NacionalidadId).Nombre;
                    }
                    string EstasdoS = organoData.PersonaEstadoCivil ?? "N/A";
                    if (EstasdoS.Substring(0, 1).ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.Substring(0, 1).ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    OrganoGestion Organo = new OrganoGestion
                    {
                        Accionista = organoData.PersonaPrimerNombre + " " +
                                     organoData.PersonaSegundoNombre + " " +
                                     organoData.PersonaPrimerApellido + " " +
                                     organoData.PersonaSegundoApellido,
                        Documento = organoData.Documento ?? "N/A",
                        Calle = organoData.DireccionCalle ?? "",
                        Cargo = cargo ?? "N/A",
                        Ciudad = organoData.DireccionNombreCiudad,
                        EstadoCivil = EstasdoS,
                        Nacionalidad = nacionalidad ?? "",
                        Sector = organoData.DireccionNombreSector
                    };
                    if (string.IsNullOrWhiteSpace(Organo.Ciudad))
                    {
                        if (organoData.DireccionCiudadId != null)
                        {
                            Organo.Ciudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == organoData.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            Organo.Ciudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(Organo.Sector))
                    {
                        if (organoData.DireccionSectorId != null)
                        {
                            Organo.Sector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == organoData.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            Organo.Sector = "";
                        }
                    }
                    if (!Formulario.OrganoGestion.Any(c => c.Documento == Organo.Documento))
                        Formulario.OrganoGestion.Add(Organo);

                }
            }
            if (SociosFirmas.ToList().Count > 0)
            {
                foreach (var FirmasData in SociosFirmas)
                {
                    string cargo = "N/A";
                    string nacionalidad = "N/A";
                    if (FirmasData.CargoId != null)
                    {
                        cargo = !string.IsNullOrWhiteSpace(dbCom.Cargos.FirstOrDefault(c => c.CargoId == FirmasData.CargoId).Descripcion) ?
                            dbCom.Cargos.FirstOrDefault(c => c.CargoId == FirmasData.CargoId).Descripcion : "N/A";
                    }
                    if (FirmasData.NacionalidadId != null && FirmasData.NacionalidadId != 0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == FirmasData.NacionalidadId).Nombre;
                    }
                    string EstasdoS = FirmasData.PersonaEstadoCivil ?? "N/A";
                    if (EstasdoS.ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    SociosFirmas Firmas = new SociosFirmas
                    {
                        Accionista = FirmasData.PersonaPrimerNombre + " " +
                                     FirmasData.PersonaSegundoNombre + " " +
                                     FirmasData.PersonaPrimerApellido + " " +
                                     FirmasData.PersonaSegundoApellido,
                        Documento = FirmasData.Documento ?? "N/A",
                        Calle = FirmasData.DireccionCalle ?? "",
                        Cargo = cargo,
                        Ciudad = FirmasData.DireccionNombreCiudad,
                        EstadoCivil = EstasdoS,
                        Nacionalidad = nacionalidad,
                        Sector = FirmasData.DireccionNombreSector
                    };
                    if (string.IsNullOrWhiteSpace(Firmas.Ciudad))
                    {
                        if (FirmasData.DireccionCiudadId != null)
                        {
                            Firmas.Ciudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == FirmasData.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            Firmas.Ciudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(Firmas.Sector))
                    {
                        if (FirmasData.DireccionSectorId != null)
                        {
                            Firmas.Sector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == FirmasData.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            Firmas.Sector = "";
                        }
                    }
                    if (!Formulario.SociosFirmas.Any(c => c.Documento == Firmas.Documento))
                        Formulario.SociosFirmas.Add(Firmas);

                }
            }
            if (SociosComanditarios.ToList().Count > 0)
            {
                foreach (var ComanditariosData in SociosComanditarios)
                {
                    string cargo = "N/A";
                    string nacionalidad = "N/A";
                    if (ComanditariosData.CargoId != null)
                    {
                        cargo = dbCom.Cargos.FirstOrDefault(c => c.CargoId == ComanditariosData.CargoId).Descripcion;
                    }
                    if (ComanditariosData.NacionalidadId != null && ComanditariosData.NacionalidadId != 0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == ComanditariosData.NacionalidadId).Nombre;
                    }
                    string EstasdoS = ComanditariosData.PersonaEstadoCivil ?? "N/A";
                    if (EstasdoS.ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    SociosComanditarios Comanditarios = new SociosComanditarios
                    {
                        Accionista = ComanditariosData.PersonaPrimerNombre + " " +
                                     ComanditariosData.PersonaSegundoNombre + " " +
                                     ComanditariosData.PersonaPrimerApellido + " " +
                                     ComanditariosData.PersonaSegundoApellido,
                        Documento = ComanditariosData.Documento ?? "N/A",
                        Calle = ComanditariosData.DireccionCalle ?? "",
                        Ciudad = ComanditariosData.DireccionNombreCiudad,
                        EstadoCivil = EstasdoS,
                        Nacionalidad = nacionalidad,
                        Sector = ComanditariosData.DireccionNombreSector,
                        CantidaCuotasAcciones = ComanditariosData.CantidadAcciones ?? 0

                    };
                    if (string.IsNullOrWhiteSpace(Comanditarios.Ciudad))
                    {
                        if (ComanditariosData.DireccionCiudadId != null)
                        {
                            Comanditarios.Ciudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == ComanditariosData.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            Comanditarios.Ciudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(Comanditarios.Sector))
                    {
                        if (ComanditariosData.DireccionSectorId != null)
                        {
                            Comanditarios.Sector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == ComanditariosData.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            Comanditarios.Sector = "";
                        }
                    }
                    if (!Formulario.SociosComanditarios.Any(c => c.Documento == Comanditarios.Documento))
                        Formulario.SociosComanditarios.Add(Comanditarios);

                }
            }
            if (SociosComanditados.ToList().Count > 0)
            {
                foreach (var ComanditadosData in SociosComanditados)
                {
                    string cargo = "N/A";
                    string nacionalidad = "N/A";
                    if (ComanditadosData.CargoId != null)
                    {
                        cargo = dbCom.Cargos.FirstOrDefault(c => c.CargoId == ComanditadosData.CargoId).Descripcion;
                    }
                    if (ComanditadosData.NacionalidadId != null && ComanditadosData.NacionalidadId != 0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == ComanditadosData.NacionalidadId).Nombre;
                    }
                    string EstasdoS = ComanditadosData.PersonaEstadoCivil ?? "N/A";
                    if (EstasdoS.ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    SociosComanditados Comanditados = new SociosComanditados
                    {
                        Accionista = ComanditadosData.PersonaPrimerNombre + " " +
                                     ComanditadosData.PersonaSegundoNombre + " " +
                                     ComanditadosData.PersonaPrimerApellido + " " +
                                     ComanditadosData.PersonaSegundoApellido,
                        Documento = ComanditadosData.Documento ?? "N/A",
                        Calle = ComanditadosData.DireccionCalle ?? "",
                        Ciudad = ComanditadosData.DireccionNombreCiudad,
                        EstadoCivil = EstasdoS,
                        Nacionalidad = nacionalidad,
                        Sector = ComanditadosData.DireccionNombreSector,
                        CantidaCuotasAcciones = ComanditadosData.CantidadAcciones ?? 0
                    };
                    if (string.IsNullOrWhiteSpace(Comanditados.Ciudad))
                    {
                        if (ComanditadosData.DireccionCiudadId != null)
                        {
                            Comanditados.Ciudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == ComanditadosData.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            Comanditados.Ciudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(Comanditados.Sector))
                    {
                        if (ComanditadosData.DireccionSectorId != null)
                        {
                            Comanditados.Sector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == ComanditadosData.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            Comanditados.Sector = "";
                        }
                    }
                    if (!Formulario.SociosComanditados.Any(c => c.Documento == Comanditados.Documento))
                        Formulario.SociosComanditados.Add(Comanditados);

                }
            }
            if (Registro.ReferenciasComerciales.Count() > 0)
            {
                foreach (var laReferencia in Registro.ReferenciasComerciales)
                {
                    ReferenciaComercial referencias = new ReferenciaComercial
                    {
                        Descripcion = laReferencia.Descripcion ?? "N/A",
                        FechaModificacion = laReferencia.FechaModificacion,
                        RegistroId = laReferencia.RegistroId,
                        ReferenciaComercialId = laReferencia.ReferenciaComercialId,
                        TransaccionId = laReferencia.TransaccionId,
                        TipoReferencia = laReferencia.TipoReferencia
                    };
                    Formulario.ReferenciaComercial.Add(referencias);
                }
            }
            if (Registro.ReferenciasBancarias.Count() > 0)
            {
                foreach (var laReferencia in Registro.ReferenciasBancarias)
                {
                    ReferenciaBancaria referencias = new ReferenciaBancaria
                    {
                        TransaccionId = laReferencia.TransaccionId,
                        BancoId = laReferencia.BancoId,
                        NombreBanco = laReferencia.NombreBanco ?? String.Empty,
                        FechaModificacion = laReferencia.FechaModificacion,
                        ReferenciaBancariaId = laReferencia.ReferenciaBancariaId,
                        RegistroId = laReferencia.RegistroId
                    };
                    if (String.IsNullOrWhiteSpace(referencias.NombreBanco))
                        referencias.NombreBanco = dbCom.Bancos.FirstOrDefault(a => a.BancoId == referencias.BancoId).Descripcion ?? "N/A";
                    Formulario.ReferenciaBancaria.Add(referencias);
                }
            }
            if (Comisarios.Count() > 0)
            {
                foreach (var elComisario in Comisarios)
                {
                    string nacionalidad = "N/A";
                    if (elComisario.NacionalidadId != null && elComisario.NacionalidadId != 0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == elComisario.NacionalidadId).Nombre;
                    }
                    string EstasdoS = elComisario.PersonaEstadoCivil ?? "N/A";
                    if (EstasdoS.ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    Comisario Comisario = new Comisario
                    {
                        Accionista = elComisario.PersonaPrimerNombre + " " +
                                     elComisario.PersonaSegundoNombre + " " +
                                     elComisario.PersonaPrimerApellido + " " +
                                     elComisario.PersonaSegundoApellido,
                        Documento = elComisario.Documento ?? "",
                        Calle = elComisario.DireccionCalle ?? "",
                        Ciudad = elComisario.DireccionNombreCiudad,
                        EstadoCivil = EstasdoS,
                        Nacionalidad = nacionalidad,
                        Sector = elComisario.DireccionNombreSector,
                    };
                    if (string.IsNullOrWhiteSpace(Comisario.Ciudad))
                    {
                        if (elComisario.DireccionCiudadId != null)
                        {
                            Comisario.Ciudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == elComisario.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            Comisario.Ciudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(Comisario.Sector))
                    {
                        if (elComisario.DireccionSectorId != null)
                        {
                            Comisario.Sector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == elComisario.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            Comisario.Sector = "";
                        }
                    }
                    if (!Formulario.Comisarios.Any(c => c.Documento == Comisario.Documento))
                        Formulario.Comisarios.Add(Comisario);
                }
            }
            if (ConsejoVijilancia.Count() > 0)
            {
                foreach (var elConsejal in ConsejoVijilancia)
                {
                    string nacionalidad = "N/A";
                    if (elConsejal.NacionalidadId != null && elConsejal.NacionalidadId != 0)
                    {
                        nacionalidad = dbCom.Paises.FirstOrDefault(c => c.PaisId == elConsejal.NacionalidadId).Nombre;
                    }
                    string EstasdoS = elConsejal.PersonaEstadoCivil ?? "N/A";
                    if (EstasdoS.ToLower() == "c")
                    {
                        EstasdoS = "Casado(a)";
                    }
                    else if (EstasdoS.ToLower() == "s")
                    {
                        EstasdoS = "Soltero(a)";
                    }
                    Comisario Consejal = new Comisario
                    {
                        Accionista = elConsejal.PersonaPrimerNombre + " " +
                                     elConsejal.PersonaSegundoNombre + " " +
                                     elConsejal.PersonaPrimerApellido + " " +
                                     elConsejal.PersonaSegundoApellido,
                        Documento = elConsejal.Documento ?? "",
                        Calle = elConsejal.DireccionCalle ?? "",
                        Ciudad = elConsejal.DireccionNombreCiudad,
                        EstadoCivil = EstasdoS,
                        Nacionalidad = nacionalidad,
                        Sector = elConsejal.DireccionNombreSector,
                    };
                    if (string.IsNullOrWhiteSpace(Consejal.Ciudad))
                    {
                        if (elConsejal.DireccionCiudadId != null)
                        {
                            Consejal.Ciudad = dbCom.Ciudades.FirstOrDefault(x => x.CiudadId == elConsejal.DireccionCiudadId).Nombre;
                        }
                        else
                        {
                            Consejal.Ciudad = "";
                        }
                    }
                    if (string.IsNullOrWhiteSpace(Consejal.Sector))
                    {
                        if (elConsejal.DireccionSectorId != null)
                        {
                            Consejal.Sector = dbCom.Sectores.FirstOrDefault(x => x.SectorId == elConsejal.DireccionSectorId).Nombre;
                        }
                        else
                        {
                            Consejal.Sector = "";
                        }
                    }
                    if (!Formulario.Comisarios.Any(c => c.Documento == Consejal.Documento))
                        Formulario.Comisarios.Add(Consejal);
                }
            }

            return true;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SetFormularioModelViewSRM(int, int, int)'
        public bool SetFormularioModelViewSRM(int transaccionIdOFV = 0, int registroIdSRM = 0, int sociedaIdSRM = 0)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioPage.SetFormularioModelViewSRM(int, int, int)'
        {
            if (transaccionIdOFV < 0)
            {
                Master.ShowMessageError("La transacción no existe.");
                return false;
            }
            #region Variables
            Formulario = new FormularioModelView();
            Formulario.Socios = new List<Socio>();
            Formulario.OrganoGestion = new List<OrganoGestion>();
            Formulario.SociosComanditados = new List<SociosComanditados>();
            Formulario.SociosComanditarios = new List<SociosComanditarios>();
            Formulario.SociosFirmas = new List<SociosFirmas>();
            Formulario.ReferenciaComercial = new List<ReferenciaComercial>();
            Formulario.ReferenciaBancaria = new List<ReferenciaBancaria>();
            Formulario.Comisarios = new List<Comisario>();

            //conecta y traerer datos de la base de datos en OFV
            var transaccion = dbWeb.Transacciones.First(c => c.TransaccionId == transaccionIdOFV);
            //conecta y traerer datos de la base de datos en SRM
            var dbContext = new SRM.CamaraSRMEntities(DataAccess.EF.Helpers.GetCamaraConnString(transaccion.CamaraId));

            var registro = dbContext.Registros.FirstOrDefault(d => d.RegistroId == registroIdSRM) ?? new SRM.Registros();

            var sociedad = dbContext.Sociedades.FirstOrDefault(d => d.SociedadId == sociedaIdSRM) ?? new SRM.Sociedades();

            var registroM = dbContext.SociedadesRegistros.FirstOrDefault(x => x.RegistroId == registro.RegistroId) ?? new SRM.SociedadesRegistros();

            var direccion = dbContext.Direcciones.FirstOrDefault(d => d.DireccionId == sociedad.DireccionId) ?? new Direcciones ();

            var registroSocios = (from socio in dbContext.ViewRegistrosSocios
                                  join persona in dbContext.Personas on socio.SocioId equals persona.PersonaId
                                  where socio.RegistroId == registroIdSRM
                                  select new { Socio = socio, Persona = persona});

            var aa = dbContext.ViewRegistrosSocios.Where(c => c.RegistroId == registroIdSRM).ToList() ?? new List<SRM.ViewRegistrosSocios>();
            var cc = new List<SRM.Sociedades>();
            foreach (var item in aa)
            {
                var b = dbContext.Sociedades.FirstOrDefault(c => c.SociedadId == item.SocioId) ?? new SRM.Sociedades();
                cc.Add(b);

            }
            var registroSociedades = new { Socio = aa, Sociedad = cc };
            var sucursales = dbContext.Suscursales.Where(S => S.SociedadId == sociedaIdSRM).ToList() ?? new List<SRM.Suscursales>();

            var referenciasComerciales = dbContext.ReferenciasComerciales.Where(a => a.RegistroId == registroIdSRM).ToList() ?? new List<SRM.ReferenciasComerciales>();

            var referenciasBancarias = dbContext.ReferenciasBancarias.Where(a => a.RegistroId == registroIdSRM);
            string sector = "";
            if (registro.Direcciones.SectorId != null)
            {
                sector = dbCom.Sectores.FirstOrDefault(c => c.SectorId == registro.Direcciones.SectorId).Nombre ?? "";
            }
            var OrganoGestion = dbContext.ViewRegistrosSocios.Where(a => a.RegistroId == registroIdSRM && a.TipoRelacion == "C").ToList() ?? new List<SRM.ViewRegistrosSocios>();

            var SociosFirmas = dbContext.ViewRegistrosSocios.Where(a => a.RegistroId == registroIdSRM && a.TipoRelacion == "F").ToList() ?? new List<SRM.ViewRegistrosSocios>();

            var SociosComanditarios = dbContext.ViewRegistrosSocios.Where(a => a.RegistroId == registroIdSRM && a.TipoRelacion == "D").ToList() ?? new List<SRM.ViewRegistrosSocios>();

            var SociosComanditados = dbContext.ViewRegistrosSocios.Where(a => a.RegistroId == registroIdSRM && a.TipoRelacion == "B").ToList() ?? new List<SRM.ViewRegistrosSocios>();

            var Comisarios = dbContext.ViewRegistrosSocios.Where(a => a.RegistroId == registroIdSRM && a.TipoRelacion == "B").ToList() ?? new List<SRM.ViewRegistrosSocios>();

            var ConsejoVijilancia = dbContext.ViewRegistrosSocios.Where(a => a.RegistroId == registroIdSRM && a.TipoRelacion == "R").ToList() ?? new List<SRM.ViewRegistrosSocios>();
            #endregion
            // mapeo de los datos 
            Formulario.Registro = new Registro
            {
                SrmRegistroId = registro.RegistroId,
                TransaccionId = transaccion.TransaccionId,
                RegistroMercantil = registroM.NumeroRegistro,
                FechaEmision = registro.FechaEmision,
                FechaVencimiento = registro.FechaVencimiento,
                CapitalSocial = registro.CapitalSocial,
                CapitalAutorizado = registro.CapitalAutorizado,
                CapitalPagado = registro.CapitalPagado,
                Activos = registro.Activos,
                BienesRaices = registro.BienesRaices,
                FechaInicioOperacion = registro.FechaInicioOperacion,
                NombreComercial = registro.NombreComercial,
                RegistroNombreComercial = registro.RegistroNombreComercial,
                MarcaFabrica = registro.MarcaFabrica ?? "N/A",
                RegistroMarcaFabrica = registro.RegistroMarcaFabrica ?? "N/A",
                PatenteInvencion = registro.PatenteInversion ?? "N/A",
                RegistroPatenteInvencion = registro.RegistroPatenteInversion ?? "N/A",
                NombreOperador = registro.NombreOperador ?? "N/A",
                ActividadNegocio = registro.ActividadNegocio ?? "N/A",
                NumeroSocios = registro.NumeroSocios,
                TotalAcciones = registro.TotalAcciones,
                EsNuevoRegistro = registro.EsNuevoRegistro,
                DireccionCalle = registro.Direcciones.Calle ?? "",
                DireccionNumero = registro.Direcciones.Numero ?? "",
                DireccionCiudadId = registro.Direcciones.CiudadId ,
                DireccionCiudad = registro.Direcciones.CiudadDescripcion ?? "",
                DireccionSectorId = registro.Direcciones.SectorId,
                NombreSolicitante = registro.NombreSolicitante,
                CargoSolicitante = registro.CargoSolicitante ?? "N/A",
                GestorUsername = registro.NombreOperador ?? "N/A",
                EntidadActiva = registro.EntidadActiva,
                EsRenovacion = registro.EsRenovacion,
                TipoMonedaCapitalSocial = registro.TipoMonedaCapitalSocial,
                TipoMonedaCapitalAutorizado = registro.TipoMonedaCapitalAutorizado,
                TipoMonedaCapitalPagado = registro.TipoMonedaCapitalPagado,
                TipoMonedaActivos = registro.TipoMonedaActivos,
                TipoMonedaBienesRaices = registro.TipoMonedaBienesRaices,
                ActividadIdCIUU = registro.ActividadIdCIUU ?? "N/A",
                ActividadCIUU = registro.ActividadCIUU ?? "N/A",
                ActividadIdCIUU2 = registro.ActividadIdCIUU2 ?? "N/A",
                ActividadCIUU2 = registro.ActividadCIUU2 ?? "N/A",
                Id_Cierre_Fiscal = registro.Id_Cierre_Fiscal,
                FechaAsamblea1 = registro.FechaAsamblea1,
                FechaAsamblea2 = registro.FechaAsamblea2,
                EmpleadosMasculinos = registro.EmpleadosMasculinos,
                EmpleadosFemeninos = registro.EmpleadosFemeninos,
                DireccionSitioWeb = registro.Direcciones.SitioWeb ?? "N/A",
                DireccionEmail = registro.Direcciones.Email ?? "N/A",
                DireccionTelefonoCasa = registro.Direcciones.TelefonoCasa ?? "N/A",
                DireccionTelefonoOficina = registro.Direcciones.TelefonoOficina ?? "N/A",
                DireccionFax = registro.Direcciones.Fax ?? "N/A",
                DireccionApartadoPostal = direccion?.ApartadoPostal ?? "No Se Encontró Registro.",
                EmpleadosTotal = registro.EmpleadosTotal,
                DireccionExtension = direccion?.Extension ?? 0,
                RegistroId = registro.RegistroId,
                DireccionSector = sector
            };
            Formulario.Sociedad = new Sociedad
            {
                SrmSociedadId = sociedad.SociedadId,
                TransaccionId = transaccion.TransaccionId,
                RegistroId = registro.RegistroId,
                TipoSociedadId = sociedad.TipoSociedadId,
                NombreSocial = sociedad.NombreSocial ?? "N/A",
                Rnc = sociedad.Rnc,
                EsNacional = sociedad.EsNacional,
                NacionalidadId = sociedad.NacionalidadId,
                FechaConstitucion = sociedad.FechaConstitucion,
                DuracionSociedad = sociedad.DuracionSociedad,
                FechaAsamblea = sociedad.FechaAsamblea,
                DuraccionDirectiva = sociedad.DuraccionDirectiva,
                EstatusId = sociedad.EstatusId,
                EsEnteRegulado = sociedad.EsEnteRegulado,
                TipoEnteReguladoId = sociedad.TipoEnteReguladoId,
                NoResolucion = sociedad.NoResolucion ?? "N/A",
                NumeroNaveIndustrial = sociedad.NumeroNaveIndustrial,
                NombreSiglas = sociedad.NombreSiglas ?? "N/A",
                SiglasConfig = sociedad.SiglasConfig ?? "N/A",
                AccionesNominales = sociedad.AccionesNominales,
                AccionesNoNominales = sociedad.AccionesNoNominales,
                FechaEnteRegulado = sociedad.FechaEnteRegulado,
                SociedadId = sociedad.SociedadId,
            };
            if (registroSocios.Count() > 0)
            {
                foreach (var socioData in registroSocios)
                {
                    Socio Socio = new Socio
                    {
                        RegistroId = transaccion.RegistroId,
                        TransaccionId = transaccion.TransaccionId,
                        SrmId = socioData.Socio.ID,
                        SrmSocioId = socioData.Socio.SocioId,
                        PersonaPrimerNombre = socioData.Persona.PrimerNombre,
                        PersonaSegundoNombre = socioData.Persona.SegundoNombre,
                        PersonaPrimerApellido = socioData.Persona.PrimerApellido,
                        PersonaSegundoApellido = socioData.Persona.SegundoApellido,
                        DireccionCiudadId = socioData.Socio.CiudadId,
                        DireccionNombreCiudad = socioData.Socio.Ciudad ?? "",
                        DireccionSectorId = socioData.Socio.SectorId,
                        DireccionNombreSector = socioData.Socio.Sector ?? "",
                        DireccionCalle = socioData.Socio.Calle ?? "",
                        DireccionNumero = socioData.Socio.Numero ?? "",
                        DireccionApartadoPostal = socioData.Socio.ApartadoPostal ?? "",
                        NacionalidadId = socioData.Socio.PaisId,
                        IdentificacionTributariaPais = socioData.Socio.Pais ?? "",
                        TipoSocio = socioData.Socio.TipoSocio,
                        TipoRelacion = socioData.Socio.TipoRelacion,
                        Documento = socioData.Socio.Documento?.RemoverFormato(),
                        TipoDocumento = socioData.Persona.TipoDocumento,
                        PersonaEstadoCivil = socioData.Socio.EstadoCivil.ToLower().Equals("soltero(a)") ? "S" : "C",
                        Cargo = socioData.Socio.Cargo ?? "N/A",
                        Nacionalidad = socioData.Socio.Nacionalidad ?? "N/A",
                        CantidadAcciones = Convert.ToInt32(socioData.Socio.CantidaCuotasAcciones)

                    };
                    if (!Formulario.Socios.Any(c => c.SrmSocioId == Socio.SrmSocioId))
                        Formulario.Socios.Add(Socio);
                }
            }
            if (OrganoGestion.ToList().Count > 0)
            {
                foreach (var organoData in OrganoGestion)
                {
                    OrganoGestion Organo = new OrganoGestion
                    {
                        Accionista = organoData.Accionista ?? "N/A",
                        Documento = organoData.Documento ?? "N/A",
                        Calle = organoData.Calle ?? "",
                        Cargo = organoData.Cargo ?? "",
                        Ciudad = organoData.Ciudad ?? "",
                        EstadoCivil = organoData.EstadoCivil.Substring(0,1).ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)",
                        Nacionalidad = organoData.Nacionalidad ?? "N/A",
                        Sector = organoData.Sector ?? ""
                    };
                    if (!Formulario.OrganoGestion.Any(c => c.Documento == Organo.Documento))
                        Formulario.OrganoGestion.Add(Organo);

                }
            }
            if (SociosFirmas.ToList().Count > 0)
            {
                foreach (var FirmasData in SociosFirmas)
                {
                    SociosFirmas Firmas = new SociosFirmas
                    {
                        Accionista = FirmasData.Accionista ?? "N/A",
                        Documento = FirmasData.Documento ?? "N/A",
                        Calle = FirmasData.Calle ?? "N/A",
                        Cargo = FirmasData.Cargo ?? "N/A",
                        Ciudad = FirmasData.Ciudad ?? "N/A",
                        EstadoCivil = FirmasData.EstadoCivil.Substring(0, 1).ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)",
                        Nacionalidad = FirmasData.Nacionalidad ?? "N/A",
                        Sector = FirmasData.Sector ?? "N/A"
                    };
                    if (!Formulario.SociosFirmas.Any(c => c.Documento == Firmas.Documento))
                        Formulario.SociosFirmas.Add(Firmas);

                }
            }
            if (SociosComanditarios.Count() > 0)
            {
                foreach (var ComanditariosData in SociosComanditarios)
                {
                    SociosComanditarios Comanditarios = new SociosComanditarios
                    {
                        Accionista = ComanditariosData.Accionista ?? "N/A",
                        Documento = ComanditariosData.Documento ?? "N/A",
                        Calle = ComanditariosData.Calle ?? "N/A",
                        Ciudad = ComanditariosData.Ciudad ?? "N/A",
                        EstadoCivil = ComanditariosData.EstadoCivil.Substring(0, 1).ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)",
                        Nacionalidad = ComanditariosData.Nacionalidad ?? "N/A",
                        Sector = ComanditariosData.Sector ?? "N/A",
                        CantidaCuotasAcciones = Convert.ToInt32(ComanditariosData.CantidaCuotasAcciones)

                    };
                    if (!Formulario.SociosComanditarios.Any(c => c.Documento == Comanditarios.Documento))
                        Formulario.SociosComanditarios.Add(Comanditarios);

                }
            }
            if (SociosComanditados.Count() > 0)
            {
                foreach (var ComanditadosData in SociosComanditados)
                {
                    SociosComanditados Comanditados = new SociosComanditados
                    {
                        Accionista = ComanditadosData.Accionista ?? "N/A",
                        Documento = ComanditadosData.Documento ?? "N/A",
                        Calle = ComanditadosData.Calle ?? "N/A",
                        Ciudad = ComanditadosData.Ciudad ?? "",
                        EstadoCivil = ComanditadosData.EstadoCivil.Substring(0, 1).ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)",
                        Nacionalidad = ComanditadosData.Nacionalidad ?? "N/A",
                        Sector = ComanditadosData.Sector ?? "N/A",
                        CantidaCuotasAcciones = Convert.ToInt32(ComanditadosData.CantidaCuotasAcciones)
                    };
                    if (!Formulario.SociosComanditados.Any(c => c.Documento == Comanditados.Documento))
                        Formulario.SociosComanditados.Add(Comanditados);

                }
            }
            if (Comisarios.Count() > 0)
            {
                foreach (var elComisario in Comisarios)
                {
                    Comisario Comisario = new Comisario
                    {
                        Accionista = elComisario.Accionista ?? "N/A",
                        Documento = elComisario.Documento ?? "N/A",
                        Calle = elComisario.Calle ?? "N/A",
                        Ciudad = elComisario.Ciudad ?? "",
                        EstadoCivil = elComisario.EstadoCivil.Substring(0, 1).ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)",
                        Nacionalidad = elComisario.Nacionalidad ?? "N/A",
                        Sector = elComisario.Sector ?? "N/A",
                    };
                    if (!Formulario.Comisarios.Any(c => c.Documento == elComisario.Documento))
                        Formulario.Comisarios.Add(Comisario);
                }
            }
            if (ConsejoVijilancia.Count() > 0)
            {
                foreach (var elConsejal in ConsejoVijilancia)
                {
                    Comisario Consejal = new Comisario
                    {
                        Accionista = elConsejal.Accionista ?? "N/A",
                        Documento = elConsejal.Documento ?? "N/A",
                        Calle = elConsejal.Calle ?? "",
                        Ciudad = elConsejal.Ciudad ?? "",
                        EstadoCivil = elConsejal.EstadoCivil.Substring(0, 1).ToLower().Equals("c") ? "Casado(a)" : "Soltero(a)",
                        Nacionalidad = elConsejal.Nacionalidad ?? "N/A",
                        Sector = elConsejal.Sector ?? "N/A",
                    };
                    if (!Formulario.Comisarios.Any(c => c.Documento == Consejal.Documento))
                        Formulario.Comisarios.Add(Consejal);
                }
            }
            if (registroSociedades.Socio.Count() > 0)
            {
                for (int i = 0; i < registroSociedades.Socio.Count(); i++)

                {
                    Socio Socio = new Socio
                    {
                        RegistroId = registro.RegistroId,
                        TransaccionId = transaccion.TransaccionId,
                        SrmId = registroSociedades.Socio.ToArray()[i].ID,
                        SrmSocioId = registroSociedades.Socio.ToArray()[i].SocioId,
                        PersonaPrimerNombre = registroSociedades.Sociedad.ToArray()[i].NombreSocial ?? "N/A",
                        DireccionCiudadId = registroSociedades.Socio.ToArray()[i].CiudadId,
                        DireccionNombreCiudad = registroSociedades.Socio.ToArray()[i].Ciudad ?? "",
                        DireccionSectorId = registroSociedades.Socio.ToArray()[i].SectorId,
                        DireccionNombreSector = registroSociedades.Socio.ToArray()[i].Sector ?? "",
                        DireccionCalle = registroSociedades.Socio.ToArray()[i].Calle ?? "",
                        DireccionNumero = registroSociedades.Socio.ToArray()[i].Numero ?? "",
                        DireccionApartadoPostal = registroSociedades.Socio.ToArray()[i].ApartadoPostal ?? "",
                        NacionalidadId = registroSociedades.Socio.ToArray()[i].PaisId,
                        IdentificacionTributariaPais = registroSociedades.Socio.ToArray()[i].Pais ?? "",
                        TipoSocio = registroSociedades.Socio.ToArray()[i].TipoSocio,
                        TipoRelacion = registroSociedades.Socio.ToArray()[i].TipoRelacion,
                        TipoDocumento = "",
                        Documento = registroSociedades.Socio.ToArray()[i].Documento?.RemoverFormato() ?? "N/A"
                    };
                    if (!Formulario.Socios.Any(c => c.SrmSocioId == Socio.SrmSocioId))
                        Formulario.Socios.Add(Socio);
                }
            }
            if (referenciasComerciales.ToList().Count() > 0)
            {
                foreach (var item in referenciasComerciales)
                {
                    ReferenciaComercial referenciaComercial = new ReferenciaComercial
                    {
                        RegistroId = registro.RegistroId,
                        Descripcion = item.Descripcion ?? "N/A",
                        FechaModificacion = item.FechaModificacion,
                        TipoReferencia = item.TipoReferencia ?? "N/A",
                        ReferenciaComercialId = item.ReferenciaComercialId,
                        TransaccionId = transaccion.TransaccionId
                    };
                }
            }
            if (referenciasBancarias.ToList().Count() > 0)
            {
                foreach (var item in referenciasBancarias)
                {
                    ReferenciaBancaria referenciaComercial = new ReferenciaBancaria
                    {
                        BancoId = item.BancoId,
                        FechaModificacion = item.FechaModificacion,
                        NombreBanco = item.BancoDescripcion ?? "N/A",
                        RegistroId = registro.RegistroId,
                        ReferenciaBancariaId = item.ReferenciaBancariaId,
                        TransaccionId = transaccion.TransaccionId
                    };
                }
            }
            return true;
        }
    }
}