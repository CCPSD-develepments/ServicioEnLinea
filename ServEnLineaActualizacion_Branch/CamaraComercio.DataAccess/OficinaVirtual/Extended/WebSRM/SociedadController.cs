using System;
using System.Collections.Generic;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class SociedadController
    {
        public SociedadCollection FetchByRegistroIds(List<int> listIds)
        {
            SociedadCollection col = new SociedadCollection();

            try
            {
                col = new Select().From(Sociedad.Schema).Where(Sociedad.RegistroIdColumn).
                    In(listIds).ExecuteAsCollection<SociedadCollection>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return col;
        }

        public Sociedad FetchByRegistroId(int Id)
        {
            Sociedad soc = new Sociedad();
            try
            {
                soc = new Select().From(Sociedad.Schema).Where(Sociedad.RegistroIdColumn).
                    IsEqualTo(Id).ExecuteSingle<Sociedad>();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return soc;
        }
    }
}