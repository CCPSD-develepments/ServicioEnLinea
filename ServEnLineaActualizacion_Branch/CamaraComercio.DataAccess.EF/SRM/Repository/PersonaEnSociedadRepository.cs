using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio para la vista ViewPersonasEnSociedades. Usado para búsquedas
    /// </summary>
    public class PersonaEnSociedadRepository: EF.Repository<ViewPersonasEnSociedades, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraID">ID de la Cámara</param>
        public PersonaEnSociedadRepository(string camaraID) : 
            base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        {
        }

        /// <summary>
        /// Retorna todas las empresas para la cual el socioID pasado es accionista
        /// </summary>
        /// <param name="socioId">ID Del Socio</param>
        /// <returns></returns>
        public IEnumerable<PersonaSociedadDto> ListEmpresasAccionistas(int socioId)
        {
            var db = this.Session;
            var col = db.ViewPersonasEnSociedades.Where(v => v.SocioId == socioId).ToList();

                var grouped = col.ToList()
                .GroupBy(c => new {c.NombreSocial, c.NumeroRegistro, c.SocioId, c.FechaConstitucion, c.Rnc, c.TipoSociedadId})
                .Select(g => new PersonaSociedadDto()
                                 {
                                     NombreSocial = g.Key.NombreSocial,
                                     NumeroRegistro = g.Key.NumeroRegistro,
                                     SocioId = g.Key.SocioId,
                                     FechaConstitucion = g.Key.FechaConstitucion,
                                     Rnc = g.Key.Rnc,
                                     TipoSociedadId = g.Key.TipoSociedadId,
                                     RegistroRelacion = GetTiposAccionistaAsString(col, g.Key.SocioId, g.Key.NumeroRegistro)
                                 });

            return grouped;
        }

        /// <summary>
        /// Obtiene todos los tipos de accionistas para una persona en forma de strings
        /// </summary>
        /// <param name="col">Colección de registros de un usuario como accionista</param>
        /// <param name="socioId">Id del socio</param>
        /// <returns></returns>
        private static string GetTiposAccionistaAsString(IEnumerable<ViewPersonasEnSociedades> col, int socioId, int numeroRegistro)
        {
            var sb = new StringBuilder();
            var tiposRelIds = col.Where(s => s.SocioId == socioId).Where(s=>s.NumeroRegistro.Equals(numeroRegistro)).Select(s => s.TipoRelacion).ToList();
            var descTipoSocios =
                    new CamaraComun.CamaraComunEntities().TipoSocio
                    .Where(t => tiposRelIds.Contains(t.TipoSocioId)).Select(
                    t => t.Descripcion);
            
            foreach (var tipo in descTipoSocios)
            {
                sb.Append(tipo + ", ");
            }
            return sb.ToString().Trim().TrimEnd(',');
        }
    }

    /// <summary>
    /// Repositorio del tipo PersonaSociedadDto que facilita el despliegue en el UI
    /// </summary>
    public class PersonaSociedadDtoRepository: Repository<PersonaSociedadDto, CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado
        /// </summary>
        /// <param name="camaraID">ID de la Cámara</param>
        public PersonaSociedadDtoRepository(string camaraID) : 
            base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        {
        }

        /// <summary>
        /// Lista las empresas en las cuales una persona es accionista
        /// </summary>
        /// <param name="socioId">ID de la persona para la que se realiza la búsqueda</param>
        /// <returns></returns>
        public IEnumerable<PersonaSociedadDto> ListEmpresasAccionistas(int socioId)
        {
            var db = this.Session;
            var registros = db.PersonasRegistros
                            .Where(p => p.PersonaId == socioId)
                            .Select(c => c.Registros);

            var test = from reg in registros
                       select new
                                  {
                                      reg.RegistroId, 
                                      reg.NombreComercial
                                  };


            return null;
        }
    }

    /// <summary>
    /// Clase que facilita el despliegue de informaciones de una persona a nivel de UI (POCO)
    /// </summary>
    public class PersonaSociedadDto
    {
        /// <summary>
        /// ID del Registro
        /// </summary>
        public int RegistroId { get; set; }

        /// <summary>
        /// ID de la Sociedad
        /// </summary>
        public int SociedadId { get; set; }

        /// <summary>
        /// Numero de registro mercantil
        /// </summary>
        public int NumeroRegistro{ get; set; }
        
        /// <summary>
        /// ID de la persona
        /// </summary>
        public int SocioId { get; set; }
        
        /// <summary>
        /// Tipo de sociedad
        /// </summary>
        public int? TipoSociedadId { get; set; }
        
        /// <summary>
        /// Fecha de constitución de la sociedad/empresa
        /// </summary>
        public DateTime? FechaConstitucion { get; set; }
        
        /// <summary>
        /// ID del tipo de socio
        /// </summary>
        public string TipoSocio { get; set; }
        
        /// <summary>
        /// Descripción del ID del tipo de socio
        /// </summary>
        public string RegistroRelacion{ get; set; }
        
        /// <summary>
        /// Nombre social de la empresa/sociedad
        /// </summary>
        public string NombreSocial { get; set; }
        
        /// <summary>
        /// Número de RNC para la empresa
        /// </summary>
        public string Rnc{ get; set; }


        public string Estatus_fecha { get; set; }
        


    }

    /// <summary>
    /// Clase que define el tipo de registro que una persona puede tener como accionista/socio de una empresa
    /// </summary>
    class TiposRegistroPorPersona
    {
        public int SocioId { get; set; }
        public string NombreRegistro { get; set; }
    }
}
