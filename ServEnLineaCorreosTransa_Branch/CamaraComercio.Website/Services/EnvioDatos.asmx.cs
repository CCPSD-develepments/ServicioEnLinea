using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.Website.DTO;

namespace CamaraComercio.Website.Services
{
    /// <summary>
    /// Web Service que asiste en el envío de datos mediante llamadas AJAX
    /// </summary>
    [WebService(Namespace = "http://www.registromercantil.org.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class EnvioDatos : System.Web.Services.WebService
    {
        [WebMethod(Description = "Servicio web que asiste el formulario de envío de datos mediante llamadas AJAX")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.UpdateDocumentosInfo(int, string, int, bool)'
        public int UpdateDocumentosInfo(int transaccionesDocumentosId, String descripcion, int tipoDocumentoId, bool firmaDigital)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.UpdateDocumentosInfo(int, string, int, bool)'
        {
            var controller = new TransaccionDocumentosController();
            try
            {
                var ofvDb = new CamaraWebsiteEntities();
                var transId = ofvDb.TransaccionesDocumentos.First(x => x.TransaccionesDocumentosId == transaccionesDocumentosId);

                if (tipoDocumentoId == 1551)
                {
                    controller.UpdateDocumentosEnviados(transaccionesDocumentosId, descripcion, tipoDocumentoId, firmaDigital);
                    return 1;
                }
                else if(tipoDocumentoId == -1)
                {
                    controller.UpdateDocumentosEnviados(transaccionesDocumentosId, descripcion, -1, firmaDigital);
                    return 1;
                }
                else
                {
                    bool? verify = ofvDb.TransaccionesDocumentos.Any(x => x.TipoDocumentoId == tipoDocumentoId && x.TransaccionId == transId.TransaccionId);
                    if (verify == false)
                    {
                        controller.UpdateDocumentosEnviados(transaccionesDocumentosId, descripcion, tipoDocumentoId, firmaDigital);
                        return 1;

                    }
                    else
                    {
                        controller.UpdateDocumentosEnviados(transaccionesDocumentosId, descripcion, -1, firmaDigital);
                        return 0;
                    }
                }
                
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return 0;
            }
        }

        [WebMethod(EnableSession = true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.GetRepresentantes()'
        public PersonasDTO[] GetRepresentantes()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.GetRepresentantes()'
        {
            var result = new List<PersonasDTO>();
            List<Personas> lista = null;

            if (Context.Session["Representantes"] != null)
                lista = Context.Session["Representantes"] as List<Personas>;

            if (lista == null)
                return result.ToArray();

            lista.ForEach(persona => result.Add(new PersonasDTO(persona)));
            return result.ToArray();
        }

        [WebMethod]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.GetUsuarioFirmaDigital()'
        public bool GetUsuarioFirmaDigital()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EnvioDatos.GetUsuarioFirmaDigital()'
        {
            var profile = (OficinaVirtualUserProfile)this.Context.Profile;

            return profile.bFirmaDigital.HasValue ? profile.bFirmaDigital.Value : false;
        }


    }
}
