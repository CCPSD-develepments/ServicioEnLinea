using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public class PersonaFisicaController
    {
        public List<PersonasRegistros> ObteneByRegistroCamara(int noRegistro, string camaraId)
        {
            var conString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(conString);

            var qry = db.PersonasRegistros.Where(x => x.NumeroRegistro == noRegistro).ToList();
            return qry;
        }
        public List<PersonasRegistros> ObteneByRegistroIdCamara(int registroId, string camaraId)
        {
            var conString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(conString);

            var qry = db.PersonasRegistros.Where(x => x.RegistroId == registroId).ToList();
            return qry;
        }
        public List<PersonasRegistros> ObteneByPersonaIdCamara(int personaId, string camaraId)
        {
            var conString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(conString);

            var qry = db.PersonasRegistros.Where(x => x.PersonaId == personaId).ToList();
            return qry;
        }
        public PersonasRegistros ObtenerUnByRegistroIdCamara(int registroId, string camaraId)
        {
            var conString = Helpers.GetCamaraConnString(camaraId);
            var db = new CamaraSRMEntities(conString);

            var qry = db.PersonasRegistros.Where(x => x.RegistroId == registroId).ToList();
            return qry.FirstOrDefault();
        }

        public List<PersonasRegistros> ObtenerPersonaRegistroByDocumentoRnc(bool exacto, string cedulaRnc,string camaraId)
        {
            if (exacto)
            {
                var conString = Helpers.GetCamaraConnString(camaraId);
                var db = new CamaraSRMEntities(conString);

                List<PersonasRegistros> result = new List<PersonasRegistros>();

                var qryDocumento = db.PersonasRegistros.Where(x => x.Personas.Documento.Equals(cedulaRnc));
                foreach (var item in qryDocumento)
                {
                    result.Add(item);
                }
                var qryRnc = db.PersonasRegistros.Where(x => x.Personas.Rnc.Equals(cedulaRnc));
                foreach (var item in qryRnc)
                {
                    if (!result.Any(x=>x.PersonaId == item.PersonaId))
                        result.Add(item);
                }
                return result;
            }
            else
            {
                var conString = Helpers.GetCamaraConnString(camaraId);
                var db = new CamaraSRMEntities(conString);

                List<PersonasRegistros> result = new List<PersonasRegistros>();

                var qryDocumento = db.PersonasRegistros.Where(x => x.Personas.Documento.Equals(cedulaRnc));
                foreach (var item in qryDocumento)
                {
                    result.Add(item);
                }
                var qryRnc = db.PersonasRegistros.Where(x => x.Personas.Rnc.Equals(cedulaRnc));
                foreach (var item in qryRnc)
                {
                    if (!result.Any(x => x.PersonaId == item.PersonaId))
                        result.Add(item);
                }
                return result;
            }
        }
        public List<PersonasRegistros> ObtenerPersonaRegistroByRM(bool exacto, string rM, string camaraId)
        {
            if (exacto)
            {
                var conString = Helpers.GetCamaraConnString(camaraId);
                var db = new CamaraSRMEntities(conString);

                List<PersonasRegistros> result = new List<PersonasRegistros>();

                int registroMercantil = Convert.ToInt32(rM);

                var rmP = db.PersonasRegistros.Where(x => x.NumeroRegistro == registroMercantil);
                foreach (var item in rmP)
                {
                    result.Add(item);
                }
                return result;
            }
            else
            {
                var conString = Helpers.GetCamaraConnString(camaraId);
                var db = new CamaraSRMEntities(conString);

                List<PersonasRegistros> result = new List<PersonasRegistros>();

                int registroMercantil = Convert.ToInt32(rM);

                var rmP = db.PersonasRegistros.Where(x => x.NumeroRegistro == registroMercantil);
                foreach (var item in rmP)
                {
                    result.Add(item);
                }
                return result;
            }
        }

        public List<PersonasRegistros> ObtenerPersonaRegistroByName(bool exacto, string name, string camaraId)
        {
             string nameUpper = name.ToUpper();
            if (exacto)
            {
                var conString = Helpers.GetCamaraConnString(camaraId);
                var db = new CamaraSRMEntities(conString);

                List<PersonasRegistros> result = new List<PersonasRegistros>();
                List<String> parametros = nameUpper.Split(' ').ToList();
                List<PersonasRegistros> paraFiltrar = new List<PersonasRegistros>();

                foreach (var item in parametros)
                {
                    var rmP = db.PersonasRegistros.Where(x => x.Personas.PrimerNombre.Contains(item.ToLower()) || x.Personas.SegundoNombre.Contains(item.ToLower())
                        || x.Personas.PrimerApellido.Contains(item.ToLower()) || x.Personas.SegundoApellido.Contains(item.ToLower()));
                    foreach (var p in rmP)
                    {
                        string primerNombre = string.IsNullOrWhiteSpace(p.Personas.PrimerNombre) ? "" : p.Personas.PrimerNombre;
                        string segundoNombre = string.IsNullOrWhiteSpace(p.Personas.SegundoNombre) ? "" : p.Personas.SegundoNombre;
                        string PrimerApellido = string.IsNullOrWhiteSpace(p.Personas.PrimerApellido) ? "" : p.Personas.PrimerApellido;
                        string SegundoApellido = string.IsNullOrWhiteSpace(p.Personas.SegundoApellido) ? "" : p.Personas.SegundoApellido;
                        var nombreCompleto = string.Format("{0}{1}{2}{3}", primerNombre,
                            segundoNombre, PrimerApellido, SegundoApellido);

                        if (nombreCompleto.Replace(" ","").Contains(nameUpper.Replace(" ", "")))
                        {
                            paraFiltrar.Add(p);
                        }
                    }
                }

                foreach (var item in paraFiltrar)
                {
                    if (!result.Any(x => x.PersonaId == item.PersonaId))
                        result.Add(item);
                }
                return result;
            }
            else
            {
                var conString = Helpers.GetCamaraConnString(camaraId);
                var db = new CamaraSRMEntities(conString);

                List<PersonasRegistros> result = new List<PersonasRegistros>();
                List<String> parametros = nameUpper.Split(' ').ToList();
                List<PersonasRegistros> paraFiltrar = new List<PersonasRegistros>();

                foreach (var item in parametros)
                {
                    var rmP = db.PersonasRegistros.Where(x => x.Personas.PrimerNombre.Contains(item.ToLower()) || x.Personas.SegundoNombre.Contains(item.ToLower())
                        || x.Personas.PrimerApellido.Contains(item.ToLower()) || x.Personas.SegundoApellido.Contains(item.ToLower()));
                    foreach (var p in rmP)
                    {
                        string primerNombre = string.IsNullOrWhiteSpace(p.Personas.PrimerNombre) ? "" : p.Personas.PrimerNombre;
                        string segundoNombre = string.IsNullOrWhiteSpace(p.Personas.SegundoNombre) ? "" : p.Personas.SegundoNombre;
                        string PrimerApellido = string.IsNullOrWhiteSpace(p.Personas.PrimerApellido) ? "" : p.Personas.PrimerApellido;
                        string SegundoApellido = string.IsNullOrWhiteSpace(p.Personas.SegundoApellido) ? "" : p.Personas.SegundoApellido;
                        var nombreCompleto = string.Format("{0}{1}{2}{3}", primerNombre,
                            segundoNombre, PrimerApellido, SegundoApellido);

                         if (nombreCompleto.Contains(nameUpper.Replace(" ","")))
                         {
                             paraFiltrar.Add(p);
                         }                         
                    }
                }
               
                foreach (var item in paraFiltrar)
                {
                    if (!result.Any(x=> x.PersonaId == item.PersonaId))
                        result.Add(item);
                }
                return result;
            }
        }
    }
}
