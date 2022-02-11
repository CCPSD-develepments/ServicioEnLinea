using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.Membership
{
    /// <summary>
    /// Controlador para los objetos del Membership (directo)
    /// </summary>
    [DataObject()]
    public class MembershipController
    {
        /// <summary>
        /// Obtiene los usuarios autorizados por su username
        /// </summary>
        /// <param name="usuarioPadre">Nombre del usuario padre</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<CamaraAuthUsers> AuthUsersGetByUsername(string usuarioPadre)
        {
            var db = new CamaraWebsiteAccountsEntities();
            var dbComun = new CamaraComun.CamaraComunEntities();

            var result = from users in db.camara_Auth_Users
                         where users.UserName == usuarioPadre
                         select users;

            //Corre ahora nos falto campos :) falta la variable camara qeu no esta arriba
            //Fijate que aqui es que hace lo de la camara.//Compila ... ya entendi la problematica... ya es de datos el error deja ver...
            result.ToList().ForEach(a =>
            {
                a.NombreCamara = dbComun.Camaras.FirstOrDefault(cam => cam.ID == a.CamaraID).Nombre;

            });

            result.ToList().ForEach(a =>
            {
                var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(a.CamaraID);
                a.NombreEmpresa = dbSrm.SociedadesRegistros.FirstOrDefault(c => c.NumeroRegistro == c.NumeroRegistro).Sociedades.NombreSocial;

            });

            return result.AsEnumerable();

        }
    }
}
