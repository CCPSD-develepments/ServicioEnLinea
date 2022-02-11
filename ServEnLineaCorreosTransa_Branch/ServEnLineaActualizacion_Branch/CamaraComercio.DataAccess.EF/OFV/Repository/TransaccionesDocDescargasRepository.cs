using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    public class TransaccionesDocDescargasRepository : Repository<TransaccionesDocDescargas, CamaraWebsiteEntities>
    {
        public TransaccionesDocDescargas AddDocumentoDescarga(int transaccionId, string userName, byte[] docContent)
        {
            var data = new TransaccionesDocDescargas
                           {
                               DocContent = docContent,
                               FechaDescarga = DateTime.Now,
                               TransaccionId = transaccionId,
                               UserName = userName,
                           };

            Add(data);

            Save();

            return data;
        }
    }
}
