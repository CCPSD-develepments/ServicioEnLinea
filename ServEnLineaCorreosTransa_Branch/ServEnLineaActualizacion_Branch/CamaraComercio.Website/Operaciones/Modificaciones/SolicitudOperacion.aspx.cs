using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Helpers;
using Telerik.Web.UI;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion'
    public partial class SolicitudOperacion : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.EsRenovacion'
        public String EsRenovacion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.EsRenovacion'
        {
            get { return Request.QueryString["EsRenovacion"] ?? String.Empty; }
        }
        private const String SiEsRenovacion = "1";
        private const int RenovacionConDocumentos = 371;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;

            LimpiarObjetosEnSesion();
            InitializeSociedad();

            //Asignando Valores del tipo de sociedad seleccionado.
            ltNombreSocial.Text = this.SociedadRegistro.Sociedades.NombreSocial;
            
            if (this.TipoSociedadId == 0)
                return;

            var dbComun = new Comun.CamaraComunEntities();
            ltTipoSociedad.Text =
                dbComun.TipoSociedad.FirstOrDefault(t => t.TipoSociedadId == this.TipoSociedadId).Etiqueta;

            var tipoServicioIdStr = Request.QueryString["tipoServicioId"];
            int tipoServicioId;
            Int32.TryParse(tipoServicioIdStr, out tipoServicioId);
            var notModOrTrans = tipoServicioId > 0 && tipoServicioId != Helper.TipoServicioId &&
                               tipoServicioId != Helper.TipoServicioIdTransformacion;

            hfTipoSociedadId.Value = this.TipoSociedadId.ToString();
            hfTipoServicioId.Value = notModOrTrans
                                     ? tipoServicioId.ToString()
                                     : Helper.TipoServicioId.ToString();
            hfTransformacionId.Value = Helper.TipoServicioIdTransformacion.ToString();
            hfSinCapital.Value = (this.SociedadRegistro.Registros.CapitalSocial == 0 &&
                Helper.TipoSociedadExtranjera.Contains(this.TipoSociedadId)).ToString();

            if (notModOrTrans)
            {
                //Se esconden los paneles
                this.pnlTransformacion.Visible = false;
                this.pnlRenovacion.Visible = false;
                this.hfSeleccionUnitaria.Value = "1";
            }
            else
            {
                //Mostrando panel de transformacion
                this.pnlTransformacion.Visible = (tipoServicioId == Helper.TipoServicioIdTransformacion);
                
                //Validando si puede solicitar Renovación.
                InitRenovacion();
            }

            if (EsRenovacion == "1")
            {
                pnlRenovacion.Visible = true;
                chkRenovacion.Checked = true;
                this.hfRenovacionObligatoria.Value = "1";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.InitRenovacion()'
        protected void InitRenovacion()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.InitRenovacion()'
        {
            //Fechas
            var fechaVenc = this.SociedadRegistro.Registros.FechaVencimiento;
            
            //Calculando si aplica renovacion
            pnlRenovacion.Visible = fechaVenc.HasValue
                                ? (fechaVenc.Value - DateTime.Today).Days 
                                    < Helper.TiempoMinimoPermitirRenovacionDias
                                : true;

            //Calculando cantidad de renovaciones a aplicar
            var yearSpan = (DateTime.Today - fechaVenc);
            var cantAnos = yearSpan.HasValue ? Math.Ceiling(Convert.ToDecimal(yearSpan.Value.Days)/365) : 1;
            var cantRenovaciones = cantAnos%2 == 0 
                ? Convert.ToInt32(cantAnos/2) 
                : Convert.ToInt32(Math.Truncate(cantAnos/2)) + 1;

            this.hfCantidadRenovaciones.Value = cantRenovaciones.ToString();
            this.lblCantRenovaciones.Text = cantRenovaciones.ToString();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.btnContinuar_Click(object, EventArgs)'
        protected void btnContinuar_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.btnContinuar_Click(object, EventArgs)'
        {
            LimpiarObjetosEnSesion();
            if (!IsValido()) return;

            IncluirRenovacion = chkRenovacion.Checked;
            ListServiciosWithCustomUrl();
            DefaultQueryString = ListServicios();

            //Si el tipo de servicio es de transformación se modifica el DefaultQueryString para usar el nuevo TipoSociedadId
            if (this.chkTransformacion.Checked)
            {
                var servicioIdStr = this.ddlTransformacion.SelectedValue;
                int servicioId;
                
                if (Int32.TryParse(servicioIdStr, out servicioId))
                {
                    var dbComun = new Comun.CamaraComunEntities();
                    var servicio = dbComun.Servicio.FirstOrDefault(s => s.ServicioId == servicioId);
                    if (servicio != null)
                    {
                        var strParams = this.DefaultQueryString.Split('&');
                        var sb = new StringBuilder();

                        //Reemplazo del parametro para TipoSociedadId
                        foreach (var str in strParams)
                        {
                            if (str.ToLower().Contains("tiposociedadid"))
                                sb.AppendFormat("TipoSociedadId={0}&", servicio.TransfDestinoId);
                            else
                                sb.Append(str + "&");
                        }

                        //Se actualizan todas las páginas en la coleccion para reflejar el nuevo TipoSociedadId
                        for (var i = 0; i < Paginas.Count; i++)
                        {
                            var pagina = Paginas[i];
                            var pagRoot = pagina.Substring(0, pagina.IndexOf(".aspx?") + 6);
                            var pagVars = pagina.Substring(pagina.IndexOf(".aspx?") + 6);
                            var sbVars = new StringBuilder();
                            foreach (var varStr in pagVars.Split('&'))
                            {
                                if (varStr.ToLower().StartsWith("tiposociedadid"))
                                    sbVars.AppendFormat("TipoSociedadId={0}&", servicio.TransfDestinoId);
                                else
                                    sbVars.Append(varStr + "&");
                            }
                            Paginas[i] = pagRoot + sbVars.ToString().TrimEnd('&');   
                        }

                        //Se crea la entrada correcta para Datos Generales
                        Paginas.Add("~/Operaciones/Modificaciones/DatosGenerales.aspx" + sb.ToString().TrimEnd('&'));
                        Paginas = Paginas.Distinct().ToList();
                        Response.Redirect(Paginas[0]);
                    }
                }
            }

            Paginas.Add("~/Operaciones/Modificaciones/DatosGenerales.aspx" + DefaultQueryString);
            Paginas = Paginas.Distinct().ToList();
            Response.Redirect(Paginas[0]);
        }
        //validar que esten items chequeados.
        private bool EligioUnaModificacion(List<int> IdsServicos) 
        {

            foreach (var idServicio in IdsServicos)
            {
                if (!idServicio.Equals(RenovacionConDocumentos))
                    return true;
            }

            return false;
        }
        private bool IsValido()
        {
            var comun = new Comun.CamaraComunEntities();
            var serviciosInGrid = GetListServicios();

            if (serviciosInGrid.Count() == 0 && !chkRenovacion.Checked)
            {
                this.pnlErrorBox.Visible = true;
                this.ltError.Text = "Hemos detectado que no seleccionaste ninguna modificación. Selecciona al menos un tipo de modificacion e intentalo nuevamente.";
                return false;
            }
            //Si es  una renovacion verificar que se seleccione un check en seccion de modificaciones
            if (EsRenovacion.Equals(SiEsRenovacion))
            {
                if (!EligioUnaModificacion(serviciosInGrid)) 
                {
                    this.pnlErrorBox.Visible = true;
                    this.ltError.Text = "Hemos detectado que no seleccionaste ninguna modificación. Selecciona al menos un tipo de modificacion e intentalo nuevamente.";
                    return false; 
                }
            }

            var servicios = comun.Servicio.Where(a => serviciosInGrid.Contains(a.ServicioId)).ToList();
            var excluyentes = from serv in servicios
                              group serv by serv.GrupoServicio
                                  into grp
                                  select new { GrupoServicio = grp.Key, Cantidad = grp.Count() };
            if (excluyentes.Where(s => s.GrupoServicio != 0 && s.Cantidad > 1).Count() > 0)
            {
                this.pnlErrorBox.Visible = true;
                this.ltError.Text =
                    "Hemos detectado que haz seleccionado varios servicios que no se pueden realizar en conjunto. "
                    + "Los servicios que no se pueden realizar juntos estan marcados en colores en común. "
                    + "Por favor verifica los errores listados e intenta nuevamente.";

                var diccionario = new Dictionary<int, string>
                                      {
                                          {1, "group_a"},
                                          {2, "group_b"},
                                          {3, "group_c"},
                                          {4, "group_d"},
                                          {5, "group_e"}
                                      };

                foreach (GridDataItem item in this.gridModificaciones.Items)
                {
                    if (item.ItemType == GridItemType.Item || item.ItemType == GridItemType.AlternatingItem)
                    {
                        var grupo = item.FindControl("GrupoServicioLabel") as Label;
                        int grupoId;

                        if (Int32.TryParse(grupo.Text, out grupoId) && grupoId > 0)
                        {
                            var claseCss = diccionario.Where(d => d.Key == grupoId).First().Value;
                            item.CssClass = claseCss;
                        }

                    }

                }

                return false;
            }

            this.pnlErrorBox.Visible = false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String ListServicios()
        {
            var sb = new StringBuilder();
            sb.Append("ServicioId=");
            foreach (var i in GetListServicios())
                sb.Append(i + ",");

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// Obtiene Lista de Servicios Solicitados.
        /// </summary>
        /// <returns></returns>
        public List<int> GetListServicios()
        {
            var listaServicios = (from GridDataItem item in gridModificaciones.Items
                                let datakey = gridModificaciones.MasterTableView.DataKeyValues[item.ItemIndex]
                                let chk = item.FindControl("chkServicio") as CheckBox
                                where chk.Checked
                                select Convert.ToInt32(datakey["ServicioId"])).ToList();
            
            if (this.chkTransformacion.Checked)
            {
                var servicioIdStr = this.ddlTransformacion.SelectedValue;
                Int32 servicioId;
                if (Int32.TryParse(servicioIdStr, out servicioId))
                {
                    listaServicios.Add(servicioId);
                }                    
            }

            if (this.chkRenovacion.Checked)
            {
                var servicioId = ServiciosDefault.Servicios
                    .FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId).ServicioRenovacionSimpleId;

                if (servicioId > 0)
                {
                    var cantidadRenovaciones = 1;
                    Int32.TryParse(hfCantidadRenovaciones.Value, out cantidadRenovaciones);
                    for (var i = 0; i < cantidadRenovaciones; i++)
                        listaServicios.Add(servicioId);
                }
            }

            return listaServicios;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void ListServiciosWithCustomUrl()
        {
            foreach (GridDataItem item in gridModificaciones.Items)
            {
                var datakey = gridModificaciones.MasterTableView.DataKeyValues[item.ItemIndex];
                var chk = item.FindControl("chkServicio") as CheckBox;

                if (!chk.Checked) continue;
                DefaultQueryString = ListServicios() + "&CurrentServicioId=" + datakey["ServicioId"];
                String queryString = DefaultQueryString;

                var url = datakey["UrlModificacion"] != null
                              ? datakey["UrlModificacion"].ToString() + queryString
                              : String.Empty;

                if (!String.IsNullOrWhiteSpace(url))
                    Paginas.Add(url);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.gridModificaciones_ItemDataBound(object, GridItemEventArgs)'
        protected void gridModificaciones_ItemDataBound(object sender, GridItemEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.gridModificaciones_ItemDataBound(object, GridItemEventArgs)'
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var servicio = e.Item.DataItem as Servicio;
                if (servicio != null)
                {
                    Int32 servCompId;
                    Helper.ServiciosComplementariosIds.TryGetValue(servicio.ServicioId, out servCompId);
                    var hf = e.Item.FindControl("hfServicioComplementarioId") as HiddenField;

                    if (servCompId > 0 && hf != null)
                        hf.Value = servCompId.ToString();
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.ddlTransformacion_SelectedIndexChanged(object, EventArgs)'
        protected void ddlTransformacion_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudOperacion.ddlTransformacion_SelectedIndexChanged(object, EventArgs)'
        {
            if (chkTransformacion.Checked)
            {
                //Listado de servicios actualizado para el tipo de empresa seleccionado
                var servicioIdStr = this.ddlTransformacion.SelectedValue;
                int servicioId;
                if (Int32.TryParse(servicioIdStr, out servicioId))
                {
                    var dbComun = new Comun.CamaraComunEntities();
                    var servicio = dbComun.Servicio.FirstOrDefault(s => s.ServicioId == servicioId);
                    if (servicio != null && servicio.TransfDestinoId != null && servicio.TransfDestinoId > 0)
                    {
                        var destinoSociedadId = servicio.TransfDestinoId.ToString();

                        odsServiciosmodificacion.SelectParameters.Clear();
                        odsServiciosmodificacion.SelectParameters.Add("tipoServicioId", DbType.Int32,
                                                                      this.hfTipoServicioId.Value);
                        odsServiciosmodificacion.SelectParameters.Add("tipoSociedadId", DbType.Int32, destinoSociedadId);
                        odsServiciosmodificacion.SelectParameters.Add("sinCapital", DbType.Boolean,
                                                                      this.hfSinCapital.Value);

                        odsServiciosmodificacion.DataBind();
                    }
                }

                hfTransfCompIds.Value = Helper.ServiciosTransfComplementarioIds.ToJSON();
            }

            else
            {
                hfTransfCompIds.Value = String.Empty;
            }
        }



    }
}