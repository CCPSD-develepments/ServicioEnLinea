using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Controlador para la vista EmpresasPorUsuario
    /// </summary>
    public class EmpresasPorUsuarioController
    {
        CamaraWebsiteEntities db = new CamaraWebsiteEntities();

        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        public EmpresasPorUsuarioController()
        { }

        /// <summary>
        /// Obtiene las empresas asociadas a un usuario del website
        /// </summary>
        /// <param name="usuario">Usuario para el cual se quiere la lista de empresas</param>
        /// <param name="estado">Estado de la empresa</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <param name="fetchAll">Override para traer todos los registros independientemente de pagina o indice</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<EmpresasPorUsuario> FetchByUsername(string usuario, EmpresaPorUsuarioEstado estado, int pagInicio = 1, int pagTamano = 10, bool fetchAll = false)
        {


            var dbUsers = new CamaraComercio.DataAccess.EF.Membership.CamaraWebsiteAccountsEntities();
            var uHijos = dbUsers.ViewProfileProperties
                        .Where(c => c.UsuarioPadre == usuario).Select(c => c.UserName).ToList();

            ////determinar usuario padre
            //var uPadre = dbUsers.ViewProfileProperties.Where(c => c.UserName == usuario).Select(c => c.UsuarioPadre).FirstOrDefault();   

            //var pageIndex = pagInicio/pagTamano + 1;
            var qry = (from epu in db.EmpresasPorUsuario
                           //where (epu.Usuario == usuario || uHijos.Contains(epu.Usuario) || epu.Usuario == uPadre)
                       where (epu.Usuario == usuario || uHijos.Contains(epu.Usuario)) && epu.Estado == (short)estado 
                       orderby epu.CamaraID
                       select epu);

            return fetchAll 
                    ? qry
                    : qry.Skip(pagInicio).Take(pagTamano);
        }

        /// <summary>
        /// Retorna la solicitud de acceso de inclusion para la combinacion de No. de Registro, Usuario y Camara
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="noRegistro">No. de Registro Mercantil</param>
        /// <param name="camaraID">Camara para la cual se realiza la búsqueda</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<EmpresasPorUsuario> FetchByUserNoRegistroCamara(string usuario, int noRegistro, string camaraID, int pagInicio = 0, int pagTamano = 10)
        {
            var qry = (from epu in db.EmpresasPorUsuario
                       where epu.Usuario == usuario &&
                             epu.NoRegistro == noRegistro &&
                             epu.CamaraID == camaraID &&
                             epu.Estado == (short)EmpresaPorUsuarioEstado.Solicitado
                       select epu).ToList().Skip(pagInicio).Take(pagTamano).AsQueryable();
            return qry;
        }

        /// <summary>
        /// Cierra el acceso de todos los usuarios activos para la empresa y cámara especificada
        /// </summary>
        /// <param name="noRegistro"></param>
        /// <param name="camaraID"></param>
        /// <returns></returns>
        public bool CerrarAcceso(int noRegistro, string camaraID)
        {
            bool metodoExitoso;
            try
            {
                var qry = from epu in db.EmpresasPorUsuario
                          where epu.NoRegistro == noRegistro &&
                                epu.CamaraID == camaraID &&
                                epu.Estado == (short)EmpresaPorUsuarioEstado.Activo
                          select epu;

                foreach (var epu in qry)
                {
                    epu.Estado = (short)EmpresaPorUsuarioEstado.DesactivadoPorCierre;
                }
                db.SaveChanges();
                metodoExitoso = true;
            }
            catch (Exception)
            {
                metodoExitoso = false;
            }
            return metodoExitoso;
        }

        /// <summary>
        /// Obtiene el nombre del usuario actual con el control de una empresa
        /// </summary>
        /// <param name="noRegistro">No. de registro mercantil de la empresa</param>
        /// <param name="camaraId">Camara a la que el registro pertenece</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public string FetchEmpresaOwnerName(int noRegistro, string camaraId)
        {
            var qry = (from epu in db.EmpresasPorUsuario
                       where epu.NoRegistro == noRegistro &&
                             epu.CamaraID == camaraId &&
                             epu.Estado == (short)EmpresaPorUsuarioEstado.Activo
                       select epu.Usuario).FirstOrDefault();

            return qry;
        }

        /// <summary>
        /// Especifica si ya existe una solicitud para la combinación usuario/rnc en el sistema.
        /// Se utiliza para prevenir que se solicite un acceso de usuario cuando ya exista uno en proceso
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="noRegistro"></param>
        /// <param name="camaraID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public bool ExisteSolicitud(string usuario, int noRegistro, string camaraID)
        {
            var qry = (from epu in db.EmpresasPorUsuario
                       where epu.NoRegistro == noRegistro &&
                             epu.Usuario == usuario &&
                             epu.Estado == (short)EmpresaPorUsuarioEstado.Solicitado &&
                             epu.CamaraID == camaraID
                       select epu.ID).Count();

            return qry > 0;
        }

        /// <summary>
        /// Verifica si ya existe un usuario que administre esta empresa en el sistema
        /// </summary>
        /// <param name="noRegistro">Numero de Registro Mercantil</param>
        /// <returns>Retorna un string con el nombre del usuario. En caso de no existir retorna un string vacío</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public string ExisteUsuarioConEmpresa(int noRegistro)
        {
            var usuario = (from epu in db.EmpresasPorUsuario
                           where epu.NoRegistro == noRegistro &&
                                 epu.Estado == (short)EmpresaPorUsuarioEstado.Activo
                           select epu.Usuario).FirstOrDefault();
            return usuario;
        }

        /// <summary>
        /// Obtiene todas las empresas de un usuario a partir de su nombre de usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario logueado</param>
        /// <returns></returns>
        public IEnumerable<EmpresasPorUsuario> FetchAllByUserName(string userName)
        {
            var qry =  db.EmpresasPorUsuario.Where(c => c.Usuario == userName);

            qry.ToList().ForEach(a =>
            {
                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(a.CamaraID);
                var empresa = dbSrm.SociedadesRegistros.FirstOrDefault(s => s.NumeroRegistro == a.NoRegistro);
                if (empresa != null)
                {
                    var sociedad = empresa.Sociedades;
                    if (sociedad != null && !String.IsNullOrEmpty(sociedad.NombreSocial))
                        a.NombreEmpresa = sociedad.NombreSocial;
                }
            });

            return qry.AsEnumerable();
        }
    }
}
