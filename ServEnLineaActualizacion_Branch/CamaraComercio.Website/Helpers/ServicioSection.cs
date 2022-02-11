using System;
using System.Collections.Generic;
using System.Configuration;

namespace CamaraComercio.Website.Helpers
{
    /// <summary>
    /// Representa la sección de configuración de servicios dentro del Web.Config
    /// </summary>
    public class ServicioSection : ConfigurationSection
    {
        /// <summary>
        /// Colección de servicios
        /// </summary>
        [ConfigurationProperty("Servicios", IsDefaultCollection = false)]
        public ServiciosCollection Servicios
        {
            get
            {
                var serviciosCollection = (ServiciosCollection)base["Servicios"];
                return serviciosCollection;
            }
        }
    }
    
    /// <summary>
    /// Representa un elemento de configuración en el Web.Config para los servicios
    /// </summary>
    public class ServicioElement : ConfigurationElement
    {
#pragma warning disable CS0108 // 'ServicioElement.this[string]' hides inherited member 'ConfigurationElement.this[string]'. Use the new keyword if hiding was intended.
        ///<summary>
        /// Nombre de la propiedad
        ///</summary>
        ///<param name="propertyName"></param>
        public int this[string propertyName]
#pragma warning restore CS0108 // 'ServicioElement.this[string]' hides inherited member 'ConfigurationElement.this[string]'. Use the new keyword if hiding was intended.
        {
            get { return (Int32)base[propertyName]; }
        }

        ///<summary>
        /// ID Primario. Necesario para indexar la colección
        ///</summary>
        [ConfigurationProperty("id", IsRequired = true)]
        public Int32 Id
        {
            get { return (Int32)base["id"]; }
            set { base["id"] = value; }
        }

        /// <summary>
        /// ID del tipo de la sociedad. 
        /// </summary>
        [ConfigurationProperty("tipoSociedadId", IsRequired = true)]
        public Int32 TipoSociedadId
        {
            get { return (Int32)base["tipoSociedadId"]; }
            set { base["tipoSociedadId"] = value; }
        }

        /// <summary>
        /// Propiedad que indica si la empresa posee capital social o es opcional 
        /// (usada para empresas cuyos serviciosIDs varian dependiendo si tienen capital social o no)
        /// </summary>
        [ConfigurationProperty("tieneCapitalSocial", IsRequired = true)]
        public bool TieneCapitalSocial
        {
            get { return (Boolean) base["tieneCapitalSocial"]; }
            set { base["tieneCapitalSocial"] = value; }
        }

        /// <summary>
        /// Servicio utilizado para matriculación
        /// </summary>
        [ConfigurationProperty("servicioConstitucionId")]
        public int ServicioConstitucionId
        {
            get { return (Int32)base["servicioConstitucionId"]; }
            set { base["servicioConstitucionId"] = value; }
        }

        /// <summary>
        /// Servicio utilizado para modificaciones al registro mercantil
        /// </summary>
        [ConfigurationProperty("servicioModificacionId")]
        public int ServicioModificacionId
        {
            get { return (Int32)base["servicioModificacionId"]; }
            set { base["servicioModificacionId"] = value; }
        }

        /// <summary>
        /// Servicio utilizado para adecuar la empresa a la nueva ley
        /// </summary>
        [ConfigurationProperty("servicioAdecuacionId")]
        public int ServicioAdecuacionId
        {
            get { return (Int32)base["servicioAdecuacionId"]; }
            set { base["servicioAdecuacionId"] = value; }
        }

        /// <summary>
        /// Servicio utilizado para incluir la empresa bajo el control de oficina virtual
        /// </summary>
        [ConfigurationProperty("solicitudInclusionId")]
        public int SolicitudInclusionId
        {
            get { return (Int32)base["solicitudInclusionId"]; }
            set { base["solicitudInclusionId"] = value; }
        }

        /// <summary>
        /// Servicio de aumento del capital social 
        /// </summary>
        [ConfigurationProperty("servicioAumentoCapital")]
        public int ServicioAumentoCapitalId
        {
            get { return (Int32)base["servicioAumentoCapital"]; }
            set { base["servicioAumentoCapital"] = value; }
        }

        /// <summary>
        /// Servicio de renovación simple (sin modificación)
        /// </summary>
        [ConfigurationProperty("servicioRenovacionSimpleId")]
        public int ServicioRenovacionSimpleId
        {
            get { return (Int32)base["servicioRenovacionSimpleId"]; }
            set { base["servicioRenovacionSimpleId"] = value; }
        }

        /// <summary>
        /// Servicio de renovación con modificaciones
        /// </summary>
        [ConfigurationProperty("servicioRenovacionId")]
        public int ServicioRenovacionId
        {
            get { return (Int32)base["servicioRenovacionId"]; }
            set { base["servicioRenovacionId"] = value; }
        }

        /// <summary>
        /// Servicio de Transformación con Aumento
        /// </summary>
        [ConfigurationProperty("servicioTransformacionAumentoId")]
        public int ServicioTransformacionAumentoId
        {
            get { return (Int32)base["servicioTransformacionAumentoId"]; }
            set { base["servicioTransformacionAumentoId"] = value; }
        }

        /// <summary>
        /// Servicio de Transformación con reducción
        /// </summary>
        [ConfigurationProperty("servicioTransformacionReduccionId")]
        public int ServicioTransformacionReduccionId
        {
            get { return (Int32)base["servicioTransformacionReduccionId"]; }
            set { base["servicioTransformacionReduccionId"] = value; }
        }
    }

    /// <summary>
    /// Clase que representa la colección de servicios en el configuration section del web.config
    /// </summary>
    public class ServiciosCollection : ConfigurationElementCollection, IEnumerable<ServicioElement>
    {
        /// <summary>
        /// Constructor predeterminado
        /// </summary>
        public ServiciosCollection()
        {
            var servicio = (ServicioElement)CreateNewElement();
            if (servicio.TipoSociedadId > 0)
                Add(servicio);
        }

        /// <summary>
        /// Override a la función que define el collectionType
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        /// <summary>
        /// Override al constructor de un nuevo configuration element
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServicioElement();
        }

        /// <summary>
        /// Adición de un nuevo elemento a la colección
        /// </summary>
        /// <param name="servicio"></param>
        public void Add(ServicioElement servicio)
        {
            BaseAdd(servicio);
        }

        /// <summary>
        /// Adición de un nuevo nombre de elemento a la colección
        /// </summary>
        public new string AddElementName
        {
            get
            { return base.AddElementName; }

            set
            { base.AddElementName = value; }

        }

        /// <summary>
        /// Limpia el nombre del elemento
        /// </summary>
        public new string ClearElementName
        {
            get
            { return base.ClearElementName; }

            set
            { base.AddElementName = value; }

        }

        /// <summary>
        /// Cuenta la cantidad de registros en la colección
        /// </summary>
        public new int Count
        {
            get { return base.Count; }
        }

        /// <summary>
        /// Indexador
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ServicioElement this[int index]
        {
            get
            {
                return (ServicioElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Instanciador de un elemento por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        new public ServicioElement this[string Id]
        {
            get
            {
                var result = this.GetEnumerator();
                while (result.MoveNext())
                {
                    var p = (ServicioElement)result.Current;
                    if (p.Id == int.Parse(Id))
                        return p;
                }
                return (ServicioElement)BaseGet(Id);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServiciosCollection.CreateNewElement(string)'
        protected override ConfigurationElement CreateNewElement(string elementName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServiciosCollection.CreateNewElement(string)'
        {
            return new ServicioElement();
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServiciosCollection.BaseAdd(ConfigurationElement)'
        protected override void BaseAdd(ConfigurationElement element)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServiciosCollection.BaseAdd(ConfigurationElement)'
        {
            BaseAdd(element, false);
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ServiciosCollection.GetElementKey(ConfigurationElement)'
        protected override object GetElementKey(ConfigurationElement element)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ServiciosCollection.GetElementKey(ConfigurationElement)'
        {
            return ((ServicioElement)element).Id;
        }
        
        ///<summary>
        /// Limpia la colección
        ///</summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Remueve un elemento especifico (por referencia al objeto)
        /// </summary>
        /// <param name="servicio"></param>
        public void Remove(ServicioElement servicio)
        {
            if (BaseIndexOf(servicio) >= 0)
                BaseRemove(servicio.Id);
        }

        /// <summary>
        /// Remueve un elemento especifico (por el indice)
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Genera un enumerador para iterar por la colección de elementos
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<ServicioElement> GetEnumerator()
        {
            var count = base.Count;
            for (var i = 0; i < count; i++)
            {
                yield return BaseGet(i) as ServicioElement;
            }
        }
    }

}