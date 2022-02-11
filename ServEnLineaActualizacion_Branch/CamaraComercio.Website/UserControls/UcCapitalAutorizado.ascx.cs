using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.Website.Operaciones.Modificaciones;

namespace CamaraComercio.Website.UserControls
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UcCapitalAutorizado'
    public partial class UcCapitalAutorizado : System.Web.UI.UserControl, IRegisterTransaccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UcCapitalAutorizado'
    {
        /// <summary>
        /// Clase que sera convertida en XML para ser enviada a SRM.
        /// </summary>
        private class ModificacionAumentoCapital
        {
            private UcCapitalAutorizado instance;

            public ModificacionAumentoCapital(UcCapitalAutorizado instance)
            {
                this.instance = instance;
            }

            public ModificacionAumentoCapital()
            {

            }

            [ControlName(NombreControl = "ltCapAutorizado", id = "ltCapAutorizado", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public Decimal CapitalAutorizado
            {
                get
                {
                    string capitalAutorizadoStr = instance.ltCapAutorizado.Text;
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

            public string GetXML()
            {
                return Serializer<ModificacionAumentoCapital>.Serialize(this);
            }
        }

        private CamaraComercio.Website.Operaciones.Modificaciones.ModificacionPage CurrentPagina;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UcCapitalAutorizado.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UcCapitalAutorizado.Page_Load(object, EventArgs)'
        {
            CurrentPagina
                    = (ModificacionPage)this.Page;
            if (!IsPostBack)
            {
                //Busco Datos de Sociedad
                CurrentPagina.InitializeSociedad();

                var dbComun = new CamaraComunEntities();

                rvCapitalSocialNuevo.MinimumValue = dbComun.TipoSociedad.FirstOrDefault(a => a.TipoSociedadId == CurrentPagina.TipoSociedadId).CapitalAutorizado.ToString();

                ltCapAutorizado.Text = String.Format("{0:n}", CurrentPagina.SociedadRegistro.Registros.CapitalAutorizado ?? 0m);
            }

        }



#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UcCapitalAutorizado.GuardarModificacion()'
        public void GuardarModificacion()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UcCapitalAutorizado.GuardarModificacion()'
        {
            CurrentPagina
                 = (ModificacionPage)this.Page;

            ModificacionAumentoCapital instance = new ModificacionAumentoCapital(this);

#pragma warning disable CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'
            CurrentPagina.InstanceXML = instance.GetXML();
#pragma warning restore CS0618 // 'ModificacionPage.InstanceXML' is obsolete: 'Metodo no utilizado, ya no se envia el XML'

            //Invoco Guardar el XML
            CurrentPagina.GuardarObjetoModificacion();
        }
    }
}