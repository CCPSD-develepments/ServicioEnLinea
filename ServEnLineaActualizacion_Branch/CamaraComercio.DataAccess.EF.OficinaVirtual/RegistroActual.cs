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

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    [Serializable]
    public partial class RegistroActual
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string RegistroId = @"RegistroId";	
    	public static string EmpresaId = @"EmpresaId";	
    	public static string NumeroRegistro = @"NumeroRegistro";	
    	public static string TipoSociedadId = @"TipoSociedadId";	
    	public static string TipoSociedad = @"TipoSociedad";	
    	public static string FechaEmision = @"FechaEmision";	
    	public static string FechaVencimiento = @"FechaVencimiento";	
    	public static string FechaConstitucion = @"FechaConstitucion";	
    	public static string FechaInicioOperaciones = @"FechaInicioOperaciones";	
    	public static string NombreEstablecimiento = @"NombreEstablecimiento";	
    	public static string RazonSocial = @"RazonSocial";	
    	public static string CapitalGeneral = @"CapitalGeneral";	
    	public static string CapitalAutorizado = @"CapitalAutorizado";	
    	public static string CapitalPagado = @"CapitalPagado";	
    	public static string Activos = @"Activos";	
    	public static string BienesRaices = @"BienesRaices";	
    	public static string IsZonaFranca = @"IsZonaFranca";	
    	public static string RNC = @"RNC";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual double RegistroId
        {
            get;
            set;
        }
    
        public virtual string EmpresaId
        {
            get;
            set;
        }
    
        public virtual Nullable<double> NumeroRegistro
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoSociedadId
        {
            get;
            set;
        }
    
        public virtual string TipoSociedad
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
    
        public virtual Nullable<System.DateTime> FechaConstitucion
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaInicioOperaciones
        {
            get;
            set;
        }
    
        public virtual string NombreEstablecimiento
        {
            get;
            set;
        }
    
        public virtual string RazonSocial
        {
            get;
            set;
        }
    
        public virtual Nullable<double> CapitalGeneral
        {
            get;
            set;
        }
    
        public virtual Nullable<double> CapitalAutorizado
        {
            get;
            set;
        }
    
        public virtual Nullable<double> CapitalPagado
        {
            get;
            set;
        }
    
        public virtual Nullable<double> Activos
        {
            get;
            set;
        }
    
        public virtual Nullable<double> BienesRaices
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> IsZonaFranca
        {
            get;
            set;
        }
    
        public virtual string RNC
        {
            get;
            set;
        }

        #endregion

    }
}
