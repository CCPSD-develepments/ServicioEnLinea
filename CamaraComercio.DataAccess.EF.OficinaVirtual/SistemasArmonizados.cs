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
    public partial class SistemasArmonizados
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string SistemaArmonizadoId = @"SistemaArmonizadoId";	
    	public static string Descripcion = @"Descripcion";	
    	public static string FechaModificacion = @"FechaModificacion";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual string SistemaArmonizadoId
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

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<Productos> Productos
        {
            get
            {
                if (_productos == null)
                {
                    var newCollection = new FixupCollection<Productos>();
                    newCollection.CollectionChanged += FixupProductos;
                    _productos = newCollection;
                }
                return _productos;
            }
            set
            {
                if (!ReferenceEquals(_productos, value))
                {
                    var previousValue = _productos as FixupCollection<Productos>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProductos;
                    }
                    _productos = value;
                    var newValue = value as FixupCollection<Productos>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProductos;
                    }
                }
            }
        }
        private ICollection<Productos> _productos;

        #endregion

        #region Association Fixup
    
        private void FixupProductos(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Productos item in e.NewItems)
                {
                    item.SistemasArmonizados = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Productos item in e.OldItems)
                {
                    if (ReferenceEquals(item.SistemasArmonizados, this))
                    {
                        item.SistemasArmonizados = null;
                    }
                }
            }
        }

        #endregion

    }
}
