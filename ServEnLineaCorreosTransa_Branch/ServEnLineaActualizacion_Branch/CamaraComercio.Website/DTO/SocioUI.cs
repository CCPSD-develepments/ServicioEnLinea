using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Generic;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI'
    public static class SocioUI
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI'
    {

        /// <summary>
        /// </summary>
        public static void Save()
        {
        }

        private static List<Socios> Socios
        {
            get
            {
                //  get the customers collection from session
                var socios =
                    HttpContext.Current.Session["Socios"] as List<Socios>;

                //  load the customers on first access
                if (socios == null)
                {
                    socios = new List<Socios>();

                    //  cache the list
                    HttpContext.Current.Session["Socios"] = socios;
                }

                return socios;
            }
            set { HttpContext.Current.Session["Socios"] = value; }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Insert(Socios)'
        public static void Insert(Socios socio)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Insert(Socios)'
        {
            socio.Id = socio.Id == 0 ? Socios.Count + 1 : socio.Id;
            Socios.Add(socio);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Delete(Socios)'
        public static void Delete(Socios socio)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Delete(Socios)'
        {
            Socios.Remove(Socios.Find(x => x.Id == socio.Id && x.TipoRelacion == socio.TipoRelacion));
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Delete(int)'
        public static void Delete(int socioID)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Delete(int)'
        {
            Socios.RemoveAll(a => a.Id == socioID);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Update(Socios)'
        public static void Update(Socios socio)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Update(Socios)'
        {
            //simulate putting this record back into the database
            var socios = Socios.Where(x => x.Id == socio.Id).ToList();
            foreach (var currentSocio in socios)
            {
                var newSocio = Utils.Clone<Socios>(socio);
                newSocio.TipoRelacion = currentSocio.TipoRelacion;
                Socios.Insert(Socios.IndexOf(currentSocio), newSocio);
                Socios.Remove(currentSocio);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindAll(string)'
        public static IEnumerable<Socios> FindAll(string tipoRelacion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindAll(string)'
        {
            var socios = new List<Socios>();
            if (!String.IsNullOrEmpty(tipoRelacion))
                socios = Socios.Where(so => so.TipoRelacion == tipoRelacion.Trim()).ToList();

            return socios;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindAll()'
        public static IEnumerable<Socios> FindAll()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindAll()'
        {
            var socios = new List<Socios>();
            return Socios;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindDistinct()'
        public static IEnumerable<Socios> FindDistinct()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindDistinct()'
        {
            //Listado de socios
            var socios = Socios.GroupBy(a => a.Id).Select(so => so.First()).ToList();

            //Nombres de sectores y ciudades
            var dbComun = new DataAccess.EF.CamaraComun.CamaraComunEntities();
            var ciudadIds = socios.Select(c => c.DireccionCiudadId).Distinct().ToList();
            var ciudades = dbComun.Ciudades.Where(c => ciudadIds.Contains(c.CiudadId)).ToList();
            var sectoresIds = socios.Select(c => c.DireccionSectorId).Distinct().ToList();
            var sectores = dbComun.Sectores.Where(s => sectoresIds.Contains(s.SectorId)).ToList();

            foreach (var socio in socios)
            {
                var firstOrDefault = ciudades.Where(c => c.CiudadId == socio.DireccionCiudadId).FirstOrDefault();
                if (firstOrDefault != null)
                    socio.DireccionNombreCiudad = firstOrDefault.Nombre;
                var orDefault = sectores.Where(s => s.SectorId == socio.DireccionSectorId).FirstOrDefault();
                if (orDefault != null)
                    socio.DireccionNombreSector = orDefault.Nombre;
            }

            return socios.AsEnumerable();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindById(int, string)'
        public static Socios FindById(int socioId, string tipoRelacion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.FindById(int, string)'
        {
            return Socios.Find(x => x.Id == socioId && x.TipoRelacion == tipoRelacion);
        }

        /// <summary>
        /// Generacion de un string con todos los cargos de un socio
        /// </summary>
        /// <param name="socioId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
#pragma warning disable CS1573 // Parameter 'tipoSociedadId' has no matching param tag in the XML comment for 'SocioUI.CargosDelSocio(int, int)' (but other parameters do)
        public static String CargosDelSocio(int socioId, int tipoSociedadId)
#pragma warning restore CS1573 // Parameter 'tipoSociedadId' has no matching param tag in the XML comment for 'SocioUI.CargosDelSocio(int, int)' (but other parameters do)
        {
            var dbComun = new CamaraComercio.DataAccess.EF.CamaraComun.CamaraComunEntities();
            var cargos = dbComun.TipoSociedadSocio.Where(t => t.TipoSociedadId == tipoSociedadId).ToList(); 

            var sb = new StringBuilder();
            var socioActual = Socios.Where(x => x.Id == socioId);
            foreach (var soc in socioActual)
            {
                var cargoSocio = cargos.Where(c => c.TipoSocioId == soc.TipoRelacion).FirstOrDefault();
                if (cargoSocio != null)
                {
                    sb.Append(cargoSocio.Descripcion + ", ");
                }
            }
            return sb.ToString().Trim().TrimEnd(',');
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Update(Socios, string)'
        public static void Update(Socios socio, string tipoRelacion)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SocioUI.Update(Socios, string)'
        {
            //simulate putting this record back into the database
            List<Socios> socios = Socios.Where(x => x.Id == socio.Id && x.TipoRelacion == tipoRelacion).ToList();
            foreach (var currentSocio in socios)
            {
                var newSocio = Utils.Clone<Socios>(socio);
                newSocio.TipoRelacion = currentSocio.TipoRelacion;
                Socios.Insert(Socios.IndexOf(currentSocio), newSocio);
                Socios.Remove(currentSocio);
            }
        }


    }

}