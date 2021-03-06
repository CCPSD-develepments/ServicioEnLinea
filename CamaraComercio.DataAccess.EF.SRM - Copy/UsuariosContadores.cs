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
    public partial class UsuariosContadores
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string UsuarioContadorId = @"UsuarioContadorId";
    public static string UsuarioId = @"UsuarioId";
    public static string TipoTransacion = @"TipoTransacion";
    public static string Prioridad = @"Prioridad";
    public static string Contador = @"Contador";
    public static string Activo = @"Activo";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int UsuarioContadorId
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
    
        public virtual string TipoTransacion
        {
            get;
            set;
        }
    
        public virtual int Prioridad
        {
            get;
            set;
        }
    
        public virtual int Contador
        {
            get;
            set;
        }
    
        public virtual bool Activo
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
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
    
        private void FixupUsuarios(Usuarios previousValue)
        {
            if (previousValue != null && previousValue.UsuariosContadores.Contains(this))
            {
                previousValue.UsuariosContadores.Remove(this);
            }
    
            if (Usuarios != null)
            {
                if (!Usuarios.UsuariosContadores.Contains(this))
                {
                    Usuarios.UsuariosContadores.Add(this);
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
