using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CamaraComercio.DataAccess.OficinaVirtual;
using SubSonic;

namespace CamaraComercio.DataAccess.SRM
{
    public partial class SociedadesController
    {
        /// <summary>
        /// Obtiene todas las sociedades de la vista vEmpresas para la coleccion de RNCs
        /// </summary>
        /// <param name="usuario">Usuario para el que se solicita la lista de empresas</param>
        /// <param name="estado">Estado de la empresa (solicitada, activa, etc)</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewSumarioSociedadesCollection FetchAllSociedadesByUser(string usuario, EmpresaPorUsuarioEstado estado, int pagInicio = 1, int pagTamano = 15)
        {
            var colSociedades = new ViewSumarioSociedadesCollection();

            //Controllers
            var ctrlEmpresasPorUsuario = new EmpresasPorUsuarioController();
            var ctrlCamaras = new CamarasController();
            var ctrlSociedades = new SociedadesController();

            var idsEmpresasAsignadas = ctrlEmpresasPorUsuario.FetchByUserName(usuario, estado, pagInicio, pagTamano)
                .Select(emp => new { emp.NoRegistro, emp.CamaraID });

            //Camaras disponibles en el sistema
            var camaras = ctrlCamaras.FetchAllActivas();
            foreach (var camara in camaras)
            {
                var connString = Helpers.GetCamaraConnString(camara.Id);
                using (var scope = new SharedDbConnectionScope(connString))
                {
                    var noRegistroList = idsEmpresasAsignadas.Where(emp => emp.CamaraID == camara.Id).Select(emp => emp.NoRegistro).
                            ToList();

                    if (noRegistroList.Count > 0)
                    {
                        var col = new ViewSumarioSociedadesCollection();
                        var qry = new Query(ViewSumarioSociedades.Schema)
                            .WHERE(ViewSumarioSociedades.Columns.NumeroRegistro, Comparison.In, noRegistroList)
                            .ORDER_BY(ViewSumarioSociedades.Columns.EstatusId);
                        col.LoadAndCloseReader(qry.ExecuteReader());
                        foreach (var sociedad in col)
                        {
                            sociedad.CamaraID = camara.Id;
                        }
                        colSociedades.AddRange(col);
                    }
                }
            }
            
            return colSociedades;
        }

        /// <summary>
        /// Obtiene el count de todas las sociedades bajo el control de un usuario
        /// </summary>
        /// <param name="usuario">Usuario para el que se solicita la lista de empresas</param>
        /// <param name="estado">Estado de la empresa (solicitada, activa, etc)</param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchAllSociedadesByUser</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchAllSociedadesByUser</param>
        /// <returns></returns>
        public int CountSociedadesByUser(string usuario, EmpresaPorUsuarioEstado estado, int pagInicio = 0, int pagTamano = 15)
        {
            var qry = new Query(EmpresasPorUsuario.Schema)
                .WHERE(EmpresasPorUsuario.Columns.Usuario, usuario)
                .AND(EmpresasPorUsuario.Columns.Estado, (short)estado);
            return qry.GetRecordCount();
        }

        /// <summary>
        /// Obtiene el ID de una socieda a partir del numero de registro
        /// </summary>
        /// <param name="noRegistro"></param>
        /// <param name="camaraId"></param>
        /// <returns></returns>
        public int GetSociedadIdByRegistro(int noRegistro, string camaraId)
        {
            var sociedadId = 0;
            var col = new ViewSumarioSociedadesCollection();

            using (var scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                var qry = new Query(ViewSumarioSociedades.Schema)
                    .WHERE(ViewSumarioSociedades.Columns.NumeroRegistro, noRegistro);
                col.LoadAndCloseReader(qry.ExecuteReader());
            }

            if (col.Count > 0)
                sociedadId = col.First().SociedadId;
            return sociedadId;
        }

        /// <summary>
        /// Obtiene una sociedad verificando su RNC, No. de registro y Camara de Comercio
        /// Este método es utilizado para la solicitud de inclusión de nuevas empresas bajo un usuario
        /// </summary>
        /// <param name="noRegistro">No. de registro mercantil</param>
        /// <param name="rnc">RNC o Cédula (formateado)</param>
        /// <param name="camaraId">ID de la camara</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewSumarioSociedadesCollection FetchByRegistroRncAndCamara(string noRegistro, string rnc, string camaraId)
        {
            //Colecciones y controllers
            var colSociedades = new ViewSumarioSociedadesCollection();
            var ctrlCamaras = new CamarasController();
            var connString = Helpers.GetCamaraConnString(camaraId);

            using (var scope = new SharedDbConnectionScope(connString))
            {
                Query qry = new Query(ViewSumarioSociedades.Schema)
                    .WHERE(ViewSumarioSociedades.Columns.Rnc, rnc)
                    .AND(ViewSumarioSociedades.Columns.NumeroRegistro, noRegistro);
                colSociedades.LoadAndCloseReader(qry.ExecuteReader());
                foreach (ViewSumarioSociedades sociedad in colSociedades)
                {
                    sociedad.CamaraID = camaraId;
                }
            }

            return colSociedades;
        }

        /// <summary>
        /// Obtiene una sociedad verificando la cedula de los accionistas de una empresa y su registro
        /// Este método es utilizado para la solicitud de inclusión de nuevas empresas bajo un usuario
        /// </summary>
        /// <param name="noRegistro">No. de registro mercantil</param>
        /// <param name="documento">Cédula o pasasporte del accionista</param>
        /// <param name="camaraId">ID de la Cámara</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewPersonasEnSociedadesCollection FetchByAccionistas(string noRegistro, string documento, string camaraId)
        {
            var col = new ViewPersonasEnSociedadesCollection();
            var connString = Helpers.GetCamaraConnString(camaraId);

            using (var scope = new SharedDbConnectionScope(connString))
            {
                Query qry = new Query(ViewPersonasEnSociedades.Schema)
                    .WHERE(ViewPersonasEnSociedades.Columns.Documento, documento)
                    .AND(ViewPersonasEnSociedades.Columns.TipoRelacion, "A")
                    .AND(ViewPersonasEnSociedades.Columns.NumeroRegistro, noRegistro);
                col.LoadAndCloseReader(qry.ExecuteReader());
            }
            return col;
        }

        #region Sociedades

        /// <summary>
        /// Obtiene una Sociedad basado en el id de la sociedad según la cámara.
        /// </summary>
        /// <param name="sociedadId">Id de la Sociedad. Primary Key.</param>
        /// <param name="camaraId">ID de la Cámara. Representa la localidad de la Cámara.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewSumarioSociedadesCollection FetchBySociedadId(int sociedadId, string camaraId)
        {
            var col = new ViewSumarioSociedadesCollection();
            var connString = Helpers.GetCamaraConnString(camaraId);

            using (var scope = new SharedDbConnectionScope(connString))
            {
                Query qry = new Query(ViewSumarioSociedades.Schema)
                    .WHERE(ViewSumarioSociedades.Columns.SociedadId, sociedadId);

                col.LoadAndCloseReader(qry.ExecuteReader());
            }
            return col;
        }
        #endregion

        
    }
}