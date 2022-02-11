using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SubSonic;

namespace CamaraComercio.DataAccess.OficinaVirtual
{
    public partial class TransaccionDocumentosController
    {
        /// <summary>
        /// Retorna el listaod de los Doc
        /// </summary>
        /// <param name="_transaccionID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TransaccionDocumentosCollection DocumentosEnviados(int? _transaccionID, int pagInicio = 0, int pagTamano = 15)
        {

            var col = new TransaccionDocumentosCollection();
            var qry = new SubSonic.Query(TransaccionDocumentos.Schema)
                .WHERE(TransaccionDocumentos.Columns.TransaccionId, _transaccionID);
                
            if (pagInicio > 0)
            {
                qry.PageIndex = pagInicio;
                qry.PageSize = pagTamano;
            }

            col.LoadAndCloseReader(qry.ExecuteReader());
            return col;
            
        }


        


        

    }
}
