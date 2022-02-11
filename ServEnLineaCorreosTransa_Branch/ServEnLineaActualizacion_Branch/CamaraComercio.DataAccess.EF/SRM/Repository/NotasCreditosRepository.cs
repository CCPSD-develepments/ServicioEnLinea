using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public class NotasCreditosRepository : Repository<SRM.NotasCredito, SRM.CamaraSRMEntities>
    {
        
        public NotasCreditosRepository(string camaraID) :
            base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        {
        }

        public NotasCreditosRepository(CamaraSRMEntities context) : base(context) { }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<SRM.NotasCredito> GetFormasPorFactura(int facturaId)
        {
            var db = this.Session;
            return db.NotasCredito.Where(f => f.FacturaID == facturaId);
        }



        /// <summary>
        /// Actualiza una Una de cxredito
        /// 2021-05-10
        /// </summary>
        /// <param name="NotadId"></param>
        /// <returns></returns>
        public bool UpdateNotasCredito(int nNotadId)
        {
            var db = this.Session;
            var nNotas = db.NotasCredito.Where(r => r.NotaCreditoID.Equals(nNotadId)).FirstOrDefault();
            if (nNotas != null)
            {
                nNotas.Activa = false;

            }
            db.SaveChanges();
            return (true);
        }

    }
}
