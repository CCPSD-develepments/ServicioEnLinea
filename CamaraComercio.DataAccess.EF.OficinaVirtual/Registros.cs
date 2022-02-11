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
    public partial class Registros
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string RegistroId = @"RegistroId";	
    	public static string RegistroMercantil = @"RegistroMercantil";	
    	public static string FechaEmision = @"FechaEmision";	
    	public static string FechaVencimiento = @"FechaVencimiento";	
    	public static string CapitalSocial = @"CapitalSocial";	
    	public static string CapitalAutorizado = @"CapitalAutorizado";	
    	public static string CapitalPagado = @"CapitalPagado";	
    	public static string Activos = @"Activos";	
    	public static string BienesRaices = @"BienesRaices";	
    	public static string FechaInicioOperacion = @"FechaInicioOperacion";	
    	public static string EmpleadosMasculinos = @"EmpleadosMasculinos";	
    	public static string EmpleadosFemeninos = @"EmpleadosFemeninos";	
    	public static string EmpleadosTotal = @"EmpleadosTotal";	
    	public static string NombreComercial = @"NombreComercial";	
    	public static string RegistroNombreComercial = @"RegistroNombreComercial";	
    	public static string MarcaFabrica = @"MarcaFabrica";	
    	public static string RegistroMarcaFabrica = @"RegistroMarcaFabrica";	
    	public static string PatenteInvencion = @"PatenteInvencion";	
    	public static string RegistroPatenteInvencion = @"RegistroPatenteInvencion";	
    	public static string NombreOperador = @"NombreOperador";	
    	public static string ActividadNegocio = @"ActividadNegocio";	
    	public static string NumeroSocios = @"NumeroSocios";	
    	public static string TotalAcciones = @"TotalAcciones";	
    	public static string EsNuevoRegistro = @"EsNuevoRegistro";	
    	public static string DireccionCalle = @"DireccionCalle";	
    	public static string DireccionNumero = @"DireccionNumero";	
    	public static string DireccionCiudadId = @"DireccionCiudadId";	
    	public static string DireccionCiudad = @"DireccionCiudad";	
    	public static string DireccionSectorId = @"DireccionSectorId";	
    	public static string DireccionApartadoPostal = @"DireccionApartadoPostal";	
    	public static string DireccionTelefonoCasa = @"DireccionTelefonoCasa";	
    	public static string DireccionTelefonoOficina = @"DireccionTelefonoOficina";	
    	public static string DireccionExtension = @"DireccionExtension";	
    	public static string DireccionFax = @"DireccionFax";	
    	public static string DireccionEmail = @"DireccionEmail";	
    	public static string DireccionSitioWeb = @"DireccionSitioWeb";	
    	public static string NombreSolicitante = @"NombreSolicitante";	
    	public static string CargoSolicitante = @"CargoSolicitante";	
    	public static string GestorUsername = @"GestorUsername";	
    	public static string FechaSolicitud = @"FechaSolicitud";	
    	public static string EntidadActiva = @"EntidadActiva";	
    	public static string EsRenovacion = @"EsRenovacion";	
    	public static string TipoMonedaCapitalSocial = @"TipoMonedaCapitalSocial";	
    	public static string TipoMonedaCapitalAutorizado = @"TipoMonedaCapitalAutorizado";	
    	public static string TipoMonedaCapitalPagado = @"TipoMonedaCapitalPagado";	
    	public static string TipoMonedaActivos = @"TipoMonedaActivos";	
    	public static string TipoMonedaBienesRaices = @"TipoMonedaBienesRaices";	
    	public static string ActividadIdCIUU = @"ActividadIdCIUU";	
    	public static string ActividadCIUU = @"ActividadCIUU";	
    	public static string ActividadIdCIUU2 = @"ActividadIdCIUU2";	
    	public static string ActividadCIUU2 = @"ActividadCIUU2";	
    	public static string Id_Cierre_Fiscal = @"Id_Cierre_Fiscal";	
    	public static string FechaAsamblea1 = @"FechaAsamblea1";	
    	public static string FechaAsamblea2 = @"FechaAsamblea2";	
    	public static string SrmRegistroId = @"SrmRegistroId";	
    	public static string TransaccionId = @"TransaccionId";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int RegistroId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> RegistroMercantil
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaEmision
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaVencimiento
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalSocial
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalAutorizado
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> CapitalPagado
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> Activos
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> BienesRaices
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaInicioOperacion
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosMasculinos
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosFemeninos
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EmpleadosTotal
        {
            get;
            set;
        }
    
        public virtual string NombreComercial
        {
            get;
            set;
        }
    
        public virtual string RegistroNombreComercial
        {
            get;
            set;
        }
    
        public virtual string MarcaFabrica
        {
            get;
            set;
        }
    
        public virtual string RegistroMarcaFabrica
        {
            get;
            set;
        }
    
        public virtual string PatenteInvencion
        {
            get;
            set;
        }
    
        public virtual string RegistroPatenteInvencion
        {
            get;
            set;
        }
    
        public virtual string NombreOperador
        {
            get;
            set;
        }
    
        public virtual string ActividadNegocio
        {
            get;
            set;
        }
    
        public virtual Nullable<int> NumeroSocios
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TotalAcciones
        {
            get;
            set;
        }
    
        public virtual bool EsNuevoRegistro
        {
            get;
            set;
        }
    
        public virtual string DireccionCalle
        {
            get;
            set;
        }
    
        public virtual string DireccionNumero
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionCiudadId
        {
            get;
            set;
        }
    
        public virtual string DireccionCiudad
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionSectorId
        {
            get;
            set;
        }
    
        public virtual string DireccionApartadoPostal
        {
            get;
            set;
        }
    
        public virtual string DireccionTelefonoCasa
        {
            get;
            set;
        }
    
        public virtual string DireccionTelefonoOficina
        {
            get;
            set;
        }
    
        public virtual Nullable<int> DireccionExtension
        {
            get;
            set;
        }
    
        public virtual string DireccionFax
        {
            get;
            set;
        }
    
        public virtual string DireccionEmail
        {
            get;
            set;
        }
    
        public virtual string DireccionSitioWeb
        {
            get;
            set;
        }
    
        public virtual string NombreSolicitante
        {
            get;
            set;
        }
    
        public virtual string CargoSolicitante
        {
            get;
            set;
        }
    
        public virtual string GestorUsername
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaSolicitud
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> EntidadActiva
        {
            get;
            set;
        }
    
        public virtual bool EsRenovacion
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaCapitalSocial
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaCapitalAutorizado
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaCapitalPagado
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaActivos
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TipoMonedaBienesRaices
        {
            get;
            set;
        }
    
        public virtual string ActividadIdCIUU
        {
            get;
            set;
        }
    
        public virtual string ActividadCIUU
        {
            get;
            set;
        }
    
        public virtual string ActividadIdCIUU2
        {
            get;
            set;
        }
    
        public virtual string ActividadCIUU2
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Id_Cierre_Fiscal
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaAsamblea1
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaAsamblea2
        {
            get;
            set;
        }
    
        public virtual Nullable<int> SrmRegistroId
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TransaccionId
        {
            get { return _transaccionId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_transaccionId != value)
                    {
                        if (Transacciones != null && Transacciones.TransaccionId != value)
                        {
                            Transacciones = null;
                        }
                        _transaccionId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _transaccionId;

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
    
        public virtual ICollection<ReferenciasBancarias> ReferenciasBancarias
        {
            get
            {
                if (_referenciasBancarias == null)
                {
                    var newCollection = new FixupCollection<ReferenciasBancarias>();
                    newCollection.CollectionChanged += FixupReferenciasBancarias;
                    _referenciasBancarias = newCollection;
                }
                return _referenciasBancarias;
            }
            set
            {
                if (!ReferenceEquals(_referenciasBancarias, value))
                {
                    var previousValue = _referenciasBancarias as FixupCollection<ReferenciasBancarias>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupReferenciasBancarias;
                    }
                    _referenciasBancarias = value;
                    var newValue = value as FixupCollection<ReferenciasBancarias>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupReferenciasBancarias;
                    }
                }
            }
        }
        private ICollection<ReferenciasBancarias> _referenciasBancarias;
    
        public virtual ICollection<ReferenciasComerciales> ReferenciasComerciales
        {
            get
            {
                if (_referenciasComerciales == null)
                {
                    var newCollection = new FixupCollection<ReferenciasComerciales>();
                    newCollection.CollectionChanged += FixupReferenciasComerciales;
                    _referenciasComerciales = newCollection;
                }
                return _referenciasComerciales;
            }
            set
            {
                if (!ReferenceEquals(_referenciasComerciales, value))
                {
                    var previousValue = _referenciasComerciales as FixupCollection<ReferenciasComerciales>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupReferenciasComerciales;
                    }
                    _referenciasComerciales = value;
                    var newValue = value as FixupCollection<ReferenciasComerciales>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupReferenciasComerciales;
                    }
                }
            }
        }
        private ICollection<ReferenciasComerciales> _referenciasComerciales;
    
        public virtual ICollection<RegistrosActividades> RegistrosActividades
        {
            get
            {
                if (_registrosActividades == null)
                {
                    var newCollection = new FixupCollection<RegistrosActividades>();
                    newCollection.CollectionChanged += FixupRegistrosActividades;
                    _registrosActividades = newCollection;
                }
                return _registrosActividades;
            }
            set
            {
                if (!ReferenceEquals(_registrosActividades, value))
                {
                    var previousValue = _registrosActividades as FixupCollection<RegistrosActividades>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupRegistrosActividades;
                    }
                    _registrosActividades = value;
                    var newValue = value as FixupCollection<RegistrosActividades>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupRegistrosActividades;
                    }
                }
            }
        }
        private ICollection<RegistrosActividades> _registrosActividades;
    
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

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupTransacciones(Transacciones previousValue)
        {
            if (previousValue != null && previousValue.Registros.Contains(this))
            {
                previousValue.Registros.Remove(this);
            }
    
            if (Transacciones != null)
            {
                if (!Transacciones.Registros.Contains(this))
                {
                    Transacciones.Registros.Add(this);
                }
                if (TransaccionId != Transacciones.TransaccionId)
                {
                    TransaccionId = Transacciones.TransaccionId;
                }
            }
            else if (!_settingFK)
            {
                TransaccionId = null;
            }
        }
    
        private void FixupProductos(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Productos item in e.NewItems)
                {
                    item.Registros = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Productos item in e.OldItems)
                {
                    if (ReferenceEquals(item.Registros, this))
                    {
                        item.Registros = null;
                    }
                }
            }
        }
    
        private void FixupReferenciasBancarias(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ReferenciasBancarias item in e.NewItems)
                {
                    item.Registros = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ReferenciasBancarias item in e.OldItems)
                {
                    if (ReferenceEquals(item.Registros, this))
                    {
                        item.Registros = null;
                    }
                }
            }
        }
    
        private void FixupReferenciasComerciales(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ReferenciasComerciales item in e.NewItems)
                {
                    item.Registros = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ReferenciasComerciales item in e.OldItems)
                {
                    if (ReferenceEquals(item.Registros, this))
                    {
                        item.Registros = null;
                    }
                }
            }
        }
    
        private void FixupRegistrosActividades(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (RegistrosActividades item in e.NewItems)
                {
                    item.Registros = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RegistrosActividades item in e.OldItems)
                {
                    if (ReferenceEquals(item.Registros, this))
                    {
                        item.Registros = null;
                    }
                }
            }
        }

        #endregion

    }
}
