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

namespace CamaraComercio.DataAccess.EF.CamaraComun
{
    public partial class ViewServicioDocumentoRequerido
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string TipoSociedadId = @"TipoSociedadId";	
    	public static string ServicioId = @"ServicioId";	
    	public static string TipoDocumentoId = @"TipoDocumentoId";	
    	public static string Requerido = @"Requerido";	
    	public static string DocumentoDescripcion = @"DocumentoDescripcion";	
    	public static string TipoSociedadDescripcion = @"TipoSociedadDescripcion";	
    	public static string Registrable = @"Registrable";	
    	public static string CostoOriginal = @"CostoOriginal";	
    	public static string CostoCopia = @"CostoCopia";	
    	public static string Visible = @"Visible";	
    	public static string FechaModificacion = @"FechaModificacion";	
    	public static string Grupo = @"Grupo";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TipoSociedadId
        {
            get;
            set;
        }
    
        public virtual int ServicioId
        {
            get;
            set;
        }
    
        public virtual int TipoDocumentoId
        {
            get;
            set;
        }
    
        public virtual bool Requerido
        {
            get;
            set;
        }
    
        public virtual string DocumentoDescripcion
        {
            get;
            set;
        }
    
        public virtual string TipoSociedadDescripcion
        {
            get;
            set;
        }
    
        public virtual bool Registrable
        {
            get;
            set;
        }
    
        public virtual decimal CostoOriginal
        {
            get;
            set;
        }
    
        public virtual decimal CostoCopia
        {
            get;
            set;
        }
    
        public virtual bool Visible
        {
            get;
            set;
        }
    
        public virtual System.DateTime FechaModificacion
        {
            get;
            set;
        }
    
        public virtual int Grupo
        {
            get;
            set;
        }

        #endregion

    }
}
