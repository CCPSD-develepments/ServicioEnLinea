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
    public partial class TipoSociedadSocio
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string Id = @"Id";	
    	public static string TipoSocioId = @"TipoSocioId";	
    	public static string TipoSociedadId = @"TipoSociedadId";	
    	public static string Descripcion = @"Descripcion";	
    	public static string RecibeCargo = @"RecibeCargo";	
    	public static string CantMinSocio = @"CantMinSocio";	
    	public static string CantMaxSocio = @"CantMaxSocio";	
    	public static string RecibeAcciones = @"RecibeAcciones";	
    	public static string GrupoValidacion = @"GrupoValidacion";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string TipoSocioId
        {
            get { return _tipoSocioId; }
            set
            {
                if (_tipoSocioId != value)
                {
                    if (TipoSocio != null && TipoSocio.TipoSocioId != value)
                    {
                        TipoSocio = null;
                    }
                    _tipoSocioId = value;
                }
            }
        }
        private string _tipoSocioId;
    
        public virtual int TipoSociedadId
        {
            get { return _tipoSociedadId; }
            set
            {
                if (_tipoSociedadId != value)
                {
                    if (TipoSociedad != null && TipoSociedad.TipoSociedadId != value)
                    {
                        TipoSociedad = null;
                    }
                    _tipoSociedadId = value;
                }
            }
        }
        private int _tipoSociedadId;
    
        public virtual string Descripcion
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> RecibeCargo
        {
            get;
            set;
        }
    
        public virtual Nullable<short> CantMinSocio
        {
            get;
            set;
        }
    
        public virtual Nullable<int> CantMaxSocio
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> RecibeAcciones
        {
            get;
            set;
        }
    
        public virtual Nullable<int> GrupoValidacion
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual TipoSocio TipoSocio
        {
            get { return _tipoSocio; }
            set
            {
                if (!ReferenceEquals(_tipoSocio, value))
                {
                    var previousValue = _tipoSocio;
                    _tipoSocio = value;
                    FixupTipoSocio(previousValue);
                }
            }
        }
        private TipoSocio _tipoSocio;
    
        public virtual TipoSociedad TipoSociedad
        {
            get { return _tipoSociedad; }
            set
            {
                if (!ReferenceEquals(_tipoSociedad, value))
                {
                    var previousValue = _tipoSociedad;
                    _tipoSociedad = value;
                    FixupTipoSociedad(previousValue);
                }
            }
        }
        private TipoSociedad _tipoSociedad;

        #endregion

        #region Association Fixup
    
        private void FixupTipoSocio(TipoSocio previousValue)
        {
            if (previousValue != null && previousValue.TipoSociedadSocio.Contains(this))
            {
                previousValue.TipoSociedadSocio.Remove(this);
            }
    
            if (TipoSocio != null)
            {
                if (!TipoSocio.TipoSociedadSocio.Contains(this))
                {
                    TipoSocio.TipoSociedadSocio.Add(this);
                }
                if (TipoSocioId != TipoSocio.TipoSocioId)
                {
                    TipoSocioId = TipoSocio.TipoSocioId;
                }
            }
        }
    
        private void FixupTipoSociedad(TipoSociedad previousValue)
        {
            if (previousValue != null && previousValue.TipoSociedadSocio.Contains(this))
            {
                previousValue.TipoSociedadSocio.Remove(this);
            }
    
            if (TipoSociedad != null)
            {
                if (!TipoSociedad.TipoSociedadSocio.Contains(this))
                {
                    TipoSociedad.TipoSociedadSocio.Add(this);
                }
                if (TipoSociedadId != TipoSociedad.TipoSociedadId)
                {
                    TipoSociedadId = TipoSociedad.TipoSociedadId;
                }
            }
        }

        #endregion

    }
}
