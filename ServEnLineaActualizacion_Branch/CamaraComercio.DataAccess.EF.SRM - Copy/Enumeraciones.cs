using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Definicion de Estatus en los que puede estar una sociedad/empresa
    /// </summary>
    public enum SociedadesEstatudId
    {
        /// <summary>
        /// Sociedad Activa
        /// </summary>
        [Description("Activa")]
        Activa = 1,

        /// <summary>
        /// Sociedad Disuelta
        /// </summary>
        [Description("Disuelta")]
        Disuelta = 2,

        /// <summary>
        /// Sociedad en Cese Temporal
        /// </summary>
        [Description("Cese Temporal")]
        CeseTemporal = 3,

        /// <summary>
        /// Sociedad Fusionada con otra
        /// </summary>
        [Description("Fusionada")]
        Fusionada = 4,

        /// <summary>
        /// Sociedad Trasladada
        /// </summary>
        [Description("Trasladada")]
        Trasladada = 5
    }

    /// <summary>
    /// Tipos de búsqueda por los que se pueden realizar búsquedas contra el repositorio de empresas
    /// </summary>
    public enum TipoBusquedaSociedades
    {
        /// <summary>
        /// Búsqueda de sociedades por nombre
        /// </summary>
        [Description("Por Nombre")]
        PorNombre = 1,

        /// <summary>
        /// Búsqueda de sociedades por RNC o Cédula
        /// </summary>
        [Description("Por RNC o Cedula")]
        PorRnc = 2,

        /// <summary>
        /// Búsqueda de sociedades por No. de Registro Mercantil
        /// </summary>
        [Description("Por Numero de Registro Mercantil")]
        PorNoRegistro = 3
    }

    /// <summary>
    /// Rangos de cantida de empleados de una empresa
    /// </summary>
    public class RangosCantidadEmpresas
    {
        
        /// <summary>
        /// Diccionario de rangos para la cantidad de empleados
        /// </summary>
        public static Dictionary<Int32, String> Diccionario
        {
            get
            {
                return new Dictionary<int, string>()
                           {
                               {1, "1 - 5"},
                               {6, "6 - 10"},
                               {11, "11 - 15"},
                               {16, "16 - 60"},
                               {61, "61 - 200"},
                               {201, "201 - 500"},
                               {501, "501 - 1,000"},
                               {1001, "Más de 1000"}
                           };
            }
        }
    }

}