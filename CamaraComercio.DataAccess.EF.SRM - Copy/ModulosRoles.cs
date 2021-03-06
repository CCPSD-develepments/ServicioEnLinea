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
    public partial class ModulosRoles
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string ID = @"ID";
    public static string ModuloId = @"ModuloId";
    public static string RolId = @"RolId";
    public static string TipoAcceso = @"TipoAcceso";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual int ModuloId
        {
            get { return _moduloId; }
            set
            {
                if (_moduloId != value)
                {
                    if (Modulos != null && Modulos.ModuloId != value)
                    {
                        Modulos = null;
                    }
                    _moduloId = value;
                }
            }
        }
        private int _moduloId;
    
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
    
        public virtual string TipoAcceso
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Modulos Modulos
        {
            get { return _modulos; }
            set
            {
                if (!ReferenceEquals(_modulos, value))
                {
                    var previousValue = _modulos;
                    _modulos = value;
                    FixupModulos(previousValue);
                }
            }
        }
        private Modulos _modulos;
    
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

        #endregion

        #region Association Fixup
    
        private void FixupModulos(Modulos previousValue)
        {
            if (previousValue != null && previousValue.ModulosRoles.Contains(this))
            {
                previousValue.ModulosRoles.Remove(this);
            }
    
            if (Modulos != null)
            {
                if (!Modulos.ModulosRoles.Contains(this))
                {
                    Modulos.ModulosRoles.Add(this);
                }
                if (ModuloId != Modulos.ModuloId)
                {
                    ModuloId = Modulos.ModuloId;
                }
            }
        }
    
        private void FixupRoles(Roles previousValue)
        {
            if (previousValue != null && previousValue.ModulosRoles.Contains(this))
            {
                previousValue.ModulosRoles.Remove(this);
            }
    
            if (Roles != null)
            {
                if (!Roles.ModulosRoles.Contains(this))
                {
                    Roles.ModulosRoles.Add(this);
                }
                if (RolId != Roles.RolId)
                {
                    RolId = Roles.RolId;
                }
            }
        }

        #endregion

    }
}
