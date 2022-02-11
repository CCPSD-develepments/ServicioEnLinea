using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de Facturas
    /// </summary>
    [DataObject]
    public partial class FacturasRepository : Repository<SRM.Facturas, SRM.CamaraSRMEntities>
    {
        /// <summary>
        /// Obtiene todas las facturas para un usuario específico
        /// </summary>
        /// <param name="userName">Nombre de usuario</param>
        /// <param name="startRowIndex">Índice de inicio para el query</param>
        /// <param name="maximumRows">Máximo número de registros a traer</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IEnumerable<SRM.Facturas> GetFacturas(String userName, int startRowIndex, int maximumRows)
        {

            var dbWebSite = new OficinaVirtual.CamaraWebsiteEntities();
            var dbComun = new CamaraComun.CamaraComunEntities();

            var result = new List<Facturas>();

            dbComun.Camaras.Where(a => a.Activa == true).ToList().ForEach(delegate(CamaraComun.Camaras a)
                                                        {

                                                            var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(a.ID);
                                                            var noRegistros =
                                                                dbWebSite.EmpresasPorUsuario.Where(
                                                                    emp =>
                                                                    emp.CamaraID == a.ID && emp.Usuario == userName).
                                                                    Select(emp => emp.NoRegistro).ToList();

                                                            var facturas =
                                                                dbSrm.Facturas.Where(f => f.Estado == 0 && noRegistros.Contains(f.Transacciones.CustomInt2)).ToList();

                                                            facturas.ForEach(delegate(SRM.Facturas fact)
                                                                                 {
                                                                                     fact.CamaraId = a.ID;
                                                                                     fact.Camara = a.Nombre;

                                                                                 });

                                                            result.AddRange(facturas);

                                                        });

            return result;
        }

        /// <summary>
        /// Cuenta la cantidad de facturas registradas a nombre de un usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetCountFacturas(String userName)
        {
            var dbWebSite = new OficinaVirtual.CamaraWebsiteEntities();
            var dbComun = new CamaraComun.CamaraComunEntities();

            int result = 0;
            dbComun.Camaras.Where(a => a.Activa == true).ToList().ForEach(delegate(CamaraComun.Camaras a)
            {
                var dbSrm =
                    SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(a.ID);

                var noRegistros =
                    dbWebSite.EmpresasPorUsuario.Where(
                        emp =>
                        emp.CamaraID == a.ID && emp.Usuario == userName).
                        Select(emp => emp.NoRegistro).ToList();

                result = dbSrm.Facturas.Where(f => f.Estado == 0 && noRegistros.Contains(f.Transacciones.CustomInt2)).Count();

            });

            return result;
        }
    }

    /// <summary>
    /// Repositorio de Facturas del SRM
    /// </summary>
    [DataObject]
    public class FacturasSrmRepository : Repository<SRM.Facturas, SRM.CamaraSRMEntities>
    {
        public FacturasSrmRepository(string camaraId) : base (CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {
        }

        public FacturasSrmRepository(CamaraSRMEntities context) : base(context) {}
    }

    /// <summary>
    /// Repositorio de Detalle de Facturas para el SRM
    /// </summary>
    [DataObject]
    public class TransaccionDetalleRepository : Repository<SRM.TransaccionDetalle, SRM.CamaraSRMEntities>
    {
        public TransaccionDetalleRepository(string camaraId)
            : base(CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId))
        {
        }

        public TransaccionDetalleRepository(CamaraSRMEntities context) : base(context) { }
    }
}
