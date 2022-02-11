using System;
using System.Collections.Generic;
using System.Linq;

namespace CamaraComercio.DataAccess.EF.SRM
{
    /// <summary>
    /// Repositorio de la vista SumarioSociedades
    /// </summary>
    public class SumarioRepository : Repository<SRM.ViewSumarioSociedades, SRM.CamaraSRMEntities>
    {
        /// <summary>
        /// Constructor Predeterminado 
        /// </summary>
        /// <param name="camaraID">ID de la Cámara</param>
        public SumarioRepository(string camaraID) : base(SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraID))
        {
        }
        
        /// <summary>
        /// Realiza una búsqueda en la vista que unifica Sociedades y Registros
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="tipoBusqueda"></param>
        /// <returns></returns>
        public IEnumerable<SRM.ViewSumarioSociedades> FindSociedades(string qry, TipoBusquedaSociedades tipoBusqueda, bool exactly = false)
        {
            var dbSrm = this.Session;
            IEnumerable<ViewSumarioSociedades> col = new List<ViewSumarioSociedades>();

            switch (tipoBusqueda)
            {
                case TipoBusquedaSociedades.PorNombre:
                    if (exactly) col = dbSrm.ViewSumarioSociedades.Where(s => s.NombreSocial == qry && s.EstatusId == 1);
                    else col = dbSrm.ViewSumarioSociedades.Where(s => s.NombreSocial.Contains(qry) && s.EstatusId == 1);
                    break;

                case TipoBusquedaSociedades.PorNoRegistro:
                    int noRegistro;
                    Int32.TryParse(qry, out noRegistro);
                    col = Int32.TryParse(qry, out noRegistro)
                              ? dbSrm.ViewSumarioSociedades.Where(s => s.NumeroRegistro == noRegistro && s.EstatusId == 1)
                              : null;
                    break;

                case TipoBusquedaSociedades.PorRnc:
                    //Busqueda por rnc de la empresa
                    col = dbSrm.ViewSumarioSociedades.Where(s => s.Rnc == qry && s.EstatusId == 1);

                    //Busqueda por cedulas de accionistas
                    var idsSociedades = dbSrm.ViewRegistrosSocios
                        .Where(vr => vr.Documento == qry).Select(vr => vr.RegistroId);
                    var empresasSocios = dbSrm.ViewSumarioSociedades
                        .Where(vss => idsSociedades.Contains(vss.RegistroId) && vss.EstatusId == 1);
                    col = col.Union(empresasSocios);
                    break;
            }

            return col;
        }

        /// <summary>
        /// Realiza una búsqueda en la vista que unifica Sociedades y Registros
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="tipoBusqueda"></param>
        /// <returns></returns>
        public DatatableDto<ViewSumarioSociedades> FindSociedadesDt(string qry, TipoBusquedaSociedades tipoBusqueda, bool exactly = false, int start = 0, int length = 20)
        {
            var dbSrm = this.Session;
            DatatableDto<ViewSumarioSociedades> datatableDto = new DatatableDto<ViewSumarioSociedades>();

            switch (tipoBusqueda)
            {
                case TipoBusquedaSociedades.PorNombre:
                    if (exactly)
                    {
                        datatableDto.Items = dbSrm.ViewSumarioSociedades.Where(s => s.NombreSocial == qry && s.EstatusId != 5).OrderBy(d => d.NombreSocial).Skip(start).Take(length);
                        datatableDto.TotalRows = dbSrm.ViewSumarioSociedades.Where(s => s.NombreSocial == qry && s.EstatusId != 5).Count();
                    }
                    else
                    {
                        datatableDto.Items = dbSrm.ViewSumarioSociedades.Where(s => s.NombreSocial.Contains(qry) && s.EstatusId != 5).OrderBy(d => d.NombreSocial).Skip(start).Take(length);
                        datatableDto.TotalRows = dbSrm.ViewSumarioSociedades.Where(s => s.NombreSocial.Contains(qry) && s.EstatusId != 5).Count();
                    }
                    break;

                case TipoBusquedaSociedades.PorNoRegistro:
                    if (int.TryParse(qry, out int noRegistro))
                    {
                        datatableDto.Items = dbSrm.ViewSumarioSociedades.Where(s => s.NumeroRegistro == noRegistro && s.EstatusId != 5).OrderBy(d => d.NombreSocial).Skip(start).Take(length);
                        datatableDto.TotalRows = dbSrm.ViewSumarioSociedades.Where(s => s.NumeroRegistro == noRegistro && s.EstatusId != 5).Count();
                    }
                    break;

                case TipoBusquedaSociedades.PorRnc:
                    //Busqueda por rnc de la empresa
                    var companiesByRnc = dbSrm.ViewSumarioSociedades.Where(s => s.Rnc == qry && s.EstatusId != 5).OrderBy(d => d.NombreSocial).Skip(start).Take(length);

                    //Busqueda por cedulas de accionistas
                    var idsSociedades = dbSrm.ViewRegistrosSocios.Where(vr => vr.Documento == qry).Select(vr => vr.RegistroId);
                    var empresasSocios = dbSrm.ViewSumarioSociedades.Where(vss => idsSociedades.Contains(vss.RegistroId) && vss.EstatusId != 5);

                    datatableDto.Items = companiesByRnc.Union(empresasSocios).OrderBy(d => d.NombreSocial).Skip(start).Take(length);
                    break;
            }

            return datatableDto;
        }
    }

    public class DatatableDto<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalRows { get; set; } = 0;
    }
}
