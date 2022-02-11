namespace CamaraComercio.Website.Operations
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OperationPage'
    public class OperationPage : SecurePage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OperationPage'
    {
        /// <summary>
        /// Verifica si el Codigo de la Camara donde se realizará la operación está disponible.
        /// </summary>
        /// <returns>Retorna <c>true</c> si el código está disponible, <c>false</c> si no lo está.</returns>
        public bool CamaraCodeIsAvailable()
        {
            return !string.IsNullOrEmpty(CamaraCode);
        }

        /// <summary>
        /// Retorna el Codigo de la Camara donde se realizará la operación si está disponible, de lo contratio retorna <c>string.Empty</c>.
        /// </summary>
        public string CamaraCode
        {
            get
            {
                if (!RouteData.Values.ContainsKey("camara")) return string.Empty;
                return RouteData.Values["camara"].ToString().ToUpperInvariant();
            }
        }

        /// <summary>
        /// Retorna el Nombre del ConnectionString para la Base de Datos de la Camara donde se realizará la operación si está disponible, de lo contratio retorna <c>string.Empty</c>.
        /// </summary>
        public string CamaraConnectionStringName
        {
            get
            {
                //IF => Se encuentra en diccionario de valores validos para Códigos de Camaras.
                //if (!true)
                //{
                //    return CamaraSection.Get().GetConnectionString(CamaraCode);
                //}
                return string.Empty;
            }
        }
    }
}