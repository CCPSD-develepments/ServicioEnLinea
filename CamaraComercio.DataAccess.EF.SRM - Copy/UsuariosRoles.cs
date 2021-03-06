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
    public partial class UsuariosRoles
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string ID = @"ID";
    public static string UsuarioId = @"UsuarioId";
    public static string RolId = @"RolId";
    public static string FechaModificacion = @"FechaModificacion";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual int UsuarioId
        {
            get { return _usuarioId; }
            set
            {
                if (_usuarioId != value)
                {
                    if (Usuarios != null && Usuarios.UsuarioId != value)
                    {
                        Usuarios = null;
                    }
                    _usuarioId = value;
                }
            }
        }
        private int _usuarioId;
    
        public virtual int RolId
        {
            get { return _rolId; }
            set
            {
                if (_rolId != value)
                {
                    if (Roles != null && Roles.RolId != value)
                    {
                        Roles = null;
                    }
                    _rolId = value;
                }
            }
        }
        private int _rolId;
    
        public virtual System.DateTime FechaModificacion
        {
            get;
            set;
        }
    
        public virtual System.Guid rowguid
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Roles Roles
        {
            get { return _roles; }
            set
            {
                if (!ReferenceEquals(_roles, value))
                {
                    var previousValue = _roles;
                    _roles = value;
                    FixupRoles(previousValue);
                }
            }
        }
        private Roles _roles;
    
        public virtual Usuarios Usuarios
        {
            get { return _usuarios; }
            set
            {
                if (!ReferenceEquals(_usuarios, value))
                {
                    var previousValue = _usuarios;
                    _usuarios = value;
                    FixupUsuarios(previousValue);
                }
            }
        }
        private Usuarios _usuarios;

        #endregion

        #region Association Fixup
    
        private void FixupRoles(Roles previousValue)
        {
            if (previousValue != null && previousValue.UsuariosRoles.Contains(this))
            {
                previousValue.UsuariosRoles.Remove(this);
            }
    
            if (Roles != null)
            {
                if (!Roles.UsuariosRoles.Contains(this))
                {
                    Roles.UsuariosRoles.Add(this);
                }
                if (RolId != Roles.RolId)
                {
                    RolId = Roles.RolId;
                }
            }
        }
    
        private void FixupUsuarios(Usuarios previousValue)
        {
            if (previousValue != null && previousValue.UsuariosRoles.Contains(this))
            {
                previousValue.UsuariosRoles.Remove(this);
            }
    
            if (Usuarios != null)
            {
                if (!Usuarios.UsuariosRoles.Contains(this))
                {
                    Usuarios.UsuariosRoles.Add(this);
                }
                if (UsuarioId != Usuarios.UsuarioId)
                {
                    UsuarioId = Usuarios.UsuarioId;
                }
            }
        }

        #endregion

    }
}
