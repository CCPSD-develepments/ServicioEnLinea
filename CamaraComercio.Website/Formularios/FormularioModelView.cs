using System;
using System.Collections.Generic;
namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView'
    public class FormularioModelView
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Registro'
        public virtual Registro Registro { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Registro'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Sociedad'
        public virtual Sociedad Sociedad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Sociedad'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Socios'
        public virtual ICollection<Socio> Socios { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Socios'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.SociosComanditarios'
        public virtual ICollection<SociosComanditarios> SociosComanditarios { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.SociosComanditarios'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.SociosComanditados'
        public virtual ICollection<SociosComanditados> SociosComanditados { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.SociosComanditados'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.OrganoGestion'
        public virtual ICollection<OrganoGestion> OrganoGestion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.OrganoGestion'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.SociosFirmas'
        public virtual ICollection<SociosFirmas> SociosFirmas { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.SociosFirmas'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.ReferenciaComercial'
        public virtual ICollection<ReferenciaComercial> ReferenciaComercial { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.ReferenciaComercial'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.ReferenciaBancaria'
        public virtual ICollection<ReferenciaBancaria> ReferenciaBancaria { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.ReferenciaBancaria'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Comisarios'
        public virtual ICollection<Comisario> Comisarios { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.Comisarios'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.ConsejoVigilancia'
        public virtual ICollection<ConsejoVigilancia> ConsejoVigilancia { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioModelView.ConsejoVigilancia'

    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro'
    public class Registro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro'
    {
        #region Primitive Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroId'
        public virtual int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroMercantil'
        public virtual Nullable<int> RegistroMercantil
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroMercantil'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaEmision'
        public virtual Nullable<System.DateTime> FechaEmision
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaEmision'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaVencimiento'
        public virtual Nullable<System.DateTime> FechaVencimiento
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaVencimiento'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.CapitalSocial'
        public virtual Nullable<decimal> CapitalSocial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.CapitalSocial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.CapitalAutorizado'
        public virtual Nullable<decimal> CapitalAutorizado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.CapitalAutorizado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.CapitalPagado'
        public virtual Nullable<decimal> CapitalPagado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.CapitalPagado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.Activos'
        public virtual Nullable<decimal> Activos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.Activos'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.BienesRaices'
        public virtual Nullable<decimal> BienesRaices
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.BienesRaices'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaInicioOperacion'
        public virtual Nullable<System.DateTime> FechaInicioOperacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaInicioOperacion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.EmpleadosMasculinos'
        public virtual Nullable<int> EmpleadosMasculinos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.EmpleadosMasculinos'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.EmpleadosFemeninos'
        public virtual Nullable<int> EmpleadosFemeninos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.EmpleadosFemeninos'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.EmpleadosTotal'
        public virtual Nullable<int> EmpleadosTotal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.EmpleadosTotal'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.NombreComercial'
        public virtual string NombreComercial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.NombreComercial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroNombreComercial'
        public virtual string RegistroNombreComercial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroNombreComercial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.MarcaFabrica'
        public virtual string MarcaFabrica
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.MarcaFabrica'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroMarcaFabrica'
        public virtual string RegistroMarcaFabrica
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroMarcaFabrica'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.PatenteInvencion'
        public virtual string PatenteInvencion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.PatenteInvencion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroPatenteInvencion'
        public virtual string RegistroPatenteInvencion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.RegistroPatenteInvencion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.NombreOperador'
        public virtual string NombreOperador
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.NombreOperador'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadNegocio'
        public virtual string ActividadNegocio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadNegocio'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.NumeroSocios'
        public virtual Nullable<int> NumeroSocios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.NumeroSocios'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TotalAcciones'
        public virtual Nullable<int> TotalAcciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TotalAcciones'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.EsNuevoRegistro'
        public virtual bool EsNuevoRegistro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.EsNuevoRegistro'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionCalle'
        public virtual string DireccionCalle
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionCalle'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionNumero'
        public virtual string DireccionNumero
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionNumero'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionCiudadId'
        public virtual Nullable<int> DireccionCiudadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionCiudadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionCiudad'
        public virtual string DireccionCiudad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionCiudad'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionSector'
        public virtual string DireccionSector
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionSector'
        {
            get; set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionSectorId'
        public virtual Nullable<int> DireccionSectorId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionSectorId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionApartadoPostal'
        public virtual string DireccionApartadoPostal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionApartadoPostal'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionTelefonoCasa'
        public virtual string DireccionTelefonoCasa
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionTelefonoCasa'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionTelefonoOficina'
        public virtual string DireccionTelefonoOficina
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionTelefonoOficina'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionExtension'
        public virtual Nullable<int> DireccionExtension
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionExtension'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionFax'
        public virtual string DireccionFax
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionFax'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionEmail'
        public virtual string DireccionEmail
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionEmail'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionSitioWeb'
        public virtual string DireccionSitioWeb
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.DireccionSitioWeb'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.NombreSolicitante'
        public virtual string NombreSolicitante
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.NombreSolicitante'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.CargoSolicitante'
        public virtual string CargoSolicitante
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.CargoSolicitante'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.GestorUsername'
        public virtual string GestorUsername
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.GestorUsername'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.EntidadActiva'
        public virtual Nullable<bool> EntidadActiva
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.EntidadActiva'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.EsRenovacion'
        public virtual bool EsRenovacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.EsRenovacion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaCapitalSocial'
        public virtual Nullable<int> TipoMonedaCapitalSocial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaCapitalSocial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaCapitalAutorizado'
        public virtual Nullable<int> TipoMonedaCapitalAutorizado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaCapitalAutorizado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaCapitalPagado'
        public virtual Nullable<int> TipoMonedaCapitalPagado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaCapitalPagado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaActivos'
        public virtual Nullable<int> TipoMonedaActivos
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaActivos'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaBienesRaices'
        public virtual Nullable<int> TipoMonedaBienesRaices
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TipoMonedaBienesRaices'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadIdCIUU'
        public virtual string ActividadIdCIUU
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadIdCIUU'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadCIUU'
        public virtual string ActividadCIUU
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadCIUU'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadIdCIUU2'
        public virtual string ActividadIdCIUU2
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadIdCIUU2'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadCIUU2'
        public virtual string ActividadCIUU2
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.ActividadCIUU2'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.Id_Cierre_Fiscal'
        public virtual Nullable<int> Id_Cierre_Fiscal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.Id_Cierre_Fiscal'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaAsamblea1'
        public virtual Nullable<System.DateTime> FechaAsamblea1
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaAsamblea1'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaAsamblea2'
        public virtual Nullable<System.DateTime> FechaAsamblea2
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.FechaAsamblea2'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.SrmRegistroId'
        public virtual Nullable<int> SrmRegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.SrmRegistroId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Registro.TransaccionId'
        public virtual Nullable<int> TransaccionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Registro.TransaccionId'
        {
            get;
            set;
        }

        #endregion
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio'
    public class Socio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio'
    {
        #region Primitive Properties
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionNombreCiudad'
        public string DireccionNombreCiudad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionNombreCiudad'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionNombreSector'
        public string DireccionNombreSector
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionNombreSector'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Modificado'
        public bool Modificado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Modificado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Id'
        public virtual int Id
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Id'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.RegistroId'
        public virtual int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.RegistroId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoSocio'
        public virtual string TipoSocio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoSocio'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoRelacion'
        public virtual string TipoRelacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoRelacion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.CargoId'
        public virtual Nullable<int> CargoId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.CargoId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Cargo'
        public virtual string Cargo
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Cargo'
        {
            get;
            set;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoDocumento'
        public virtual string TipoDocumento
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoDocumento'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Documento'
        public virtual string Documento
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Documento'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.NacionalidadId'
        public virtual Nullable<int> NacionalidadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.NacionalidadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Nacionalidad'
        public virtual string Nacionalidad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Nacionalidad'
        {
            get;
            set;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.RegistroMercantil'
        public virtual string RegistroMercantil
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.RegistroMercantil'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Orden'
        public virtual int Orden
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Orden'
        {
            get;
            set;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.NumeroRM'
        public virtual string NumeroRM { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.NumeroRM'


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.SociedadNombreSocial'
        public virtual string SociedadNombreSocial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.SociedadNombreSocial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaPrimerNombre'
        public virtual string PersonaPrimerNombre
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaPrimerNombre'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaSegundoNombre'
        public virtual string PersonaSegundoNombre
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaSegundoNombre'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaPrimerApellido'
        public virtual string PersonaPrimerApellido
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaPrimerApellido'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaSegundoApellido'
        public virtual string PersonaSegundoApellido
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaSegundoApellido'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaEstadoCivil'
        public virtual string PersonaEstadoCivil
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaEstadoCivil'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaProfesionId'
        public virtual Nullable<int> PersonaProfesionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.PersonaProfesionId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionCalle'
        public virtual string DireccionCalle
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionCalle'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionNumero'
        public virtual string DireccionNumero
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionNumero'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionCiudadId'
        public virtual Nullable<int> DireccionCiudadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionCiudadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionSectorId'
        public virtual Nullable<int> DireccionSectorId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionSectorId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionApartadoPostal'
        public virtual string DireccionApartadoPostal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.DireccionApartadoPostal'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.RepresentanteId'
        public virtual Nullable<int> RepresentanteId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.RepresentanteId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.CantidadAcciones'
        public virtual Nullable<int> CantidadAcciones
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.CantidadAcciones'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.FechaNacimiento'
        public virtual Nullable<System.DateTime> FechaNacimiento
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.FechaNacimiento'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoBeneficiario'
        public virtual string TipoBeneficiario
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoBeneficiario'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.IdentificacionTributariaPais'
        public virtual string IdentificacionTributariaPais
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.IdentificacionTributariaPais'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoDatosSocio'
        public virtual string TipoDatosSocio
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.TipoDatosSocio'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Telefono1'
        public virtual string Telefono1
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Telefono1'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.Telefono2'
        public virtual string Telefono2
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.Telefono2'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.CorreoElectronico'
        public virtual string CorreoElectronico
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.CorreoElectronico'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.SrmId'
        public virtual Nullable<int> SrmId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.SrmId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.SrmSocioId'
        public virtual Nullable<int> SrmSocioId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.SrmSocioId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Socio.TransaccionId'
        public virtual Nullable<int> TransaccionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Socio.TransaccionId'
        {
            get;
            set;
        }

        #endregion
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal'
    public class Sucursal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal'
    {
        #region Primitive Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.SucursalId'
        public virtual int SucursalId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.SucursalId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.SociedadId'
        public virtual int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.SociedadId'
        {
            get;
            set;
        }
#pragma warning disable CS0169 // The field 'Sucursal._sociedadId' is never used
        private int _sociedadId;
#pragma warning restore CS0169 // The field 'Sucursal._sociedadId' is never used

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.Descripcion'
        public virtual string Descripcion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.Descripcion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionId'
        public virtual Nullable<int> DireccionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.FechaModificacion'
        public virtual System.DateTime FechaModificacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.FechaModificacion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionCalle'
        public virtual string DireccionCalle
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionCalle'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionNumero'
        public virtual string DireccionNumero
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionNumero'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionCiudadId'
        public virtual Nullable<int> DireccionCiudadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionCiudadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionSectorId'
        public virtual Nullable<int> DireccionSectorId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionSectorId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionApartadoPostal'
        public virtual string DireccionApartadoPostal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionApartadoPostal'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionTelefonoCasa'
        public virtual string DireccionTelefonoCasa
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionTelefonoCasa'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionTelefonoOficina'
        public virtual string DireccionTelefonoOficina
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionTelefonoOficina'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionExtension'
        public virtual Nullable<int> DireccionExtension
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionExtension'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionFax'
        public virtual string DireccionFax
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionFax'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionEmail'
        public virtual string DireccionEmail
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sucursal.DireccionEmail'
        {
            get;
            set;
        }

        #endregion
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad'
    public class Sociedad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad'
    {
        #region Primitive Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.SociedadId'
        public virtual int SociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.SociedadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.RegistroId'
        public virtual int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.RegistroId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.TipoSociedadId'
        public virtual Nullable<int> TipoSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.TipoSociedadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NombreSocial'
        public virtual string NombreSocial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NombreSocial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.Rnc'
        public virtual string Rnc
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.Rnc'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.EsNacional'
        public virtual bool EsNacional
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.EsNacional'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NacionalidadId'
        public virtual Nullable<int> NacionalidadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NacionalidadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.FechaConstitucion'
        public virtual Nullable<System.DateTime> FechaConstitucion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.FechaConstitucion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.DuracionSociedad'
        public virtual string DuracionSociedad
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.DuracionSociedad'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.FechaAsamblea'
        public virtual Nullable<System.DateTime> FechaAsamblea
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.FechaAsamblea'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.DuraccionDirectiva'
        public virtual Nullable<int> DuraccionDirectiva
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.DuraccionDirectiva'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.EstatusId'
        public virtual Nullable<int> EstatusId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.EstatusId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.EsEnteRegulado'
        public virtual bool EsEnteRegulado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.EsEnteRegulado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.TipoEnteReguladoId'
        public virtual Nullable<int> TipoEnteReguladoId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.TipoEnteReguladoId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NoResolucion'
        public virtual string NoResolucion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NoResolucion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NumeroNaveIndustrial'
        public virtual string NumeroNaveIndustrial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NumeroNaveIndustrial'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NombreSiglas'
        public virtual string NombreSiglas
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.NombreSiglas'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.SiglasConfig'
        public virtual string SiglasConfig
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.SiglasConfig'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.AccionesNominales'
        public virtual Nullable<int> AccionesNominales
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.AccionesNominales'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.AccionesNoNominales'
        public virtual Nullable<int> AccionesNoNominales
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.AccionesNoNominales'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.FechaEnteRegulado'
        public virtual Nullable<System.DateTime> FechaEnteRegulado
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.FechaEnteRegulado'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.SrmSociedadId'
        public virtual Nullable<int> SrmSociedadId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.SrmSociedadId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.TransaccionId'
        public virtual Nullable<int> TransaccionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Sociedad.TransaccionId'
        {
            get;
            set;
        }
#pragma warning disable CS0169 // The field 'Sociedad._transaccionId' is never used
        private Nullable<int> _transaccionId;
#pragma warning restore CS0169 // The field 'Sociedad._transaccionId' is never used

        #endregion
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial'
    public class ReferenciaComercial
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial'
    {
        #region Primitive Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.ReferenciaComercialId'
        public virtual int ReferenciaComercialId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.ReferenciaComercialId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.RegistroId'
        public virtual int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.RegistroId'
        {
            get;
            set;
        }
#pragma warning disable CS0169 // The field 'ReferenciaComercial._registroId' is never used
        private int _registroId;
#pragma warning restore CS0169 // The field 'ReferenciaComercial._registroId' is never used

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.TipoReferencia'
        public virtual string TipoReferencia
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.TipoReferencia'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.Descripcion'
        public virtual string Descripcion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.Descripcion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.FechaModificacion'
        public virtual System.DateTime FechaModificacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.FechaModificacion'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.TransaccionId'
        public virtual Nullable<int> TransaccionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaComercial.TransaccionId'
        {
            get;
            set;
        }
#pragma warning disable CS0169 // The field 'ReferenciaComercial._transaccionId' is never used
        private Nullable<int> _transaccionId;
#pragma warning restore CS0169 // The field 'ReferenciaComercial._transaccionId' is never used

        #endregion
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria'
    public class ReferenciaBancaria
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria'
    {
        #region Primitive Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.ReferenciaBancariaId'
        public virtual int ReferenciaBancariaId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.ReferenciaBancariaId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.RegistroId'
        public virtual int RegistroId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.RegistroId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.BancoId'
        public virtual int BancoId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.BancoId'
        {
            get;
            set;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.FechaModificacion'
        public virtual System.DateTime FechaModificacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.FechaModificacion'
        {
            get;
            set;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.NombreBanco'
        public string NombreBanco
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.NombreBanco'
        {
            get;
            set;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.TransaccionId'
        public virtual Nullable<int> TransaccionId
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ReferenciaBancaria.TransaccionId'
        {
            get;
            set;
        }

        #endregion
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas'
    public class SociosFirmas
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Cargo'
        public virtual string Cargo { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Cargo'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Accionista'
        public virtual string Accionista { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Accionista'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Calle'
        public virtual string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Sector'
        public virtual string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Ciudad'
        public virtual string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Nacionalidad'
        public virtual string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.EstadoCivil'
        public virtual string EstadoCivil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.EstadoCivil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Documento'
        public virtual string Documento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosFirmas.Documento'

    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion'
    public class OrganoGestion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Cargo'
        public virtual string Cargo { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Cargo'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Accionista'
        public virtual string Accionista { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Accionista'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.NumeroRM'
        public virtual string NumeroRM { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.NumeroRM'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Calle'
        public virtual string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Sector'
        public virtual string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Ciudad'
        public virtual string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Nacionalidad'
        public virtual string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.EstadoCivil'
        public virtual string EstadoCivil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.EstadoCivil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Documento'
        public virtual string Documento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrganoGestion.Documento'

    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios'
    public class SociosComanditarios
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Accionista'
        public virtual string Accionista { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Accionista'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Calle'
        public virtual string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Sector'
        public virtual string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Ciudad'
        public virtual string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Nacionalidad'
        public virtual string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.EstadoCivil'
        public virtual string EstadoCivil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.EstadoCivil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Documento'
        public virtual string Documento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.Documento'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.CantidaCuotasAcciones'
        public virtual int CantidaCuotasAcciones { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditarios.CantidaCuotasAcciones'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados'
    public class SociosComanditados
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Accionista'
        public virtual string Accionista { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Accionista'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Calle'
        public virtual string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Sector'
        public virtual string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Ciudad'
        public virtual string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Nacionalidad'
        public virtual string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.EstadoCivil'
        public virtual string EstadoCivil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.EstadoCivil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Documento'
        public virtual string Documento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.Documento'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.CantidaCuotasAcciones'
        public virtual int CantidaCuotasAcciones { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SociosComanditados.CantidaCuotasAcciones'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario'
    public class Comisario
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Accionista'
        public virtual string Accionista { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Accionista'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Calle'
        public virtual string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Sector'
        public virtual string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Ciudad'
        public virtual string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Nacionalidad'
        public virtual string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.EstadoCivil'
        public virtual string EstadoCivil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.EstadoCivil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Documento'
        public virtual string Documento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Comisario.Documento'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia'
    public class ConsejoVigilancia    {
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Accionista'
        public virtual string Accionista { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Accionista'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Calle'
        public virtual string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Sector'
        public virtual string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Ciudad'
        public virtual string Ciudad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Ciudad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Nacionalidad'
        public virtual string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.EstadoCivil'
        public virtual string EstadoCivil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.EstadoCivil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Documento'
        public virtual string Documento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConsejoVigilancia.Documento'
    }

}