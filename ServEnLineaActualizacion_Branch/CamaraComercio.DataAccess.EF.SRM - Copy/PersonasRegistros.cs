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
    public partial class PersonasRegistros
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string NumeroRegistro = @"NumeroRegistro";
    public static string RegistroId = @"RegistroId";
    public static string PersonaId = @"PersonaId";
    public static string FechaModificacion = @"FechaModificacion";
    public static string EsValido = @"EsValido";
    public static string Migrada = @"Migrada";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int NumeroRegistro
        {
            get;
            set;
        }
    
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
    
        public virtual int PersonaId
        {
            get { return _personaId; }
            set
            {
                if (_personaId != value)
                {
                    if (Personas != null && Personas.PersonaId != value)
                    {
                        Personas = null;
                    }
                    _personaId = value;
                }
            }
        }
        private int _personaId;
    
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
    
        public virtual bool EsValido
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Migrada
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Personas Personas
        {
            get { return _personas; }
            set
            {
                if (!ReferenceEquals(_personas, value))
                {
                    var previousValue = _personas;
                    _personas = value;
                    FixupPersonas(previousValue);
                }
            }
        }
        private Personas _personas;
    
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

        #endregion

        #region Association Fixup
    
        private void FixupPersonas(Personas previousValue)
        {
            if (previousValue != null && previousValue.PersonasRegistros.Contains(this))
            {
                previousValue.PersonasRegistros.Remove(this);
            }
    
            if (Personas != null)
            {
                if (!Personas.PersonasRegistros.Contains(this))
                {
                    Personas.PersonasRegistros.Add(this);
                }
                if (PersonaId != Personas.PersonaId)
                {
                    PersonaId = Personas.PersonaId;
                }
            }
        }
    
        private void FixupRegistros(Registros previousValue)
        {
            if (previousValue != null && previousValue.PersonasRegistros.Contains(this))
            {
                previousValue.PersonasRegistros.Remove(this);
            }
    
            if (Registros != null)
            {
                if (!Registros.PersonasRegistros.Contains(this))
                {
                    Registros.PersonasRegistros.Add(this);
                }
                if (RegistroId != Registros.RegistroId)
                {
                    RegistroId = Registros.RegistroId;
                }
            }
        }

        #endregion

    }
}
