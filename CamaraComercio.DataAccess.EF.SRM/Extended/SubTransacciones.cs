using System.Collections.Generic;

namespace CamaraComercio.DataAccess.EF.SRM
{
    ///<summary>
    ///</summary>
    public partial class SubTransacciones
    {
        ///<summary>
        ///</summary>
        public List<DocumentosTransacciones> DocumentosTransacciones
        {
            get { return _documentosTransacciones; }
            set { _documentosTransacciones = value; }
        }

        private List<DocumentosTransacciones> _documentosTransacciones = new List<DocumentosTransacciones>();
    }
}