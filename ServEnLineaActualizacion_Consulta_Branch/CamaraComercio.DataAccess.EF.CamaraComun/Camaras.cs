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
    public partial class Camaras
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string ID = @"ID";	
    	public static string Nombre = @"Nombre";	
    	public static string GestionID = @"GestionID";	
    	public static string RNC = @"RNC";	
    	public static string Activa = @"Activa";	
    	public static string ActivaOnline = @"ActivaOnline";	
    	public static string HeaderImpresiones = @"HeaderImpresiones";	
    	public static string SecurityGroup = @"SecurityGroup";	
    	public static string Direccion = @"Direccion";	
    	public static string PathCertificado = @"PathCertificado";	
    	public static string Password = @"Password";	
    	public static string Reason = @"Reason";	
    	public static string SignContact = @"SignContact";	
    	public static string SignLocation = @"SignLocation";	
    	public static string Logo = @"Logo";	
    	public static string PuedeVenderOnline = @"PuedeVenderOnline";	
    	public static string VisanetMerchant = @"VisanetMerchant";	
    	public static string BraintreeMerchant = @"BraintreeMerchant";	
    	public static string NombreEncargado = @"NombreEncargado";	
    	public static string PuestoEncargado = @"PuestoEncargado";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual string ID
        {
            get;
            set;
        }
    
        public virtual string Nombre
        {
            get;
            set;
        }
    
        public virtual Nullable<int> GestionID
        {
            get;
            set;
        }
    
        public virtual string RNC
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Activa
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> ActivaOnline
        {
            get;
            set;
        }
    
        public virtual string HeaderImpresiones
        {
            get;
            set;
        }
    
        public virtual string SecurityGroup
        {
            get;
            set;
        }
    
        public virtual string Direccion
        {
            get;
            set;
        }
    
        public virtual string PathCertificado
        {
            get;
            set;
        }
    
        public virtual string Password
        {
            get;
            set;
        }
    
        public virtual string Reason
        {
            get;
            set;
        }
    
        public virtual string SignContact
        {
            get;
            set;
        }
    
        public virtual string SignLocation
        {
            get;
            set;
        }
    
        public virtual byte[] Logo
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> PuedeVenderOnline
        {
            get;
            set;
        }
    
        public virtual string VisanetMerchant
        {
            get;
            set;
        }
    
        public virtual string BraintreeMerchant
        {
            get;
            set;
        }
    
        public virtual string NombreEncargado
        {
            get;
            set;
        }
    
        public virtual string PuestoEncargado
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<ServiciosEnCamara> ServiciosEnCamara
        {
            get
            {
                if (_serviciosEnCamara == null)
                {
                    var newCollection = new FixupCollection<ServiciosEnCamara>();
                    newCollection.CollectionChanged += FixupServiciosEnCamara;
                    _serviciosEnCamara = newCollection;
                }
                return _serviciosEnCamara;
            }
            set
            {
                if (!ReferenceEquals(_serviciosEnCamara, value))
                {
                    var previousValue = _serviciosEnCamara as FixupCollection<ServiciosEnCamara>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupServiciosEnCamara;
                    }
                    _serviciosEnCamara = value;
                    var newValue = value as FixupCollection<ServiciosEnCamara>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupServiciosEnCamara;
                    }
                }
            }
        }
        private ICollection<ServiciosEnCamara> _serviciosEnCamara;

        #endregion

        #region Association Fixup
    
        private void FixupServiciosEnCamara(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ServiciosEnCamara item in e.NewItems)
                {
                    item.Camaras = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ServiciosEnCamara item in e.OldItems)
                {
                    if (ReferenceEquals(item.Camaras, this))
                    {
                        item.Camaras = null;
                    }
                }
            }
        }

        #endregion

    }
}
