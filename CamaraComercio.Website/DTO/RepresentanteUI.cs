using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.ComponentModel;

namespace CamaraComercio.Website
{
    [DataObject]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI'
    public static class RepresentanteUI
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI'
    {
        private static List<Personas> Representantes
        {
            get
            {
                //  get the customers collection from session
                var representantes =
                    HttpContext.Current.Session["Representantes"] as List<Personas>;

                //  load the customers on first access
                if (representantes == null)
                {
                    representantes = new List<Personas>();

                    //  cache the list
                    HttpContext.Current.Session["Representantes"] = representantes;
                }

                return representantes;
            }
            set { HttpContext.Current.Session["Representantes"] = value; }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Insert(Personas)'
        public static void Insert(Personas representante)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Insert(Personas)'
        {
            representante.PersonaId = representante.PersonaId == 0 ? Representantes.Count + 1 : representante.PersonaId;
            Representantes.Add(representante);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Delete(Personas)'
        public static void Delete(Personas representantes)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Delete(Personas)'
        {
            Representantes.Remove(Representantes.Find(x => x.PersonaId == representantes.PersonaId));
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Delete(int)'
        public static void Delete(int personaId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Delete(int)'
        {
            Representantes.Remove(Representantes.Find(x => x.PersonaId == personaId));
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Update(Personas)'
        public static void Update(Personas rep)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.Update(Personas)'
        {
            //simulate putting this record back into the database
            var representante = Representantes.Where(x => x.PersonaId == rep.PersonaId).FirstOrDefault();
            var newSocio = Utils.Clone<Personas>(rep);

            Representantes.Insert(Representantes.IndexOf(representante), newSocio);
            Representantes.Remove(representante);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.FindAll()'
        public static IEnumerable<Personas> FindAll()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'RepresentanteUI.FindAll()'
        {
            return Representantes;
        }
    }
}