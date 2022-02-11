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
    public partial class RegistrosActividades
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string AtividadId = @"AtividadId";
    public static string RegistroId = @"RegistroId";
    public static string TipoActividadId = @"TipoActividadId";
    public static string FechaModificacion = @"FechaModificacion";
    public static string TipoActividadDescripcion = @"TipoActividadDescripcion";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int AtividadId
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
    
        public virtual int TipoActividadId
        {
            get;
            set;
        }
    
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
    
        public virtual string TipoActividadDescripcion
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

        #endregion

        #region Association Fixup
    
        private void FixupRegistros(Registros previousValue)
        {
            if (previousValue != null && previousValue.RegistrosActividades.Contains(this))
            {
                previousValue.RegistrosActividades.Remove(this);
            }
    
            if (Registros != null)
            {
                if (!Registros.RegistrosActividades.Contains(this))
                {
                    Registros.RegistrosActividades.Add(this);
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
