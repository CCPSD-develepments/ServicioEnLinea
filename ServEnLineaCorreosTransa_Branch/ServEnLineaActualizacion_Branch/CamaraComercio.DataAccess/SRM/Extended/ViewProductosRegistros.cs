using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SubSonic;

namespace CamaraComercio.DataAccess.SRM
{
    [DataObject]
    public partial class ViewRegistrosProductosController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewRegistrosProductosCollection FetchbyRegistroId(int registroId, string camaraId)
        {
            using (SharedDbConnectionScope scope = new SharedDbConnectionScope(Helpers.GetCamaraConnString(camaraId)))
            {
                ViewRegistrosProductosCollection col =
                    new ViewRegistrosProductosCollection().Where(ViewRegistrosProductos.Columns.RegistroId, registroId).Load();

                return col;
            }

        }
    }
}
