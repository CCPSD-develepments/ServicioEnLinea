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
    public partial class TransaccionesDocumentosOnapi
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string TransaccionesDocumentosOnapiId = @"TransaccionesDocumentosOnapiId";	
    	public static string TransaccionId = @"TransaccionId";	
    	public static string numeroSolicitudONAPI = @"numeroSolicitudONAPI";	
    	public static string Nombre = @"Nombre";	
    	public static string Descripcion = @"Descripcion";	
    	public static string NombreArchivo = @"NombreArchivo";	
    	public static string FechaEnvio = @"FechaEnvio";	
    	public static string Usuario = @"Usuario";	
    	public static string RowId = @"RowId";	
    	public static string DocContentType = @"DocContentType";	
    	public static string DocContent = @"DocContent";	
    	public static string Estatus = @"Estatus";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TransaccionesDocumentosOnapiId
        {
            get;
            set;
        }
    
        public virtual int TransaccionId
        {
            get;
            set;
        }
    
        public virtual int numeroSolicitudONAPI
        {
            get;
            set;
        }
    
        public virtual string Nombre
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }
    
        public virtual string NombreArchivo
        {
            get;
            set;
        }
    
        public virtual System.DateTime FechaEnvio
        {
            get;
            set;
        }
    
        public virtual string Usuario
        {
            get;
            set;
        }
    
        public virtual System.Guid RowId
        {
            get;
            set;
        }
    
        public virtual string DocContentType
        {
            get;
            set;
        }
    
        public virtual byte[] DocContent
        {
            get;
            set;
        }
    
        public virtual string Estatus
        {
            get;
            set;
        }

        #endregion

    }
}
