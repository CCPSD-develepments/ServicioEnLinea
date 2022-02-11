using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.Helpers
{
    public class SqlSiteMapProvider : StaticSiteMapProvider
    {
        private string connectionString;
        private string ProviderName;
        private string storedProcedure;
        private bool initialized = false;
        CamaraWebsiteEntities dbWebSite = new CamaraWebsiteEntities();

        public virtual bool IsInitialized { get { return initialized; } }

        private SiteMapNode rootNode;

        public override void Initialize(string name, NameValueCollection attributes)
        {
            if (!IsInitialized)
            {
                base.Initialize(name, attributes);

                initialized = true;
            }
        }


        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                if (rootNode == null)
                {
                    Clear();

                    var rootNodeDb = dbWebSite.SiteMap.FirstOrDefault(a => !a.ParentID.HasValue);

                    var valuesCollection = new NameValueCollection();
                    var siteMapKey = rootNodeDb.Url + rootNodeDb.Id.ToString();

                    rootNode = new SiteMapNode(this, siteMapKey, rootNodeDb.Url, rootNodeDb.Title, rootNodeDb.Descripcion,
                        rootNodeDb.Roles.Split(",".ToCharArray()).ToList(), valuesCollection, valuesCollection, String.Empty);

                    int rootId = rootNodeDb.Id;

                    AddChildren(rootNode, rootId);
                }

            }

            return rootNode;
        }

        public virtual SiteMapNode BuildSiteMap(int moduloId)
        {
            lock (this)
            {
                if (rootNode == null)
                {
                    Clear();

                    var rootNodeDb = dbWebSite.SiteMap.Where(a => a.ModuloId == moduloId).OrderBy(a => a.ParentID).FirstOrDefault();

                    var valuesCollection = new NameValueCollection();
                    var siteMapKey = rootNodeDb.Url + rootNodeDb.Id.ToString();

                    rootNode = new SiteMapNode(this, siteMapKey, rootNodeDb.Url, rootNodeDb.Title, rootNodeDb.Descripcion,
                        rootNodeDb.Roles.Split(",".ToCharArray()).ToList(), valuesCollection, valuesCollection, String.Empty);

                    int rootId = rootNodeDb.Id;

                    AddChildren(rootNode, rootId);
                }

            }

            return rootNode;
        }

        private void AddChildren(SiteMapNode rootNode, int rootId)
        {
            var result = dbWebSite.SiteMap.Where(a => a.ParentID == rootId).ToList();
            foreach (var siteMap in result)
            {
                var valuesCollection = new NameValueCollection();
                var siteMapKey = siteMap.Url + siteMap.Id.ToString();
                SiteMapNode childNode = new SiteMapNode(this,
                    siteMapKey, siteMap.Url, siteMap.Title, siteMap.Descripcion,
                    siteMap.Roles.Split(",".ToCharArray()).ToList(), valuesCollection, valuesCollection, String.Empty);

                AddNode(childNode, rootNode);

                AddChildren(childNode, siteMap.ParentID.Value);
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }

        public override SiteMapNode RootNode
        {
            get
            {
                return BuildSiteMap();
            }
        }

        protected override void Clear()
        {
            lock (this)
            {
                rootNode = null;
                base.Clear();
            }
        }

        

    }
}