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
    public partial class Mensajes
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string ID = @"ID";	
    	public static string Usuario = @"Usuario";	
    	public static string UsuarioSistema = @"UsuarioSistema";	
    	public static string SociedadID = @"SociedadID";	
    	public static string Titulo = @"Titulo";	
    	public static string Mensaje = @"Mensaje";	
    	public static string FechaEnvio = @"FechaEnvio";	
    	public static string FechaLectura = @"FechaLectura";	
    	public static string TransaccionId = @"TransaccionId";	
    	public static string TipoMensaje = @"TipoMensaje";	
    	public static string CamaraId = @"CamaraId";	
    	public static string UsuarioPadre = @"UsuarioPadre";	
    	public static string idFirmaDocumentos = @"idFirmaDocumentos";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual string Usuario
        {
            get;
            set;
        }
    
        public virtual string UsuarioSistema
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SociedadID
        {
            get;
            set;
        }
    
        public virtual string Titulo
        {
            get;
            set;
        }
    
        public virtual string Mensaje
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaEnvio
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaLectura
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TransaccionId
        {
            get;
            set;
        }
    
        public virtual int TipoMensaje
        {
            get;
            set;
        }
    
        public virtual string CamaraId
        {
            get;
            set;
        }
    
        public virtual string UsuarioPadre
        {
            get;
            set;
        }
    
        public virtual Nullable<long> idFirmaDocumentos
        {
            get;
            set;
        }

        #endregion

    }
}
