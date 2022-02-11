using System;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Enumeración de estados para usuarios autorizados para manejar empresas en el website
    /// </summary>
    [Serializable]
    public enum EmpresaPorUsuarioEstado
    {
        ///<summary>
        /// Acceso Solicitado
        ///</summary>
        Solicitado = 1,
        /// <summary>
        /// Acceso Activo
        /// </summary>
        Activo = 2,
        /// <summary>
        /// Usuario desactivado por cambio de usuario padre
        /// </summary>
        DesactivadoPorCambioDeUsuario = 3,
        /// <summary>
        /// Usuario desactivo por cierre/disoluicón de Empresa
        /// </summary>
        DesactivadoPorCierre = 4,
        /// <summary>
        /// Acceso denegado
        /// </summary>
        Denegado = 5
    }
    
    /// <summary>
    /// Enumeración de tipos de mensajes para usuarios en el website
    /// </summary>
    [Serializable]
    public enum TipoMensaje
    {
        /// <summary>
        /// Mensaje para empresa
        /// </summary>
        Empresa = 0,
        /// <summary>
        /// Mensaje relacionada a un trámite/transacción
        /// </summary>
        Trámite = 1,
        /// <summary>
        /// Mensaje para un usuario
        /// </summary>
        Usuario = 2
    }
}