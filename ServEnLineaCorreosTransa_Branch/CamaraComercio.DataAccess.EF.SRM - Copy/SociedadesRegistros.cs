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
    public partial class SociedadesRegistros
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string NumeroRegistro = @"NumeroRegistro";
    public static string SociedadId = @"SociedadId";
    public static string RegistroId = @"RegistroId";
    public static string bAdecuada = @"bAdecuada";
    public static string FechaModificacion = @"FechaModificacion";
    public static string EsValida = @"EsValida";
    public static string bTransformada = @"bTransformada";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int NumeroRegistro
        {
            get;
            set;
        }
    
        public virtual int SociedadId
        {
            get { return _sociedadId; }
            set
            {
                if (_sociedadId != value)
                {
                    if (Sociedades != null && Sociedades.SociedadId != value)
                    {
                        Sociedades = null;
                    }
                    _sociedadId = value;
                }
            }
        }
        private int _sociedadId;
    
        public virtual int RegistroId
        {
            get { return _registroId; }
            set
            {
                if (_registroId != value)
                {
                    if (Registros != null && Registros.RegistroId != value)
                    {
                        Registros = null;
                    }
                    _registroId = value;
                }
            }
        }
        private int _registroId;
    
        public virtual Nullable<bool> bAdecuada
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaModificacion
        {
            get;
            set;
        }
    
        public virtual System.Guid rowguid
        {
            get;
            set;
        }
    
        public virtual bool EsValida
        {
            get;
            set;
        }
    
        public virtual bool bTransformada
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Registros Registros
        {
            get { return _registros; }
            set
            {
                if (!ReferenceEquals(_registros, value))
                {
                    var previousValue = _registros;
                    _registros = value;
                    FixupRegistros(previousValue);
                }
            }
        }
        private Registros _registros;
    
        public virtual Sociedades Sociedades
        {
            get { return _sociedades; }
            set
            {
                if (!ReferenceEquals(_sociedades, value))
                {
                    var previousValue = _sociedades;
                    _sociedades = value;
                    FixupSociedades(previousValue);
                }
            }
        }
        private Sociedades _sociedades;

        #endregion

        #region Association Fixup
    
        private void FixupRegistros(Registros previousValue)
        {
            if (previousValue != null && previousValue.SociedadesRegistros.Contains(this))
            {
                previousValue.SociedadesRegistros.Remove(this);
            }
    
            if (Registros != null)
            {
                if (!Registros.SociedadesRegistros.Contains(this))
                {
                    Registros.SociedadesRegistros.Add(this);
                }
                if (RegistroId != Registros.RegistroId)
                {
                    RegistroId = Registros.RegistroId;
                }
            }
        }
    
        private void FixupSociedades(Sociedades previousValue)
        {
            if (previousValue != null && previousValue.SociedadesRegistros.Contains(this))
            {
                previousValue.SociedadesRegistros.Remove(this);
            }
    
            if (Sociedades != null)
            {
                if (!Sociedades.SociedadesRegistros.Contains(this))
                {
                    Sociedades.SociedadesRegistros.Add(this);
                }
                if (SociedadId != Sociedades.SociedadId)
                {
                    SociedadId = Sociedades.SociedadId;
                }
            }
        }

        #endregion

    }
}
