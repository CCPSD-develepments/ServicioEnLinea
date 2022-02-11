using System;
using System.Collections.Generic;
using System.Linq;
using CamaraComercio.DataAccess.EF.SRM;
using CamaraComercio.WebServices.Helpers;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.WebServices.Nobox
{
    /// <summary>
    /// Metodos de acceso a datos, facilita la expocisión a los web services
    /// </summary>
    public class DataAccessMethods
    {
        /// <summary>
        /// Encapsulación del método que obtiene las actividades de una empresa, para facilitar exposición en el Web Service
        /// </summary>
        /// <param name="rnc"></param>
        /// <param name="cantidadRegistros"></param>
        /// <param name="camaraID"></param>
        /// <returns></returns>
        public static List<ActividadDTO> GetActividadPorEmpresa(string rnc, int cantidadRegistros, string camaraID)
        {
            var actividades = new List<ActividadDTO>();
            if (String.IsNullOrEmpty(camaraID))
            {
                var camaras = new Comun.CamarasController().FetchAllActivas();
                foreach (var camara in camaras)
                {
                    actividades = AccessDbActividades(camara.ID, rnc, cantidadRegistros);
                    if (actividades.Count() > 0) break;
                }
            }
            else
            {
                actividades = AccessDbActividades(camaraID, rnc, cantidadRegistros);
            }
            return actividades;
        }

        /// <summary>
        /// Encapsulación del método que busca empresas, para facilitar exposición en el Web Service
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tipoBusqueda"></param>
        /// <param name="camaraID"></param>
        /// <returns></returns>
        public static List<SociedadDTO> FindEmpresas(string query, TipoBusquedaSociedades tipoBusqueda, string camaraID)
        {
            var empresas = new List<SociedadDTO>();
            if (!String.IsNullOrEmpty(camaraID))
            {
                var camaras = new Comun.CamarasController().FetchAllActivas();
                foreach (var camara in camaras)
                {
                    empresas = AccessDbEmpresas(query, tipoBusqueda, camara.ID);
                    if (empresas.Count() > 0) break;
                }
            }
            else
            {
                empresas = AccessDbEmpresas(query, tipoBusqueda, camaraID);
            }
            return empresas;
        }

        /// <summary>
        /// Retorna todas las cámaras activas
        /// </summary>
        /// <returns></returns>
        public static List<CamaraDTO> GetAllCamaras()
        {
            var camaras = new Comun.CamarasController().FetchAllActivas()
                                    .Select(c => new CamaraDTO
                                    {
                                         CamaraID = c.ID,
                                        Descripcion = c.Nombre
                                    })
                                    .ToList();
            return camaras;
        }

        #region Acceso a la base de datos
        private static List<ActividadDTO> AccessDbActividades(string camaraID, string rnc, int cantidadTrans)
        {
            var rep = new SearchEmpresasRepository(camaraID);
            var result = new List<ActividadDTO>();
            rnc = rnc.FormatRnc();

            var trans = rep.FindSociedadTransacciones(rnc, cantidadTrans);
            trans.ForEach(a => result.Add(new ActividadDTO
            {
                Descripcion = a.Servicio,
                TipoActividad = String.Empty,
                Fecha = a.Fecha
            }));

            return result;
        }
        private static List<SociedadDTO> AccessDbEmpresas(string query, TipoBusquedaSociedades tipoBusqueda, string camaraID)
        {
            var searchResult = new List<SociedadDTO>();

            if (tipoBusqueda == TipoBusquedaSociedades.PorRnc)
                query = query.FormatRnc();

            var rep = new SearchEmpresasRepository(camaraID);
            var sociedades = rep.FindSociedades(query, tipoBusqueda);

            foreach (var sociedad in sociedades)
            {
                var registro = sociedad.SociedadesRegistros.FirstOrDefault();
                if (registro == null) continue;

                var resultUnit = new SociedadDTO
                {
                    ActividadNegocio = registro.Registros.ActividadNegocio,
                    Direccion = registro.Registros.Direcciones.ToString(),
                    Telefono = registro.Registros.Direcciones.TelefonoOficina,
                    SitioWeb = registro.Registros.Direcciones.SitioWeb,
                    FechaInicioOperaciones = registro.Registros.FechaInicioOperacion,
                    Nacionalidad = sociedad.NacionalidadDescripcion,
                    NombreSocial = sociedad.NombreSocial,
                    Siglas = sociedad.NombreSiglas,
                    RNC = sociedad.Rnc,
                    TipoSociedad = sociedad.TipoSociedad
                };

                searchResult.Add(resultUnit);
            }

            return searchResult;
        }
        #endregion
    }
}