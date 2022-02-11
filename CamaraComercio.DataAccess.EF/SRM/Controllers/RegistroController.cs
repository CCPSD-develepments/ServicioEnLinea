using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CamaraComercio.DataAccess.EF.SRM
{

    /// <summary>
    /// Controlador de registros
    /// </summary>
    [DataObject]
    public class RegistroController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InformacionRegistro CheckRegistroEsValido(string camaraId, int numeroRegistro, Guid numeroValidacion, int TipoRegistro = 0)
        {
            var db = CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(camaraId);

            switch (TipoRegistro)
            {
                case 2:
                    {
                        var registro = db.PersonasRegistros.Where(s => s.NumeroRegistro == numeroRegistro);
                        if (registro.Count() > 0)
                        {
                            var principalPer = registro.OrderBy(r => r.Registros.FechaVencimiento).Select(r => r.Personas).FirstOrDefault();
                            var principalReg = registro.OrderBy(r => r.Registros.FechaVencimiento).Select(r => r.Registros).FirstOrDefault();
                            var tipoSociedad = new CamaraComun.CamaraComunEntities().TipoSociedad.FirstOrDefault(
                                                     ts => ts.TipoSociedadId == 7);

                            return new InformacionRegistro()
                            {
                                RazonSocial = ((principalPer.PrimerNombre != null) ? principalPer.PrimerNombre : String.Empty) +
                                              ((principalPer.SegundoNombre != null) ? principalPer.SegundoNombre : String.Empty) + " " +
                                              ((principalPer.PrimerApellido != null) ? principalPer.PrimerApellido : String.Empty) + " " +
                                              ((principalPer.SegundoApellido != null) ? principalPer.SegundoApellido : String.Empty),
                                FechaVencimiento = principalReg.FechaVencimiento,
                                TipoSociedad = tipoSociedad != null && tipoSociedad.Descripcion.Length > 0
                                               ? tipoSociedad.Descripcion
                                               : String.Empty,
                                UltimoRegistro = (principalReg.rowguid == numeroValidacion)
                            };
                        }
                        break;
                    }
                case 1:
                    {
                        var registro = db.SociedadesRegistros.Where(s => s.NumeroRegistro == numeroRegistro);

              


                        if (registro.Count() > 0)
                        {
                            var principalReg = registro.OrderBy(r => r.Registros.FechaVencimiento)
                                            .Select(r => r.Registros).FirstOrDefault();
                            var principalSoc = registro.OrderBy(r => r.Registros.FechaVencimiento)
                                            .Select(r => r.Sociedades).FirstOrDefault();

                            var tipoSociedadId = principalSoc.TipoSociedadId;
                            var tipoSociedad = new CamaraComun.CamaraComunEntities().TipoSociedad.FirstOrDefault(
                                                     ts => ts.TipoSociedadId == tipoSociedadId);
                            

                            return new InformacionRegistro()
                            {
                            
                                RazonSocial = principalSoc.NombreSocial,
                                FechaVencimiento = principalReg.FechaVencimiento,
                                TipoSociedad = tipoSociedad != null && tipoSociedad.Descripcion.Length > 0
                                               ? tipoSociedad.Descripcion
                                               : String.Empty,
                                UltimoRegistro = (principalReg.rowguid == numeroValidacion)
                            };
                        }
                        break;
                    }
            }
            
            //Si no se encontraron registros con la informacion pasada al método se retorna nulo
            return null;
        }
    }

    public class InformacionRegistro
    {
        public string RazonSocial { get; set; }
        public string TipoSociedad { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool UltimoRegistro { get; set; }
    }
}


