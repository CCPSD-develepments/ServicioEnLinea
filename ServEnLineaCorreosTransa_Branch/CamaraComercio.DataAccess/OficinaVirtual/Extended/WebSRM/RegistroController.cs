using System;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class RegistroController
    {
        /// <summary>
        /// Obtiene todos los registros de un gestor
        /// </summary>
        /// <param name="username"></param>
        /// <param name="includeCitas"></param>
        /// <returns></returns>
        public RegistroCollection FetchByGestor(string username, bool includeCitas)
        {
            RegistroCollection col = new RegistroCollection();
            try
            {
                if (!includeCitas)
                    col = new Select().From(Registro.Schema).Where(Registro.GestorUsernameColumn).
                        IsEqualTo(username).And(Registro.EntidadActivaColumn).IsEqualTo(true).
                        ExecuteAsCollection<RegistroCollection>();
                else
                    col = new Select().From(Registro.Schema).Where(Registro.GestorUsernameColumn).
                        IsEqualTo(username).ExecuteAsCollection<RegistroCollection>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return col;
        }

    }
}