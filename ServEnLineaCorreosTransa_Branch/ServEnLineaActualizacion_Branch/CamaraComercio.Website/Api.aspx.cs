using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.Website.DTO;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Api'
    public partial class Api : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Api'
    {
        private string Operation { get { return Request.GetParam("op"); } }
        private int? OpId
        {
            get
            {
                var parm = Request.GetParam("Id");
                if (parm.Length > 0 && parm != "source")
                {
                    int id;
                    if (Int32.TryParse(parm, out id))
                        return id;
                    return null;
                }
                return null;
            }
        }
        private string OpIdStr
        {
            get { return Request.GetParam("Id"); }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Api.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Api.Page_Load(object, EventArgs)'
        {
            var responseString = HandleRequest();

            if (String.IsNullOrEmpty(responseString)) return;
            Response.ContentType = "application/json";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(responseString);
        }

        private string HandleRequest()
        {
            var json = String.Empty;
            var db = new Comun.CamaraComunEntities();

            switch (this.Operation.ToLower())
            {
                //Query recibido de onapi
                case "reciboonapi":

                    wsOnapi2.ServicioCC onapi = new wsOnapi2.ServicioCC();
                    int numeroOnapi = 0;
                    int.TryParse(this.OpIdStr, out numeroOnapi);
                    wsOnapi2.ResultadoBusquedaNombre res = onapi.BuscarNombrePorNumero(numeroOnapi, "cc", "abc");

                    if (res != null)
                    {
                        json = res.ToAnonJSON();
                    }

                break;

                //Query de recibo de la DGII
                case "recibodgii":
                    var ws = new wsDgii3.wsDGII();
                    var resp = ws.ConsultaAutorizacionPago(Helper.WsDgiiUsername, Helper.WsDgiiPassword, this.OpIdStr);
                    if (resp == null) break;

                    //Validando si el recibo fue pagado (ya que no trae ningún mensaje)
                    if (resp.Pagada == 0 && resp.DescripcionMensaje.Trim().Length == 0)
                        resp.DescripcionMensaje = "El recibo ha sido solicitado, pero aún no ha sido pagado";

                    //Validando si el recibo se ha vendio (ya que no trae ningún mensaje)
                    var vencida = resp.FechaLimiteAutorizacion < DateTime.Today && resp.Pagada == 0;
                    
                    if (vencida)
                        resp.DescripcionMensaje = "El recibo se venció antes de haber sido pagado. Debe generar un nuevo recibo.";

                    if (resp.FechaLimiteAutorizacion == DateTime.MinValue && resp.MontoAutorizacionPago == 0)
                        resp.DescripcionMensaje = "Número de recibo inválido. Por favor revise y digite nuevamente.";

                    //Variable anónima de retorno
                    var respDTO = new
                                      {
                                          resp.CodigoMensaje, 
                                          DescripcionMensaje = resp.DescripcionMensaje.Length > 0
                                                                ? resp.DescripcionMensaje
                                                                : "Recibo Válido",
                                          resp.FechaLimiteAutorizacion, resp.FechaPagoAutorizacion,
                                          resp.MontoAutorizacionPago, resp.NombreRazonSocial,
                                          resp.NumeroAutorizacion, resp.Pagada,
                                          resp.RNC_Cedula, Vencida = vencida
                                      };

                    json = respDTO.ToAnonJSON();
                    break;
                
                //Listado de bancos en el sistema
                case "bancos":
                    json = db.Bancos
                        .Select(b => new {b.BancoId, Text = b.Descripcion, Html = b.Descripcion, Comment = b.Descripcion})
                        .OrderBy(b => b.Text).ToList().ToAnonJSON();
                    break;

                //Listado de actividades del sistema
                case "actividadesqry":
                    json = db.Actividades
                        .Where(a => a.Visible != false)
                        .Select(a => new { id = a.ActividadID, a.PadreID, text = a.Descripcion, a.RecibeAccion,
                                    hasChildren = a.TieneHijos, nombreCompleto = a.DescripconLarga})
                        .OrderBy(a => a.text)
                        .ToList().ToAnonJSON();
                    break;

                //Listado de actividades formateadas como un arbol para desplegar en control de extended list
                case "actividadestree":
                    var qry = db.Actividades
                        .Where(a => a.Visible != false)
                        .Select(a => new DTO.ActividadDTO()
                                         {
                                             ID = a.ActividadID, PadreID = a.PadreID, Descripcion = a.Descripcion,
                                             RecibeAccion = a.RecibeAccion, TieneHijos = a.TieneHijos, 
                                             DescripcionLarga = a.DescripconLarga,
                                         }).OrderBy(a => a.Descripcion).ToList();

                    var actividadRaiz = new DTO.ActividadDTO()
                                            {
                                                ID = null,
                                                Descripcion = "root",
                                                DescripcionLarga = "root",
                                                PadreID = null,
                                                RecibeAccion = false,
                                                TieneHijos = true
                                            };

                    json = AnidarResultados(actividadRaiz, ref qry).ToJSON();
                    break;

                case "actividades":
                    if (this.OpId == null)
                        json = db.Actividades
                        .Select(a => new { id = a.ActividadID, a.PadreID, text = a.Descripcion, a.RecibeAccion, hasChildren = a.TieneHijos, nombreCompleto = a.DescripconLarga })
                        .Where(a => a.PadreID == null)
                        .OrderBy(a => a.text).ToList().ToAnonJSON();
                    else
                        json = db.Actividades
                            .Select(a => new { id = a.ActividadID, a.PadreID, text = a.Descripcion, a.RecibeAccion, hasChildren = a.TieneHijos, nombreCompleto = a.DescripconLarga })
                            .Where(a => a.PadreID == this.OpId)
                            .OrderBy(a => a.text).ToList().ToAnonJSON();
                    break;
                default:
                    break;
            }
            return json;
        }

        private ActividadDTO AnidarResultados(ActividadDTO item , ref List<ActividadDTO> qry)
        {
            if (item.ActividadesHijas == null)
                item.ActividadesHijas = new List<ActividadDTO>();

            //Se seleccionan los hijos del item actual
            var id = item.ID;
            var hijos = qry.Where(q => q.PadreID == id);

            foreach (var hijo in hijos)
            {                
                var hijoAnidado = AnidarResultados(hijo, ref qry);
                item.ActividadesHijas.Add(hijoAnidado);
            }
            return item;
        }
    }

}