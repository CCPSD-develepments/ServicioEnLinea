//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class cvw_SociedadesRegistros
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string SociedadId = @"SociedadId";
    public static string TipoSociedadId = @"TipoSociedadId";
    public static string NombreSocial = @"NombreSocial";
    public static string NombreEmpresa = @"NombreEmpresa";
    public static string NombreSiglas = @"NombreSiglas";
    public static string Rnc = @"Rnc";
    public static string EsNacional = @"EsNacional";
    public static string Nacionalidad = @"Nacionalidad";
    public static string NacionalidadId = @"NacionalidadId";
    public static string FechaConstitucion = @"FechaConstitucion";
    public static string DuracionSociedad = @"DuracionSociedad";
    public static string FechaAsamblea = @"FechaAsamblea";
    public static string DuraccionDirectiva = @"DuraccionDirectiva";
    public static string EstatusId = @"EstatusId";
    public static string EsEnteRegulado = @"EsEnteRegulado";
    public static string TipoEnteReguladoId = @"TipoEnteReguladoId";
    public static string NoResolucion = @"NoResolucion";
    public static string NumeroNaveIndustrial = @"NumeroNaveIndustrial";
    public static string NumeroRegistro = @"NumeroRegistro";
    public static string RegistroId = @"RegistroId";
    public static string FechaEmision = @"FechaEmision";
    public static string FechaVencimiento = @"FechaVencimiento";
    public static string NombreEstablecimiento = @"NombreEstablecimiento";
    public static string CapitalSocial = @"CapitalSocial";
    public static string TipoMonedaCapitalSocial = @"TipoMonedaCapitalSocial";
    public static string CapitalAutorizado = @"CapitalAutorizado";
    public static string TipoMonedaCapitalAutorizado = @"TipoMonedaCapitalAutorizado";
    public static string CapitalPagado = @"CapitalPagado";
    public static string TipoMonedaCapitalPagado = @"TipoMonedaCapitalPagado";
    public static string Activos = @"Activos";
    public static string TipoMonedaActivos = @"TipoMonedaActivos";
    public static string BienesRaices = @"BienesRaices";
    public static string TipoMonedaBienesRaices = @"TipoMonedaBienesRaices";
    public static string FechaInicioOperacion = @"FechaInicioOperacion";
    public static string EmpleadosMasculinos = @"EmpleadosMasculinos";
    public static string EmpleadosFemeninos = @"EmpleadosFemeninos";
    public static string EmpleadosTotal = @"EmpleadosTotal";
    public static string DireccionId = @"DireccionId";
    public static string NombreComercial = @"NombreComercial";
    public static string RegistroNombreComercial = @"RegistroNombreComercial";
    public static string MarcaFabrica = @"MarcaFabrica";
    public static string RegistroMarcaFabrica = @"RegistroMarcaFabrica";
    public static string PatenteInversion = @"PatenteInversion";
    public static string RegistroPatenteInversion = @"RegistroPatenteInversion";
    public static string EsProvicional = @"EsProvicional";
    public static string Comentario1 = @"Comentario1";
    public static string Comentario2 = @"Comentario2";
    public static string NombreOperador = @"NombreOperador";
    public static string NombreSociedad = @"NombreSociedad";
    public static string TipoRegistro = @"TipoRegistro";
    public static string Estado = @"Estado";
    public static string ActividadNegocio = @"ActividadNegocio";
    public static string NumeroSocios = @"NumeroSocios";
    public static string EsSocioInterno = @"EsSocioInterno";
    public static string TipoSocioInterno = @"TipoSocioInterno";
    public static string FechaCreacion = @"FechaCreacion";
    public static string FechaModificacion = @"FechaModificacion";
    public static string TotalAcciones = @"TotalAcciones";
    public static string AbreviaturaTipoMonedaActivos = @"AbreviaturaTipoMonedaActivos";
    public static string AbreviaturaTipoMonedaBienesRaices = @"AbreviaturaTipoMonedaBienesRaices";
    public static string AbreviaturaTIpoMonedaCapitalAutorizado = @"AbreviaturaTIpoMonedaCapitalAutorizado";
    public static string AbreviaturaTipoMonedaCapitalPagado = @"AbreviaturaTipoMonedaCapitalPagado";
    public static string AbreviaturaTipoMonedaCapitalSocial = @"AbreviaturaTipoMonedaCapitalSocial";
    public static string Sociedad = @"Sociedad";
    public static string SufijoSociedad = @"SufijoSociedad";
    public static string TipoEnteRegulado = @"TipoEnteRegulado";
    public static string SiglasConfig = @"SiglasConfig";
    public static string Suscripcion = @"Suscripcion";
    public static string bAdecuada = @"bAdecuada";
    public static string Id_Cierre_Fiscal = @"Id_Cierre_Fiscal";
    public static string ActividadCIUU2 = @"ActividadCIUU2";
    public static string ActividadIdCIUU2 = @"ActividadIdCIUU2";
    public static string ActividadCIUU = @"ActividadCIUU";
    public static string VersionRegistro = @"VersionRegistro";
    public static string EsValida = @"EsValida";
    public static string bActoAlguacil = @"bActoAlguacil";
    public static string FechaAsamblea1 = @"FechaAsamblea1";
    public static string FechaAsamblea2 = @"FechaAsamblea2";
    public static string isRncValido = @"isRncValido";
    public static string FechaEnteRegulado = @"FechaEnteRegulado";
    public static string bActividadCIUU = @"bActividadCIUU";
    public static string ActividadIdCIUU = @"ActividadIdCIUU";
    public static string SocioValido = @"SocioValido";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int SociedadId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoSociedadId
        {
            get;
            set;
        }
    
        public virtual string NombreSocial
        {
            get;
            set;
        }
    
        public virtual string NombreEmpresa
        {
            get;
            set;
        }
    
        public virtual string NombreSiglas
        {
            get;
            set;
        }
    
        public virtual string Rnc
        {
            get;
            set;
        }
    
        public virtual bool EsNacional
        {
            get;
            set;
        }
    
        public virtual string Nacionalidad
        {
            get;
            set;
        }
    
        public virtual Nullable<int> NacionalidadId
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaConstitucion
        {
            get;
            set;
        }
    
        public virtual string DuracionSociedad
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaAsamblea
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DuraccionDirectiva
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EstatusId
        {
            get;
            set;
        }
    
        public virtual bool EsEnteRegulado
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoEnteReguladoId
        {
            get;
            set;
        }
    
        public virtual string NoResolucion
        {
            get;
            set;
        }
    
        public virtual string NumeroNaveIndustrial
        {
            get;
            set;
        }
    
        public virtual int NumeroRegistro
        {
            get;
            set;
        }
    
        public virtual int RegistroId
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaEmision
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaVencimiento
        {
            get;
            set;
        }
    
        public virtual string NombreEstablecimiento
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalSocial
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaCapitalSocial
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalAutorizado
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaCapitalAutorizado
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalPagado
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaCapitalPagado
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> Activos
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaActivos
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> BienesRaices
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaBienesRaices
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaInicioOperacion
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosMasculinos
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosFemeninos
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosTotal
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionId
        {
            get;
            set;
        }
    
        public virtual string NombreComercial
        {
            get;
            set;
        }
    
        public virtual string RegistroNombreComercial
        {
            get;
            set;
        }
    
        public virtual string MarcaFabrica
        {
            get;
            set;
        }
    
        public virtual string RegistroMarcaFabrica
        {
            get;
            set;
        }
    
        public virtual string PatenteInversion
        {
            get;
            set;
        }
    
        public virtual string RegistroPatenteInversion
        {
            get;
            set;
        }
    
        public virtual bool EsProvicional
        {
            get;
            set;
        }
    
        public virtual string Comentario1
        {
            get;
            set;
        }
    
        public virtual string Comentario2
        {
            get;
            set;
        }
    
        public virtual string NombreOperador
        {
            get;
            set;
        }
    
        public virtual string NombreSociedad
        {
            get;
            set;
        }
    
        public virtual string TipoRegistro
        {
            get;
            set;
        }
    
        public virtual string Estado
        {
            get;
            set;
        }
    
        public virtual string ActividadNegocio
        {
            get;
            set;
        }
    
        public virtual Nullable<int> NumeroSocios
        {
            get;
            set;
        }
    
        public virtual bool EsSocioInterno
        {
            get;
            set;
        }
    
        public virtual string TipoSocioInterno
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaCreacion
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaModificacion
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TotalAcciones
        {
            get;
            set;
        }
    
        public virtual string AbreviaturaTipoMonedaActivos
        {
            get;
            set;
        }
    
        public virtual string AbreviaturaTipoMonedaBienesRaices
        {
            get;
            set;
        }
    
        public virtual string AbreviaturaTIpoMonedaCapitalAutorizado
        {
            get;
            set;
        }
    
        public virtual string AbreviaturaTipoMonedaCapitalPagado
        {
            get;
            set;
        }
    
        public virtual string AbreviaturaTipoMonedaCapitalSocial
        {
            get;
            set;
        }
    
        public virtual string Sociedad
        {
            get;
            set;
        }
    
        public virtual string SufijoSociedad
        {
            get;
            set;
        }
    
        public virtual string TipoEnteRegulado
        {
            get;
            set;
        }
    
        public virtual string SiglasConfig
        {
            get;
            set;
        }
    
        public virtual string Suscripcion
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> bAdecuada
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Id_Cierre_Fiscal
        {
            get;
            set;
        }
    
        public virtual string ActividadCIUU2
        {
            get;
            set;
        }
    
        public virtual string ActividadIdCIUU2
        {
            get;
            set;
        }
    
        public virtual string ActividadCIUU
        {
            get;
            set;
        }
    
        public virtual System.Guid VersionRegistro
        {
            get;
            set;
        }
    
        public virtual bool EsValida
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> bActoAlguacil
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaAsamblea1
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaAsamblea2
        {
            get;
            set;
        }
    
        public virtual bool isRncValido
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaEnteRegulado
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> bActividadCIUU
        {
            get;
            set;
        }
    
        public virtual string ActividadIdCIUU
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> SocioValido
        {
            get;
            set;
        }

        #endregion

    }
}
