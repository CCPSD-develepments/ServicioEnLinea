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

namespace CamaraComercio.DataAccess.EF.Membership
{
    public partial class ViewProfileProperties
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string UserId = @"UserId";
    public static string TipoDocumento = @"TipoDocumento";
    public static string NumeroDocumento = @"NumeroDocumento";
    public static string NombreSolicitante = @"NombreSolicitante";
    public static string LastUpdatedDate = @"LastUpdatedDate";
    public static string UserName = @"UserName";
    public static string UsuarioPadre = @"UsuarioPadre";
    public static string Email = @"Email";
    public static string IsApproved = @"IsApproved";
    public static string PasswordResetKey = @"PasswordResetKey";
    public static string ActivateUserKey = @"ActivateUserKey";
    public static string IsActive = @"IsActive";
    public static string NombreEmpresa = @"NombreEmpresa";
    public static string RNC = @"RNC";
    public static string Phone = @"Phone";
    public static string Extension = @"Extension";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual System.Guid UserId
        {
            get;
            set;
        }
    
        public virtual string TipoDocumento
        {
            get;
            set;
        }
    
        public virtual string NumeroDocumento
        {
            get;
            set;
        }
    
        public virtual string NombreSolicitante
        {
            get;
            set;
        }
    
        public virtual System.DateTime LastUpdatedDate
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }
    
        public virtual string UsuarioPadre
        {
            get;
            set;
        }
    
        public virtual string Email
        {
            get;
            set;
        }
    
        public virtual bool IsApproved
        {
            get;
            set;
        }
    
        public virtual string PasswordResetKey
        {
            get;
            set;
        }
    
        public virtual string ActivateUserKey
        {
            get;
            set;
        }
    
        public virtual string IsActive
        {
            get;
            set;
        }
    
        public virtual string NombreEmpresa
        {
            get;
            set;
        }
    
        public virtual string RNC
        {
            get;
            set;
        }
    
        public virtual string Phone
        {
            get;
            set;
        }
    
        public virtual string Extension
        {
            get;
            set;
        }

        #endregion

    }
}
