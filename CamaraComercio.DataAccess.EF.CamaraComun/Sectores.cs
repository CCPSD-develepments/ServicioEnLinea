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
    public partial class Sectores
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    			public static string SectorId = @"SectorId";	
    	public static string Nombre = @"Nombre";	
    	public static string CiudadId = @"CiudadId";	
    	public static string Orden = @"Orden";	
    	public static string FechaModificacion = @"FechaModificacion";	
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int SectorId
        {
            get;
            set;
        }
    
        public virtual string Nombre
        {
            get;
            set;
        }
    
        public virtual int CiudadId
        {
            get { return _ciudadId; }
            set
            {
                if (_ciudadId != value)
                {
                    if (Ciudades != null && Ciudades.CiudadId != value)
                    {
                        Ciudades = null;
                    }
                    _ciudadId = value;
                }
            }
        }
        private int _ciudadId;
    
        public virtual Nullable<int> Orden
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

        #endregion

        #region Navigation Properties
    
        public virtual Ciudades Ciudades
        {
            get { return _ciudades; }
            set
            {
                if (!ReferenceEquals(_ciudades, value))
                {
                    var previousValue = _ciudades;
                    _ciudades = value;
                    FixupCiudades(previousValue);
                }
            }
        }
        private Ciudades _ciudades;

        #endregion

        #region Association Fixup
    
        private void FixupCiudades(Ciudades previousValue)
        {
            if (previousValue != null && previousValue.Sectores.Contains(this))
            {
                previousValue.Sectores.Remove(this);
            }
    
            if (Ciudades != null)
            {
                if (!Ciudades.Sectores.Contains(this))
                {
                    Ciudades.Sectores.Add(this);
                }
                if (CiudadId != Ciudades.CiudadId)
                {
                    CiudadId = Ciudades.CiudadId;
                }
            }
        }

        #endregion

    }
}
