using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CamaraComercio.DataAccess.EF
{
    /// <summary>
    /// Metodos Extendidos para acceso y transformacion de datos
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Convierte una coleccion IEnumerable en un DataTable
        /// </summary>
        /// <typeparam name="T">Entidad IEnumerable a convertir</typeparam>
        /// <param name="varlist">Listado de variables</param>
        /// <returns>Datatable (non-typed)</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist)
        {
            var dtReturn = new DataTable();
            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (var pi in oProps)
                    {
                        var colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                var dr = dtReturn.NewRow();
                foreach (var pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
}
