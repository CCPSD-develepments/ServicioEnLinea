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
    public partial class EstatusTransacciones
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string EstatusTransId = @"EstatusTransId";	
    	public static string EstatusTranNombre = @"EstatusTranNombre";	
    	public static string EstatusTransDescripcion = @"EstatusTransDescripcion";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int EstatusTransId
        {
            get;
            set;
        }
    
        public virtual string EstatusTranNombre
        {
            get;
            set;
        }
    
        public virtual string EstatusTransDescripcion
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<Transacciones> Transacciones
        {
            get
            {
                if (_transacciones == null)
                {
                    var newCollection = new FixupCollection<Transacciones>();
                    newCollection.CollectionChanged += FixupTransacciones;
                    _transacciones = newCollection;
                }
                return _transacciones;
            }
            set
            {
                if (!ReferenceEquals(_transacciones, value))
                {
                    var previousValue = _transacciones as FixupCollection<Transacciones>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTransacciones;
                    }
                    _transacciones = value;
                    var newValue = value as FixupCollection<Transacciones>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTransacciones;
                    }
                }
            }
        }
        private ICollection<Transacciones> _transacciones;
    
        public virtual ICollection<TransaccionesCanceladas> TransaccionesCanceladas
        {
            get
            {
                if (_transaccionesCanceladas == null)
                {
                    var newCollection = new FixupCollection<TransaccionesCanceladas>();
                    newCollection.CollectionChanged += FixupTransaccionesCanceladas;
                    _transaccionesCanceladas = newCollection;
                }
                return _transaccionesCanceladas;
            }
            set
            {
                if (!ReferenceEquals(_transaccionesCanceladas, value))
                {
                    var previousValue = _transaccionesCanceladas as FixupCollection<TransaccionesCanceladas>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTransaccionesCanceladas;
                    }
                    _transaccionesCanceladas = value;
                    var newValue = value as FixupCollection<TransaccionesCanceladas>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTransaccionesCanceladas;
                    }
                }
            }
        }
        private ICollection<TransaccionesCanceladas> _transaccionesCanceladas;

        #endregion

        #region Association Fixup
    
        private void FixupTransacciones(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Transacciones item in e.NewItems)
                {
                    item.EstatusTransacciones = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Transacciones item in e.OldItems)
                {
                    if (ReferenceEquals(item.EstatusTransacciones, this))
                    {
                        item.EstatusTransacciones = null;
                    }
                }
            }
        }
    
        private void FixupTransaccionesCanceladas(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TransaccionesCanceladas item in e.NewItems)
                {
                    item.EstatusTransacciones = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TransaccionesCanceladas item in e.OldItems)
                {
                    if (ReferenceEquals(item.EstatusTransacciones, this))
                    {
                        item.EstatusTransacciones = null;
                    }
                }
            }
        }

        #endregion

    }
}
