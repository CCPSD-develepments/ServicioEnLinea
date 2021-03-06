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
    public partial class TipoDocumento
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string TipoDocumentoId = @"TipoDocumentoId";	
    	public static string Nombre = @"Nombre";	
    	public static string Registrable = @"Registrable";	
    	public static string CostoOriginal = @"CostoOriginal";	
    	public static string CostoCopia = @"CostoCopia";	
    	public static string FechaModificacion = @"FechaModificacion";	
    	public static string Visible = @"Visible";	
    	public static string DocumentoOnBaseId = @"DocumentoOnBaseId";	
    	public static string DocumentoOnBaseDesc = @"DocumentoOnBaseDesc";	
    	public static string DescripcionWeb = @"DescripcionWeb";	
    	public static string SiteVisible = @"SiteVisible";	
    	public static string Descripcion = @"Descripcion";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int TipoDocumentoId
        {
            get;
            set;
        }
    
        public virtual string Nombre
        {
            get;
            set;
        }
    
        public virtual bool Registrable
        {
            get;
            set;
        }
    
        public virtual decimal CostoOriginal
        {
            get;
            set;
        }
    
        public virtual decimal CostoCopia
        {
            get;
            set;
        }
    
        public virtual System.DateTime FechaModificacion
        {
            get;
            set;
        }
    
        public virtual bool Visible
        {
            get;
            set;
        }
    
        public virtual int DocumentoOnBaseId
        {
            get;
            set;
        }
    
        public virtual string DocumentoOnBaseDesc
        {
            get;
            set;
        }
    
        public virtual string DescripcionWeb
        {
            get;
            set;
        }
    
        public virtual bool SiteVisible
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<ServicioDocumentoRequerido> ServicioDocumentoRequerido
        {
            get
            {
                if (_servicioDocumentoRequerido == null)
                {
                    var newCollection = new FixupCollection<ServicioDocumentoRequerido>();
                    newCollection.CollectionChanged += FixupServicioDocumentoRequerido;
                    _servicioDocumentoRequerido = newCollection;
                }
                return _servicioDocumentoRequerido;
            }
            set
            {
                if (!ReferenceEquals(_servicioDocumentoRequerido, value))
                {
                    var previousValue = _servicioDocumentoRequerido as FixupCollection<ServicioDocumentoRequerido>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupServicioDocumentoRequerido;
                    }
                    _servicioDocumentoRequerido = value;
                    var newValue = value as FixupCollection<ServicioDocumentoRequerido>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupServicioDocumentoRequerido;
                    }
                }
            }
        }
        private ICollection<ServicioDocumentoRequerido> _servicioDocumentoRequerido;
    
        public virtual ICollection<TipoReglaDocumento> TipoReglaDocumento
        {
            get
            {
                if (_tipoReglaDocumento == null)
                {
                    var newCollection = new FixupCollection<TipoReglaDocumento>();
                    newCollection.CollectionChanged += FixupTipoReglaDocumento;
                    _tipoReglaDocumento = newCollection;
                }
                return _tipoReglaDocumento;
            }
            set
            {
                if (!ReferenceEquals(_tipoReglaDocumento, value))
                {
                    var previousValue = _tipoReglaDocumento as FixupCollection<TipoReglaDocumento>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTipoReglaDocumento;
                    }
                    _tipoReglaDocumento = value;
                    var newValue = value as FixupCollection<TipoReglaDocumento>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTipoReglaDocumento;
                    }
                }
            }
        }
        private ICollection<TipoReglaDocumento> _tipoReglaDocumento;

        #endregion

        #region Association Fixup
    
        private void FixupServicioDocumentoRequerido(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ServicioDocumentoRequerido item in e.NewItems)
                {
                    item.TipoDocumento = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ServicioDocumentoRequerido item in e.OldItems)
                {
                    if (ReferenceEquals(item.TipoDocumento, this))
                    {
                        item.TipoDocumento = null;
                    }
                }
            }
        }
    
        private void FixupTipoReglaDocumento(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TipoReglaDocumento item in e.NewItems)
                {
                    item.TipoDocumento = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TipoReglaDocumento item in e.OldItems)
                {
                    if (ReferenceEquals(item.TipoDocumento, this))
                    {
                        item.TipoDocumento = null;
                    }
                }
            }
        }

        #endregion

    }
}
