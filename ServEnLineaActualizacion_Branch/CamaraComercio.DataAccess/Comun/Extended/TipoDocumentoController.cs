using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SubSonic;

namespace CamaraComercio.DataAccess.Comun
{
    public partial class TipoDocumentoController
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TipoDocumentoCollection FetchTest()
        {
            var col = new TipoDocumentoCollection();
            var qry = new Query(TipoDocumento.Schema);
            qry.Top = "10";
            col.LoadAndCloseReader(qry.ExecuteReader());
            return col;
        }
    }
}
