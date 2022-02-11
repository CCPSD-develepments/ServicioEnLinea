using System.ComponentModel;
using System.Linq;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class EmpresasPorUsuarioController
    {
        /// <summary>
        /// Obtiene las empresas asociadas a un usuario del website
        /// </summary>
        /// <param name="usuario">Usuario para el cual se quiere la lista de empresas</param>
        /// <param name="estado">Estado de la empresa</param>
        /// <param name="pagInicio">Para los registros paginados, indica la pagina a buscar en la BD</param>
        /// <param name="pagTamano">Para los registros paginados, indica el tamaño de las páginas</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmpresasPorUsuarioCollection FetchByUserName(string usuario, EmpresaPorUsuarioEstado estado, int pagInicio=1, int pagTamano=15)
        {
            var col = new EmpresasPorUsuarioCollection();
            var qry = new SubSonic.Query(EmpresasPorUsuario.Schema)
                .WHERE(EmpresasPorUsuario.Columns.Usuario, usuario)
                .WHERE(EmpresasPorUsuario.Columns.Estado, (short) estado);
            qry.PageIndex = pagInicio / pagTamano + 1;
            qry.PageSize = pagTamano;
            col.LoadAndCloseReader(qry.ExecuteReader());
            return col;
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
        public EmpresasPorUsuarioCollection FetchByUserNoRegistroCamara(string usuario, int noRegistro, string camaraID, int pagInicio=0, int pagTamano=15)
        {
            var col = new EmpresasPorUsuarioCollection();
            var qry = new SubSonic.Query(EmpresasPorUsuario.Schema)
                .WHERE(EmpresasPorUsuario.Columns.Usuario, usuario)
                .WHERE(EmpresasPorUsuario.Columns.NoRegistro, noRegistro)
                .WHERE(EmpresasPorUsuario.Columns.CamaraID, camaraID)
                .WHERE(EmpresasPorUsuario.Columns.Estado, (short) EmpresaPorUsuarioEstado.Solicitado);

            if (pagInicio > 0)
            {
                qry.PageIndex = pagInicio;
                qry.PageSize = pagTamano;
            }

            col.LoadAndCloseReader(qry.ExecuteReader());
            return col;
        }

        /// <summary>
        /// Obtiene el usuario actual con el control de una empresa
        /// </summary>
        /// <param name="noRegistro">No. de registro mercantil de la empresa</param>
        /// <param name="camaraId">Camara a la que el registro pertenece</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmpresasPorUsuario FetchEmpresaOwner(int noRegistro, string camaraId)
        {
            var qry = new SubSonic.Query(EmpresasPorUsuario.Schema)
                .WHERE(EmpresasPorUsuario.Columns.NoRegistro, noRegistro)
                .AND(EmpresasPorUsuario.Columns.Estado, (short) EmpresaPorUsuarioEstado.Activo)
                .AND(EmpresasPorUsuario.Columns.CamaraID, camaraId);
            var empresaUsuario = new EmpresasPorUsuario();
            empresaUsuario.LoadAndCloseReader(qry.ExecuteReader());
            return empresaUsuario;
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
            var qry = new Select(EmpresasPorUsuario.UsuarioColumn)
                    .From(EmpresasPorUsuario.Schema)
                    .Where(EmpresasPorUsuario.NoRegistroColumn).IsEqualTo(noRegistro)
                    .And(EmpresasPorUsuario.CamaraIDColumn).IsEqualTo(camaraId)
                    .And(EmpresasPorUsuario.EstadoColumn).IsEqualTo((short)EmpresaPorUsuarioEstado.Activo);
            return (string)qry.ExecuteScalar();
        }

        /// <summary>
        /// Especifica si ya existe una solicitud para la combinación usuario/rnc en el sistema.
        /// Se utiliza para prevenir que se solicite un acceso de usuario cuando ya exista uno en proceso
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="noRegistro"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public bool ExisteSolicitud(string usuario, int noRegistro)
        {
            int qry = new Select().From(EmpresasPorUsuario.Schema)
                .Where(EmpresasPorUsuario.NoRegistroColumn).IsEqualTo(noRegistro)
                .And(EmpresasPorUsuario.UsuarioColumn).IsEqualTo(usuario)
                .And(EmpresasPorUsuario.EstadoColumn).IsEqualTo((short) EmpresaPorUsuarioEstado.Solicitado)
                .GetRecordCount();
            
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
            string usuario = "";

            SqlQuery qry = new Select(EmpresasPorUsuario.Columns.Usuario)
                .From(EmpresasPorUsuario.Schema)
                .Where(EmpresasPorUsuario.NoRegistroColumn).IsEqualTo(noRegistro)
                .And(EmpresasPorUsuario.EstadoColumn).IsEqualTo((short) EmpresaPorUsuarioEstado.Activo);
            usuario = (string) qry.ExecuteScalar();

            return usuario;
        }
    }
}