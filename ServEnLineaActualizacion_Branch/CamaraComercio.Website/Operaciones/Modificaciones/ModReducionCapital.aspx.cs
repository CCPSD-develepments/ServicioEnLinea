using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModReducionCapital'
    public partial class ModReducionCapital : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModReducionCapital'
    {
        /// <summary>
        /// Clase que sera convertida en XML para ser enviada a SRM.
        /// </summary>
        private class ModificacionReduccionCapital : EntitySerializer<ModReducionCapital>
        {
            [ControlName(NombreControl = "ltCapAutorizado", id = "ltCapAutorizado", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal CapitalAutorizado
            {
                get
                {
                    var capitalAutorizadoStr = instance.ltCapAutorizado.Text;
                    decimal capitalAutorizado;
                    Decimal.TryParse(capitalAutorizadoStr, out capitalAutorizado);
                    return capitalAutorizado;
                }
            }

            [ControlName(NombreControl = "txtCapitalSocialNuevo", id = "txtCapitalSocialNuevo", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal NuevoCapitalAutorizado
            {
                get { return instance.txtCapitalSocialNuevo.DecimalValue(); }
            }

#pragma warning disable CS0114 // 'ModReducionCapital.ModificacionReduccionCapital.GetXML()' hides inherited member 'EntitySerializer<ModReducionCapital>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            public string GetXML()
#pragma warning restore CS0114 // 'ModReducionCapital.ModificacionReduccionCapital.GetXML()' hides inherited member 'EntitySerializer<ModReducionCapital>.GetXML()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            {
                return Serializer<ModificacionReduccionCapital>.Serialize(this);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModReducionCapital.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModReducionCapital.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                //Busco Datos de Sociedad
                InitializeSociedad();

                var dbComun = new CamaraComunEntities();

                rvCapitalSocialNuevo.MinimumValue =
                    dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId).CapitalAutorizado.
                        ToString();

                var capAutorizado = this.SociedadRegistro.Registros.CapitalAutorizado.Value2();
                this.rvCapitalSocialAnterior.MinimumValue = "0.00";
                this.rvCapitalSocialAnterior.MaximumValue = capAutorizado.ToString("n2");

                txtCapitalSocialNuevo.MaxValue = (double)capAutorizado;
                this.rvCapitalSocialNuevo.ErrorMessage = "El capital social mínimo requerido para este tipo de sociedad es RD$"
                                                         + rvCapitalSocialNuevo.MinimumValue;
                

                ltCapAutorizado.Text = String.Format("{0:n}", this.SociedadRegistro.Registros.CapitalAutorizado ?? 0m);
                ltNombreSociedad.Text = this.SociedadRegistro.Sociedades.NombreSocial;
                ltNombreSocialTitulo.Text = this.SociedadRegistro.Sociedades.NombreSocial;

                if (this.TipoSociedadId > 0)
                {
                    //Títulos - Tipo de sociedad
                    var tipoSociedad = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == this.TipoSociedadId);
                    if (tipoSociedad != null)
                    {
                        ltTipoSociedadTitulo.Text = tipoSociedad.Etiqueta;
                    }

                    //Títulos - Nombre del capital social
                    var dbWebsite = new CamaraComercio.DataAccess.EF.OficinaVirtual.CamaraWebsiteEntities();
                    var propiedad = dbWebsite.PropiedadesPorSociedad.FirstOrDefault(
                                        p => p.PropiedadesUI.Nombre == "CapitalSocial" && p.TipoSociedadID == this.TipoSociedadId);
                    if (propiedad != null && !String.IsNullOrEmpty(propiedad.Descripcion))
                    {
                        this.lblNombreCapitalSocial.Text = propiedad.Descripcion;
                        this.lbltxtCapitalSocialNuevo.Text = propiedad.Descripcion;
                    }
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModReducionCapital.btnEnviarModificacion_Click(object, EventArgs)'
        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModReducionCapital.btnEnviarModificacion_Click(object, EventArgs)'
        {
            //Se especifica Tipo Servicio
            var servicioIdActual = 0;
            int.TryParse(this.Request.QueryString["CurrentServicioId"], out servicioIdActual);
            if (servicioIdActual <= 0)
            {
                ErrorMessage = "Servicio Invalido.";
                Response.Redirect("SolicitudOperacion.aspx");
            }
            this.ServicioId = servicioIdActual;

            //Nuevo Capital Social
            Decimal capital;
            if (Decimal.TryParse(this.txtCapitalSocialNuevo.Text, out capital))
            {
                this.RegistroNuevo.CapitalSocial = capital;
               
                //Si la empresa es extranjera y el capital es cero se cambia el servicio para usar uno con monto fijo
                if (capital == 0 && Helper.TipoSociedadExtranjera.Contains(this.TipoSociedadId))
                {
                    this.ServicioId = Helper.ReduccionCapSocialCeroId;
                    var listaServicios = this.ServiciosSeleccionadosPorUrl.ToList();

                    //Se elimina el registro del servicio anterior y se crea una nueva entrada
                    for (var index = 0; index < listaServicios.Count; index++)
                    {
                        var t = listaServicios[index];
                        if (t != servicioIdActual) continue;
                        listaServicios.RemoveAt(index);
                        break;
                    }
                    listaServicios.Add(this.ServicioId);

                    //Se elimina el registro del servicio anterior de la variable que está en sesión
                    for (var i = 0; i < this.ServiciosSeleccionados.Count; i++)
                    {
                        var t = this.ServiciosSeleccionados[i];
                        if (t != servicioIdActual) continue;
                        this.ServiciosSeleccionados.RemoveAt(i);
                        break;
                    }

                    //Reemplazo del parametro para servicios
                    var qryCheck = DefaultQueryString.Replace("%2c", ",");
                    var pagIndex = Paginas.LastIndexOf("~" + Request.Path + qryCheck);
                    
                    for (var i = 0; i < Paginas.Count; i++)
                    {
                        if (pagIndex == i) continue;

                        var pagina = Paginas[i];
                        var sb = new StringBuilder();
                        var url = pagina.Substring(0, pagina.IndexOf("?"));
                        var parametros = pagina.Substring(pagina.IndexOf("?"));

                        var strParams = parametros.Split('&');
                        foreach (var str in strParams)
                        {
                            if (str.ToLower().StartsWith("servicioid"))
                            {
                                sb.AppendFormat("ServicioId={0}&", String.Join(",", listaServicios));
                            }
                            else
                            {
                                sb.Append(str + "&");
                            }
                        }
                        Paginas[i] = url + sb.ToString().Trim('&');
                    }

                    //Si cambia el servicio no se guarda el objeto de transaccion sino hasta el ultimo momento
                    GoNextPage();
                }
            }

            //Guardar transaccion
            GuardarObjetoModificacion();
            this.RegistroCargado = true;

            if (!String.IsNullOrWhiteSpace(ErrorMessage))
            {
                Master.ShowMessageError(ErrorMessage);
                return;
            }
            
            //Envio a pagina siguiente. 
            GoNextPage();
            SubmitChanges();

            //Envio a pantalla de confirmacion
            if (Redirect)
                Response.Redirect("~/Empresas/RevisionDocumentos.aspx" + DefaultQueryString);
        }

    }
}