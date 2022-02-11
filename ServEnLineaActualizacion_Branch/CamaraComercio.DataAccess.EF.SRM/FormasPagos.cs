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
    public partial class FormasPagos
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string Id = @"Id";
    public static string FacturaId = @"FacturaId";
    public static string FechaCuadre = @"FechaCuadre";
    public static string FormaPago = @"FormaPago";
    public static string Valor = @"Valor";
    public static string Tasa = @"Tasa";
    public static string Referencia = @"Referencia";
    public static string NoTarjeta = @"NoTarjeta";
    public static string Divisa = @"Divisa";
    public static string ValorEntregado = @"ValorEntregado";
    public static string ValorDevuelto = @"ValorDevuelto";
    public static string Nota = @"Nota";
    public static string BancoId = @"BancoId";
    public static string BancoDescripcion = @"BancoDescripcion";
    public static string ConfirmacionPagoTarjeta = @"ConfirmacionPagoTarjeta";
    public static string NumeroNotaCredito = @"NumeroNotaCredito";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual int FacturaId
        {
            get { return _facturaId; }
            set
            {
                if (_facturaId != value)
                {
                    if (Facturas != null && Facturas.FacturaId != value)
                    {
                        Facturas = null;
                    }
                    _facturaId = value;
                }
            }
        }
        private int _facturaId;
    
        public virtual System.DateTime FechaCuadre
        {
            get;
            set;
        }
    
        public virtual string FormaPago
        {
            get;
            set;
        }
    
        public virtual decimal Valor
        {
            get;
            set;
        }
    
        public virtual decimal Tasa
        {
            get;
            set;
        }
    
        public virtual string Referencia
        {
            get;
            set;
        }
    
        public virtual string NoTarjeta
        {
            get;
            set;
        }
    
        public virtual decimal Divisa
        {
            get;
            set;
        }
    
        public virtual decimal ValorEntregado
        {
            get;
            set;
        }
    
        public virtual decimal ValorDevuelto
        {
            get;
            set;
        }
    
        public virtual string Nota
        {
            get;
            set;
        }
    
        public virtual Nullable<int> BancoId
        {
            get;
            set;
        }
    
        public virtual string BancoDescripcion
        {
            get;
            set;
        }
    
        public virtual string ConfirmacionPagoTarjeta
        {
            get;
            set;
        }
    
        public virtual Nullable<int> NumeroNotaCredito
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Facturas Facturas
        {
            get { return _facturas; }
            set
            {
                if (!ReferenceEquals(_facturas, value))
                {
                    var previousValue = _facturas;
                    _facturas = value;
                    FixupFacturas(previousValue);
                }
            }
        }
        private Facturas _facturas;

        #endregion

        #region Association Fixup
    
        private void FixupFacturas(Facturas previousValue)
        {
            if (previousValue != null && previousValue.FormasPagos.Contains(this))
            {
                previousValue.FormasPagos.Remove(this);
            }
    
            if (Facturas != null)
            {
                if (!Facturas.FormasPagos.Contains(this))
                {
                    Facturas.FormasPagos.Add(this);
                }
                if (FacturaId != Facturas.FacturaId)
                {
                    FacturaId = Facturas.FacturaId;
                }
            }
        }

        #endregion

    }
}
