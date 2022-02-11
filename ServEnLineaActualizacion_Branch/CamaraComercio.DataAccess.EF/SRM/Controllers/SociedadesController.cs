using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Controlador para Sociedades (del lado del SRM)
    /// </summary>
    public class SociedadesController
    {
        /// <summary>
        /// Obtiene todas las sociedades de la vista vEmpresas para la coleccion de RNCs
        /// </summary>
        /// <param name="usuario">Usuario para el que se solicita la lista de empresas</param>
        /// <param name="estado">Estado de la empresa (solicitada, activa, etc)</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <param name="fetchAll">Override para traer todos los rows, independientemente de la pagina o indice</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ViewSumarioSociedades> FetchAllSociedadesByUser(string usuario, OFV.EmpresaPorUsuarioEstado estado, 
            int pagInicio = 1, int pagTamano = 10, bool fetchAll = false)
        {
            //Variable de retorno
            var list = new List<ViewSumarioSociedades>();

            //Controladores
            var ctrlEmpresas = new OFV.EmpresasPorUsuarioController();
            var ctrlCamaras = new CamaraComun.CamarasController();

            //Ids de empresas en CamaraWebsite
            var idsEmpresasAsignadas = ctrlEmpresas.FetchByUsername(usuario, estado, pagInicio, pagTamano, fetchAll)
                .Select(emp => new { emp.NoRegistro, emp.CamaraID, emp.TransaccionId }).ToList();

            //Camaras disponibles en el sistema
            var camaras = from c in ctrlCamaras.FetchAll().ToList()
                          where idsEmpresasAsignadas.Select(emp => emp.CamaraID).Distinct().Contains(c.ID)
                          select c;

            foreach (var camara in camaras)
            {
                var camaraId = camara.ID;
                var connString = Helpers.GetCamaraConnString(camara.ID);
                var db = new CamaraSRMEntities(connString);

                var noRegistroList = idsEmpresasAsignadas.Where(emp => emp.CamaraID == camaraId).Select(emp => emp.NoRegistro).ToList();
                if (noRegistroList.Count() <= 0) continue;

                var qry = (from v in db.ViewSumarioSociedades
                           where noRegistroList.Contains(v.NumeroRegistro)
                           orderby v.EstatusId
                           select v).ToList();

                qry.ForEach(v => v.CamaraID = camaraId);
                list.AddRange(qry);
            }

            foreach (var item in list)
            {
                var noRegistro = item.NumeroRegistro;
                item.TransaccionId = idsEmpresasAsignadas.FirstOrDefault(a => a.NoRegistro == noRegistro).TransaccionId;
            }

            return list;
        }

        /// <summary>
        /// Obtiene todas las sociedades de la vista vEmpresas para la coleccion de RNCs
        /// </summary>
        /// <param name="usuario">Nombre del usuario</param>
        /// <param name="estado">Estado de la sociedad</param>
        /// <param name="pagInicio">Índice de la página en donde debe comenzar la búsqueda</param>
        /// <param name="pagTamano">Cantidad de registros a retornar por página</param>
        /// <returns>Retorna un DataTable que se puede filtrar en objetos de Telerik</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable FetchAllSociedadesByUserDt(string usuario, OFV.EmpresaPorUsuarioEstado estado, int pagInicio = 1, int pagTamano = 10)
        {
            var sociedades = FetchAllSociedadesByUser(usuario, estado, pagInicio, pagTamano, true);
            return sociedades.ToDataTable();
        }

        /// <summary>
        /// Obtiene el count de todas las sociedades bajo el control de un usuario
        /// </summary>
        /// <param name="usuario">Usuario para el que se solicita la lista de empresas</param>
        /// <param name="estado">Estado de la empresa (solicitada, activa, etc)</param>
        /// <param name="pagInicio">Placeholder para que el signature concuerde con el del método FetchAllSociedadesByUser</param>
        /// <param name="pagTamano">Placeholder para que el signature concuerde con el del método FetchAllSociedadesByUser</param>
        /// <returns></returns>
        public int CountSociedadesByUser(string usuario, OFV.EmpresaPorUsuarioEstado estado, int pagInicio = 0, int pagTamano = 10)
        {
            var ctrlEmpresas = new OFV.EmpresasPorUsuarioController();

            return ctrlEmpresas.FetchByUsername(usuario, estado, fetchAll: true).Count();
        }

        /// <summary>
        /// Obtiene el ID de una sociedad a partir del numero de registro
        /// </summary>
        /// <param name="noRegistro">Número del registro mercantil</param>
        /// <param name="camaraId">ID de la cámara</param>
        /// <returns></returns>
        public int GetSociedadIdByRegistro(int noRegistro, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);

            var qry = db.ViewSumarioSociedades.Where(v => v.NumeroRegistro == noRegistro).FirstOrDefault();
            var sociedadId = qry != null ? qry.SociedadId : 0;

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
        public List<ViewSumarioSociedades> FetchByRegistroRncAndCamara(int noRegistro, string rnc, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);
            var qry = (from v in db.ViewSumarioSociedades
                       where v.Rnc == rnc &&
                             v.NumeroRegistro == noRegistro
                       select v).ToList();
            qry.ForEach(v => v.CamaraID = camaraId);

            return qry;
        }

        /// <summary>
        /// Obtiene una sociedad a partir de su No. de registro y cámara de comercio
        /// Este método es utilizado para la solicitud de inclusión de nuevas empresas bajo un usuario
        /// </summary>
        /// <param name="noRegistro">No. de Registro Mercantil</param>
        /// <param name="camaraId">ID de la cámara donde se realiza la búsqueda</param>
        /// <returns></returns>
        public List<ViewSumarioSociedades> FetchByRegistroAndCamara(int noRegistro, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);
            var qry = (from v in db.ViewSumarioSociedades
                       where v.NumeroRegistro == noRegistro
                       select v).ToList();
            qry.ForEach(v => v.CamaraID = camaraId);
            return qry;
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
        public List<ViewPersonasEnSociedades> FetchByAccionistas(int noRegistro, string documento, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);

            var qry = from v in db.ViewPersonasEnSociedades
                      where (v.Documento == documento || v.Documento == documento.Replace("-","")) &&
                            v.TipoRelacion == "A" &&
                            v.NumeroRegistro == noRegistro
                      select v;

            return qry.ToList();
        }

        /// <summary>
        /// Obtiene una Sociedad basado en el id de la sociedad según la cámara.
        /// </summary>
        /// <param name="sociedadId">Id de la Sociedad. Primary Key.</param>
        /// <param name="camaraId">ID de la Cámara. Representa la localidad de la Cámara.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ViewSumarioSociedades> FetchBySociedadId(int sociedadId, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);
            return db.ViewSumarioSociedades.Where(v => v.SociedadId == sociedadId).ToList();
        }

        #region SociedadesRegistros
        /// <summary>
        /// Obtiene la informacion de una sociedad y los datos del registro mercantil mediante el numero de sociedad.
        /// </summary>
        /// <param name="sociedadId">Id de la Sociedad. Primary Key.</param>
        /// <param name="camaraId">ID de la Cámara. Representa la localidad de la Cámara.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public cvw_SociedadesRegistros FetchSociedadesRegistroBySociedadId(int sociedadId, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);
            return db.cvw_SociedadesRegistros.Where(a => a.SociedadId == sociedadId).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public cvw_SociedadesRegistros FetchSociedadesRegistroByRegistroId(int registroId, string camaraId)
        {
            var connString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(connString);
            return db.cvw_SociedadesRegistros.Where(a => a.RegistroId == registroId).FirstOrDefault();
        }

        /// <summary>
        /// Obtiene la informacion de una sociedad y los datos del registro mercantil mediante el numero de sociedad.
        /// </summary>
        /// <param name="registroId">Número del registro mercantil</param>
        /// <param name="camaraId">ID de la Cámara. Representa la localidad de la Cámara.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SociedadesRegistros FindRegistro(int registroId, string camaraId)
        {
            var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
            return
                db.SociedadesRegistros.Include("Sociedades").Include("Registros").FirstOrDefault(
                    a => a.RegistroId == registroId);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SociedadesRegistros FindNORegistro(int noRegistroId, string camaraId)
        {
            var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);
            return
                db.SociedadesRegistros.Include("Sociedades").Include("Registros").FirstOrDefault(
                    a => a.NumeroRegistro == noRegistroId);
        }

        #endregion

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public System.Data.DataTable FetchAllEntidadesC(string usuario, OFV.EmpresaPorUsuarioEstado estado, int pagInicio = 1, int pagTamano = 10)
        {
            var Entidades = FetchAllEntidades(usuario, estado, pagInicio, pagTamano, true);
            return Entidades.ToDataTable();
        }

        public int FetchAllEntidadesCount(string usuario, OFV.EmpresaPorUsuarioEstado estado, int pagInicio = 1, int pagTamano = 10)
        {
            var Entidades = FetchAllEntidades(usuario, estado, pagInicio, pagTamano, true);
            return Entidades.Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmpresasConAcceso> FetchAllEntidades(string usuario, OFV.EmpresaPorUsuarioEstado estado,
            int pagInicio = 1, int pagTamano = 10, bool fetchAll = false)
        {
            //Variable de retorno
            var list = new List<EmpresasConAcceso>();

            //Controladores
            var ctrlEmpresas = new OFV.EmpresasPorUsuarioController();
            var ctrlCamaras = new CamaraComun.CamarasController();

            //Ids de empresas en CamaraWebsite
            var idsEmpresasAsignadas = ctrlEmpresas.FetchByUsername(usuario, estado, pagInicio, pagTamano, fetchAll)
                .Select(emp => new { emp.NoRegistro, emp.CamaraID, emp.EsPersona, emp.TransaccionId }).OrderBy(x=> x.NoRegistro).ToList();

            //Camaras disponibles en el sistema
            var camaras = from c in ctrlCamaras.FetchAll().ToList()
                          where idsEmpresasAsignadas.Select(emp => emp.CamaraID).Distinct().Contains(c.ID)
                          select c;

            foreach (var empresaAsig in idsEmpresasAsignadas)
            {
                var connString = Helpers.GetCamaraConnString(empresaAsig.CamaraID);
                var db = new CamaraSRMEntities(connString);

                bool persona;
                persona = empresaAsig?.EsPersona ?? false;
                if (persona)
                {
                    var entidad = db.PersonasRegistros.FirstOrDefault(x => x.NumeroRegistro == empresaAsig.NoRegistro);
                    if (entidad != null)
                    {
                        var entidadAcceso = new EmpresasConAcceso()
                        {
                            PersonaId = entidad.PersonaId,
                            CamaraId = empresaAsig.CamaraID,
                            FechaConstitucion = entidad.Registros.FechaInicioOperacion,
                            NombreSocialPersona = entidad.Personas.PrimerNombre + " " + entidad.Personas.SegundoNombre +" "+ entidad.Personas.PrimerApellido+" "+ entidad.Personas.SegundoApellido,
                            NumeroRegistro = entidad.NumeroRegistro,
                            SociedadId = null,
                            TipoSociedadId = 7,
                            sufijo="7",
                            TransaccionId = empresaAsig.TransaccionId,
                            RegistroId = entidad.RegistroId,
                            EstadoId = null,
                            Estado = null
                        };
                        if (list.Any(x => x.RegistroId == entidad.RegistroId)) continue;
                        list.Add(entidadAcceso);
                    }
                }
                else
                {
                    var entidad = db.SociedadesRegistros.FirstOrDefault(x => x.NumeroRegistro == empresaAsig.NoRegistro);
                    if (entidad != null)
                    {
                        var entidadAcceso = new EmpresasConAcceso()
                        {
                            PersonaId = null,
                            CamaraId = empresaAsig.CamaraID,
                            FechaConstitucion = entidad.Sociedades.FechaConstitucion,
                            NombreSocialPersona = entidad.Sociedades.NombreSocial,
                            NumeroRegistro = entidad.NumeroRegistro,
                            SociedadId = entidad.SociedadId,
                            TipoSociedadId = entidad.Sociedades.TipoSociedadId,
                            sufijo = entidad.Sociedades.TipoSociedadId.ToString(),
                            TransaccionId = empresaAsig.TransaccionId,
                            RegistroId = entidad.RegistroId,
                            EstadoId = entidad.Sociedades.EstatusId,
                            Estado = entidad.Sociedades.EstatusDescripcion
                        };
                        if (list.Any(x => x.RegistroId == entidad.RegistroId)) continue;
                        list.Add(entidadAcceso);
                    }
                }
            }

            return list;
        }

    }

    public class EmpresasConAcceso
    {
        public string CamaraId { get; set; }

        public int NumeroRegistro { get; set; }

        public string NombreSocialPersona { get; set; }

        public int? TipoSociedadId { get; set; }

        public System.DateTime? FechaConstitucion { get; set; }

        public int? SociedadId { get; set; }

        public int? PersonaId { get; set; }

        public int? TransaccionId { get; set; }

        public int RegistroId { get; set; }
        public int? EstadoId { get; set; }
        public string Estado { get; set; }
        public string sufijo { get; set; }
    }
}
