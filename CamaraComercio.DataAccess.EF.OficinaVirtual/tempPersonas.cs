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
    public partial class tempPersonas
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string Id = @"Id";	
    	public static string PersonaId = @"PersonaId";	
    	public static string TransaccionId = @"TransaccionId";	
    	public static string TipoDocumento = @"TipoDocumento";	
    	public static string Documento = @"Documento";	
    	public static string PrimerNombre = @"PrimerNombre";	
    	public static string SegundoNombre = @"SegundoNombre";	
    	public static string PrimerApellido = @"PrimerApellido";	
    	public static string SegundoApellido = @"SegundoApellido";	
    	public static string Rnc = @"Rnc";	
    	public static string NacionalidadId = @"NacionalidadId";	
    	public static string EstadoCivil = @"EstadoCivil";	
    	public static string ProfesionId = @"ProfesionId";	
    	public static string DireccionId = @"DireccionId";	
    	public static string DireccionCalle = @"DireccionCalle";	
    	public static string DireccionNumero = @"DireccionNumero";	
    	public static string DireccionCiudadId = @"DireccionCiudadId";	
    	public static string DireccionSectorId = @"DireccionSectorId";	
    	public static string DireccionApartadoPostal = @"DireccionApartadoPostal";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual int PersonaId
        {
            get;
            set;
        }
    
        public virtual int TransaccionId
        {
            get;
            set;
        }
    
        public virtual string TipoDocumento
        {
            get;
            set;
        }
    
        public virtual string Documento
        {
            get;
            set;
        }
    
        public virtual string PrimerNombre
        {
            get;
            set;
        }
    
        public virtual string SegundoNombre
        {
            get;
            set;
        }
    
        public virtual string PrimerApellido
        {
            get;
            set;
        }
    
        public virtual string SegundoApellido
        {
            get;
            set;
        }
    
        public virtual string Rnc
        {
            get;
            set;
        }
    
        public virtual Nullable<int> NacionalidadId
        {
            get;
            set;
        }
    
        public virtual string EstadoCivil
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ProfesionId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionId
        {
            get;
            set;
        }
    
        public virtual string DireccionCalle
        {
            get;
            set;
        }
    
        public virtual string DireccionNumero
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionCiudadId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionSectorId
        {
            get;
            set;
        }
    
        public virtual string DireccionApartadoPostal
        {
            get;
            set;
        }

        #endregion

    }
}
