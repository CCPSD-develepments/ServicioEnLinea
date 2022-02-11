using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF
{
    /// <summary>
    /// Asistentes y shortcuts para acceso a datos
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Define el string de conexion para subsonic en runtime
        /// </summary>
        public static string GetCamaraConnString(string camaraID)
        {
            string con = "";

            // Si es SDQ Utilizar conexion CamaraSRMEntitiesSDQ, de lo contrario utilizar CamaraSRMEntities (todas las camaras interior)
            if (camaraID == "SDQ")
                con = ConfigurationManager.ConnectionStrings["CamaraSRMEntitiesSDQ"].ConnectionString;
            else
                con = String.Format(ConfigurationManager.ConnectionStrings["CamaraSRMEntities"].ConnectionString, camaraID);

            return con;
            //return String.Format(ConfigurationManager.ConnectionStrings["CamaraSRMEntities"].ConnectionString, camaraID);
        }
    }

    /// <summary>
    /// Clase que asiste con el manejo de enumeraciones
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EnumHelper<T>
    {
        /// <summary>
        /// Obtiene la descripción del objeto seleccionado en una enumeración 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ObtenerDescripcion(int value)
        {
            var type = typeof(T);
            var name = Enum.GetName(type, value);
            if (String.IsNullOrEmpty(name))
                return "";

            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        }

        /// <summary>
        /// Obtiene la Enumaracion a partir de la descripcion.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Enum ObtenerEnumeracion(int value)
        {
            var type = typeof(T);
            var myEnum = (Enum)Activator.CreateInstance(type, value);
            return myEnum;
        }
    }
}
