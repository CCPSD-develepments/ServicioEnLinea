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
    public partial class TempDatosSociedad
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string Id = @"Id";	
    	public static string TransaccionId = @"TransaccionId";	
    	public static string CapitalSocial = @"CapitalSocial";	
    	public static string BienesRaices = @"BienesRaices";	
    	public static string Activos = @"Activos";	
    	public static string FechaInicioOperaciones = @"FechaInicioOperaciones";	
    	public static string FechaEstatutosAsamblea = @"FechaEstatutosAsamblea";	
    	public static string FechaPrimeraAsamblea = @"FechaPrimeraAsamblea";	
    	public static string FechaCierreFiscal = @"FechaCierreFiscal";	
    	public static string DuracionEmpresa = @"DuracionEmpresa";	
    	public static string DuracionOrganoGestion = @"DuracionOrganoGestion";	
    	public static string EmpleadosM = @"EmpleadosM";	
    	public static string EmpleadosF = @"EmpleadosF";	
    	public static string Usuario = @"Usuario";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TransaccionId
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalSocial
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> BienesRaices
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> Activos
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaInicioOperaciones
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaEstatutosAsamblea
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaPrimeraAsamblea
        {
            get;
            set;
        }
    
        public virtual string FechaCierreFiscal
        {
            get;
            set;
        }
    
        public virtual string DuracionEmpresa
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DuracionOrganoGestion
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosM
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosF
        {
            get;
            set;
        }
    
        public virtual string Usuario
        {
            get;
            set;
        }

        #endregion

    }
}
