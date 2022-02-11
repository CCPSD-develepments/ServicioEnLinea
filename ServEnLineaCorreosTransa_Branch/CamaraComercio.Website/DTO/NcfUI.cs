using System.Collections.Generic;
using System.ComponentModel;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website
{
    [DataObject]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NcfUI'
    public static class NcfUI
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NcfUI'
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'NcfUI.FindAll()'
        public static IEnumerable<DataAccess.EF.CamaraComun.TiposNcf> FindAll()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'NcfUI.FindAll()'
        {
            var rep = new TiposNcfRepository();
            return rep.GetAll();
        }
    }
}