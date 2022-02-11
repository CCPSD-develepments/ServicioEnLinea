using System.Linq;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.DataAccess.EF.OficinaVirtual
{
    /// <summary>
    /// Transacciones Históricas
    /// </summary>
    public partial class TransaccionHistorico
    {
        /// <summary>
        /// Servicio de una transacción histórica
        /// </summary>
        public ServicioComun Servicio
        {
            get
            {
                var result = new CamaraComunEntities().Servicio.FirstOrDefault(a => a.ServicioId == this.ServicioId);
                if (result != null)
                    return new ServicioComun { ServicioId = this.ServicioId, Nombre = result.Descripcion };
                else
                    return new ServicioComun();
            }
        }

        /// <summary>
        /// Tipo de sociedad de una transacción histórica
        /// </summary>
        public TipoSociedades TipoSociedades
        {
            get
            {
                var result = new CamaraComun.CamaraComunEntities().TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId);
                return new TipoSociedades { TipoSociedadId = this.TipoSociedadId, Nombre = result.Descripcion };

            }
        }

        /// <summary>
        /// Estatus de una transacción histórica
        /// </summary>
        public EstatusTransacciones EstatusTransacciones
        {
            get
            {
                if (this.EstatusTransId == 0)
                    return null;

                var result = new SRM.CamaraSRMEntities(Helpers.GetCamaraConnString(this.CamaraId)).EstatusTransacciones.FirstOrDefault(a => a.EstatusTransId == this.EstatusTransId);
                
                return result != null 
                       ? new EstatusTransacciones { EstatusTransId = this.EstatusTransId, EstatusTranNombre = result.EstatusTransaccion, EstatusTransDescripcion = result.EstatusTransaccion }
                       : null;
            }
        }

        /// <summary>
        /// El comentario de la transaccion.
        /// </summary>
        public string Comentario { get; set; }
    }
}
