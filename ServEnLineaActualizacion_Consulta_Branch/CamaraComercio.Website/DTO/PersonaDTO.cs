using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.Website.DTO
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO'
    public class PersonasDTO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.PersonaId'
        public int PersonaId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.PersonaId'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.NombreCompleto'
        public string NombreCompleto { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.NombreCompleto'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.PersonasDTO(Personas)'
        public PersonasDTO(Personas entity)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.PersonasDTO(Personas)'
        {
            this.PersonaId = entity.PersonaId;
            this.NombreCompleto = entity.NombreCompleto;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.PersonasDTO()'
        public PersonasDTO()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PersonasDTO.PersonasDTO()'
        {

        }
    }
}