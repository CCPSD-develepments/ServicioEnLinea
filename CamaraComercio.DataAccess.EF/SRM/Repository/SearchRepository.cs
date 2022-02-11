using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CamaraComercio.DataAccess.EF.SRM;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de búsqueda para sociedades
    /// </summary>
    [DataObject]
    public class SearchEmpresasRepository : Repository<SRM.Sociedades, SRM.CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraID">ID de la Cámara</param>
        public SearchEmpresasRepository(string camaraID) : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        { 
        }

        /// <summary>
        /// Realiza una búsqueda de sociedades por RNC, No. de Registro o Nombre
        /// </summary>
        /// <param name="qry">Valor de la búsqueda</param>
        /// <param name="tipoBusqueda">Tipo de la búsqueda (nombre, registro o RNC)</param>
        /// <returns></returns>
        public IEnumerable<SRM.Sociedades> FindSociedades(string qry, TipoBusquedaSociedades tipoBusqueda)
        {
            var dbSrm = this.Session;
            IEnumerable<SRM.Sociedades> col = null;

            switch (tipoBusqueda)
            {
                case TipoBusquedaSociedades.PorNombre:
                    col = dbSrm.Sociedades.Where(s => s.NombreSocial.StartsWith(qry));
                break;

                case TipoBusquedaSociedades.PorNoRegistro:
                    int noRegistro;
                    col = Int32.TryParse(qry, out noRegistro)
                              ? dbSrm.SociedadesRegistros.Where(sr => sr.NumeroRegistro == noRegistro).Select(
                                sr => sr.Sociedades)
                              : null;
                    break;

                case TipoBusquedaSociedades.PorRnc:
                    col = dbSrm.Sociedades.Where(s => s.Rnc == qry);
                    break;
            }

            return col;
        }

        /// <summary>
        /// Obtiene un listado de las transacciones asociadas a una sociedad/empresa. 
        /// </summary>
        /// <param name="rnc">Número de RNC</param>
        /// <param name="maximumRows">Cantidad máxima de registros a retornar</param>
        /// <returns></returns>
        public List<SRM.Transacciones> FindSociedadTransacciones(string rnc, int maximumRows)
        {
            var result = new List<SRM.Transacciones>();
            SRM.Sociedades empresa = null;

            var dbSrm = this.Session;
            empresa = dbSrm.Sociedades.FirstOrDefault(a => a.Rnc == rnc);
            if (empresa == null)
                return result;

            var registro = empresa.SociedadesRegistros.FirstOrDefault().NumeroRegistro;

            result.AddRange(dbSrm.Transacciones.Where(a => a.CustomInt2 == registro)
                .OrderByDescending(a=>a.Fecha).Take(maximumRows));

            return result;
        }

        /// <summary>
        /// Obtiene un listado de la relación entre Sociedades y Registros a partir de un rango de IDs
        /// </summary>
        /// <param name="ids">IDs a buscar</param>
        /// <returns></returns>
        public IEnumerable<SRM.SociedadesRegistros> FindSociedadesRegistros(List<Int32> ids)
        {
            var dbSrm = this.Session;
            return dbSrm.SociedadesRegistros.Where(s => ids.Contains(s.SociedadId));
        }
    }
}
