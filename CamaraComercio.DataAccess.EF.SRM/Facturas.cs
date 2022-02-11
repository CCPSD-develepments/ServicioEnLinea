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
    public partial class Facturas
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string FacturaId = @"FacturaId";
    public static string TipoComprobanteId = @"TipoComprobanteId";
    public static string RNC = @"RNC";
    public static string TransaccionId = @"TransaccionId";
    public static string Fecha = @"Fecha";
    public static string Ncf = @"Ncf";
    public static string Usuario = @"Usuario";
    public static string Estado = @"Estado";
    public static string Complementaria = @"Complementaria";
    public static string TipoNcf = @"TipoNcf";
    public static string TotalFactura = @"TotalFactura";
    public static string UsuarioId = @"UsuarioId";
    public static string Cajero = @"Cajero";
    public static string NombreCliente = @"NombreCliente";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int FacturaId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoComprobanteId
        {
            get;
            set;
        }
    
        public virtual string RNC
        {
            get;
            set;
        }
    
        public virtual int TransaccionId
        {
            get { return _transaccionId; }
            set
            {
                if (_transaccionId != value)
                {
                    if (Transacciones != null && Transacciones.TransaccionId != value)
                    {
                        Transacciones = null;
                    }
                    _transaccionId = value;
                }
            }
        }
        private int _transaccionId;
    
        public virtual System.DateTime Fecha
        {
            get;
            set;
        }
    
        public virtual string Ncf
        {
            get;
            set;
        }
    
        public virtual string Usuario
        {
            get;
            set;
        }
    
        public virtual int Estado
        {
            get;
            set;
        }
    
        public virtual bool Complementaria
        {
            get;
            set;
        }
    
        public virtual string TipoNcf
        {
            get;
            set;
        }
    
        public virtual decimal TotalFactura
        {
            get;
            set;
        }
    
        public virtual Nullable<int> UsuarioId
        {
            get;
            set;
        }
    
        public virtual string Cajero
        {
            get;
            set;
        }
    
        public virtual string NombreCliente
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Transacciones Transacciones
        {
            get { return _transacciones; }
            set
            {
                if (!ReferenceEquals(_transacciones, value))
                {
                    var previousValue = _transacciones;
                    _transacciones = value;
                    FixupTransacciones(previousValue);
                }
            }
        }
        private Transacciones _transacciones;
    
        public virtual ICollection<FormasPagos> FormasPagos
        {
            get
            {
                if (_formasPagos == null)
                {
                    var newCollection = new FixupCollection<FormasPagos>();
                    newCollection.CollectionChanged += FixupFormasPagos;
                    _formasPagos = newCollection;
                }
                return _formasPagos;
            }
            set
            {
                if (!ReferenceEquals(_formasPagos, value))
                {
                    var previousValue = _formasPagos as FixupCollection<FormasPagos>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupFormasPagos;
                    }
                    _formasPagos = value;
                    var newValue = value as FixupCollection<FormasPagos>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupFormasPagos;
                    }
                }
            }
        }
        private ICollection<FormasPagos> _formasPagos;
    
        public virtual ICollection<TransaccionDetalle> TransaccionDetalle
        {
            get
            {
                if (_transaccionDetalle == null)
                {
                    var newCollection = new FixupCollection<TransaccionDetalle>();
                    newCollection.CollectionChanged += FixupTransaccionDetalle;
                    _transaccionDetalle = newCollection;
                }
                return _transaccionDetalle;
            }
            set
            {
                if (!ReferenceEquals(_transaccionDetalle, value))
                {
                    var previousValue = _transaccionDetalle as FixupCollection<TransaccionDetalle>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTransaccionDetalle;
                    }
                    _transaccionDetalle = value;
                    var newValue = value as FixupCollection<TransaccionDetalle>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTransaccionDetalle;
                    }
                }
            }
        }
        private ICollection<TransaccionDetalle> _transaccionDetalle;
    
        public virtual ICollection<NotasCredito> NotasCredito
        {
            get
            {
                if (_notasCredito == null)
                {
                    var newCollection = new FixupCollection<NotasCredito>();
                    newCollection.CollectionChanged += FixupNotasCredito;
                    _notasCredito = newCollection;
                }
                return _notasCredito;
            }
            set
            {
                if (!ReferenceEquals(_notasCredito, value))
                {
                    var previousValue = _notasCredito as FixupCollection<NotasCredito>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupNotasCredito;
                    }
                    _notasCredito = value;
                    var newValue = value as FixupCollection<NotasCredito>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupNotasCredito;
                    }
                }
            }
        }
        private ICollection<NotasCredito> _notasCredito;

        #endregion

        #region Association Fixup
    
        private void FixupTransacciones(Transacciones previousValue)
        {
            if (previousValue != null && previousValue.Facturas.Contains(this))
            {
                previousValue.Facturas.Remove(this);
            }
    
            if (Transacciones != null)
            {
                if (!Transacciones.Facturas.Contains(this))
                {
                    Transacciones.Facturas.Add(this);
                }
                if (TransaccionId != Transacciones.TransaccionId)
                {
                    TransaccionId = Transacciones.TransaccionId;
                }
            }
        }
    
        private void FixupFormasPagos(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (FormasPagos item in e.NewItems)
                {
                    item.Facturas = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FormasPagos item in e.OldItems)
                {
                    if (ReferenceEquals(item.Facturas, this))
                    {
                        item.Facturas = null;
                    }
                }
            }
        }
    
        private void FixupTransaccionDetalle(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TransaccionDetalle item in e.NewItems)
                {
                    item.Facturas = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TransaccionDetalle item in e.OldItems)
                {
                    if (ReferenceEquals(item.Facturas, this))
                    {
                        item.Facturas = null;
                    }
                }
            }
        }
    
        private void FixupNotasCredito(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (NotasCredito item in e.NewItems)
                {
                    item.Facturas = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (NotasCredito item in e.OldItems)
                {
                    if (ReferenceEquals(item.Facturas, this))
                    {
                        item.Facturas = null;
                    }
                }
            }
        }

        #endregion

    }
}
