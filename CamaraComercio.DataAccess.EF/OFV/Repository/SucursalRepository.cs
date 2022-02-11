using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Repositorio para el manejo de sucursales
    /// </summary>
    [DataObject]
    public class SucursalRepository:Repository<Sucursales, CamaraWebsiteEntities>
    {
        ///<summary>
        /// Obtiene todas las sucursales por ID de la transaccion
        ///</summary>
        ///<param name="transId"></param>
        ///<returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<Sucursales> GetSucursalesByTransaccionID(int transId)
        {
            var db = this.Session;
            var transaccion = db.Transacciones.Where(t => t.TransaccionId == transId).FirstOrDefault();

            //Validacion del registro
            if (transaccion == null) 
                return null;

            if (transaccion.NumeroRegistro.HasValue && transaccion.NumeroRegistro > 0)
            {
                //Si la transaccion tiene un registro, quiere decir que está cargada en el SRM. 
                //se trae la data de CamaraSRM en vez de Camara Website

                var dbSRM = DataAccess.EF.SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(transaccion.CamaraId);

                var sumario = dbSRM.ViewSumarioSociedades.Where(v => v.NumeroRegistro == transaccion.NumeroRegistro).
                        FirstOrDefault();
                if (sumario == null)
                    return null;

                var sucursales = from s in dbSRM.Suscursales
                    join d in dbSRM.Direcciones on s.DireccionId equals d.DireccionId
                    select new
                               {
                                   s.SucursalId,
                                   s.Descripcion,
                                   s.FechaModificacion,
                                   d.ApartadoPostal,
                                   d.Calle,
                                   d.CiudadDescripcion,
                                   d.CiudadId,
                                   d.Email,
                                   d.Extension,
                                   d.Fax,
                                   d.Numero,
                                   d.PaisDescripcion,
                                   d.PaisId,
                                   d.SectorDescripcion,
                                   d.SectorId,
                                   d.TelefonoCasa,
                                   d.TelefonoOficina,
                               };

                return sucursales.Select(s => new Sucursales
                                             {
                                                Descripcion   = s.Descripcion,
                                                DireccionApartadoPostal = s.ApartadoPostal,
                                                DireccionCalle = s.Calle,
                                                DireccionCiudadId = s.CiudadId,
                                                DireccionEmail = s.Email,
                                                DireccionExtension = s.Extension,
                                                DireccionFax = s.Fax,
                                                DireccionNumero = s.Numero,
                                                DireccionSectorId = s.SectorId
                                             }
                    );

            }
            else
            {
                var sociedad = db.Sociedades.Where(s => s.RegistroId == transaccion.RegistroId).FirstOrDefault();
                if (sociedad == null) return null;

                var sucursales = db.Sucursales.Where(s => s.SociedadId == sociedad.SociedadId);
                return sucursales;
            }
        }

        ///<summary>
        /// Retorna la colección de sucursales asociadas a un registro mercantil
        ///</summary>
        ///<param name="numeroCertificacion">Número de registro mercantil</param>
        ///<param name="camaraID">ID de la cámara</param>
        ///<returns>Colección IEnumerable de Sucursales</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IEnumerable<Sucursales> GetSucursalesByNumeroRegistro(int numeroRegistro, string camaraID)
        {
            var db = this.Session;
            var dbSRM = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID);

            var registro = dbSRM.Registros.Where(r => r.SociedadesRegistros.FirstOrDefault().NumeroRegistro == numeroRegistro).FirstOrDefault();
            if (registro == null)
                return null;

                var sociedadId = registro.SociedadesRegistros.FirstOrDefault().SociedadId;
                var sucursales = from s in dbSRM.Suscursales
                                 join d in dbSRM.Direcciones on s.DireccionId equals d.DireccionId
                                 where s.SociedadId == sociedadId
                                 select new
                                 {
                                     s.SucursalId, s.Descripcion,
                                     s.FechaModificacion, d.ApartadoPostal,
                                     d.Calle, d.CiudadDescripcion,
                                     d.CiudadId, d.Email,
                                     d.Extension, d.Fax,
                                     d.Numero, d.PaisDescripcion,
                                     d.PaisId, d.SectorDescripcion,
                                     d.SectorId, d.TelefonoCasa,
                                     d.TelefonoOficina,
                                 };

            return sucursales.Select(s => new Sucursales
                                              {
                                                  Descripcion = s.Descripcion,
                                                  DireccionApartadoPostal = s.ApartadoPostal,
                                                  DireccionCalle = s.Calle,
                                                  DireccionCiudadId = s.CiudadId,
                                                  DireccionEmail = s.Email,
                                                  DireccionExtension = s.Extension,
                                                  DireccionFax = s.Fax,
                                                  DireccionNumero = s.Numero,
                                                  DireccionSectorId = s.SectorId
                                              });
        }
    }
}
