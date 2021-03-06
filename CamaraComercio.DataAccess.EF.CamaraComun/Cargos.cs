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
    public partial class Cargos
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string CargoId = @"CargoId";	
    	public static string Descripcion = @"Descripcion";	
    	public static string FechaModificacion = @"FechaModificacion";	
    	public static string SiteVisible = @"SiteVisible";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int CargoId
        {
            get;
            set;
        }
    
        public virtual string Descripcion
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
    
        public virtual Nullable<bool> SiteVisible
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<TipoSociedadServicioCargo> TipoSociedadServicioCargo
        {
            get
            {
                if (_tipoSociedadServicioCargo == null)
                {
                    var newCollection = new FixupCollection<TipoSociedadServicioCargo>();
                    newCollection.CollectionChanged += FixupTipoSociedadServicioCargo;
                    _tipoSociedadServicioCargo = newCollection;
                }
                return _tipoSociedadServicioCargo;
            }
            set
            {
                if (!ReferenceEquals(_tipoSociedadServicioCargo, value))
                {
                    var previousValue = _tipoSociedadServicioCargo as FixupCollection<TipoSociedadServicioCargo>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTipoSociedadServicioCargo;
                    }
                    _tipoSociedadServicioCargo = value;
                    var newValue = value as FixupCollection<TipoSociedadServicioCargo>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTipoSociedadServicioCargo;
                    }
                }
            }
        }
        private ICollection<TipoSociedadServicioCargo> _tipoSociedadServicioCargo;

        #endregion

        #region Association Fixup
    
        private void FixupTipoSociedadServicioCargo(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TipoSociedadServicioCargo item in e.NewItems)
                {
                    item.Cargos = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TipoSociedadServicioCargo item in e.OldItems)
                {
                    if (ReferenceEquals(item.Cargos, this))
                    {
                        item.Cargos = null;
                    }
                }
            }
        }

        #endregion

    }
}
