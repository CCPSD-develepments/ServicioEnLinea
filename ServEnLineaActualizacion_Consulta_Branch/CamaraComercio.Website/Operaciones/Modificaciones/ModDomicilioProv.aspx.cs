using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;

namespace CamaraComercio.Website.Operaciones.Modificaciones
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>'
    public abstract class EntitySerializer<T>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>.instance'
        protected T instance;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>.instance'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>.EntitySerializer()'
        public EntitySerializer()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>.EntitySerializer()'
        {
            this.instance = (T)HttpContext.Current.CurrentHandler;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>.GetXML()'
        public virtual string GetXML()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EntitySerializer<T>.GetXML()'
        {
            return String.Empty;
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv'
    public partial class ModDomicilioProv : ModificacionPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv'
    {
        private class ModificacionDomicionProv : EntitySerializer<ModDomicilioProv>
        {
            [ControlName(NombreControl = "txtDireccionEmpCalle", id = "txtDireccionEmpCalle", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String Calle
            {
                get
                {
                    return instance.txtDireccionEmpCalle.Text;
                }
            }

            [ControlName(NombreControl = "txtDireccionEmpNumero", id = "txtDireccionEmpNumero", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String Numero
            {
                get
                {
                    return instance.txtDireccionEmpNumero.Text;
                }
            }

            [ControlName(NombreControl = "txtApartadoPostal", id = "txtApartadoPostal", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String ApartadoPostal
            {
                get
                {
                    return instance.txtApartadoPostal.Text;
                }
            }

            [ControlName(NombreControl = "ddlCiudad", id = "ddlCiudad", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String CiudadId
            {
                get
                {
                    if (instance.ddlCiudad.Items.Count > 0)
                        return instance.ddlCiudad.SelectedValue;

                    return String.Empty;
                }
            }

            [ControlName(NombreControl = "ddlSector", id = "ddlSector", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String SectorId
            {
                get
                {
                    if (instance.ddlSector.Items.Count > 0)
                        return instance.ddlSector.SelectedValue;

                    return String.Empty;
                }
            }

            [ControlName(NombreControl = "ddlSector", id = "ddlSector", isMandatory = true, maxInstances = 0, maxLength = 0, controlSRM = "undefined", fieldType = FieldType.Text, isNumber = false)]
            public String Sector
            {
                get
                {
                    if (instance.ddlSector.Items.Count > 0)
                        return instance.ddlSector.SelectedItem.Text;

                    return String.Empty;
                }
            }

            public override string GetXML()
            {
                return Serializer<ModificacionDomicionProv>.Serialize(this);
            }
        }
        private bool bModificacionMismaProvincia
        {
            get
            {
                return Session["bModMismaProvincia"] == null ? true : (bool)Session["bModMismaProvincia"];
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.Page_Load(object, EventArgs)'
        {
            if (!IsPostBack)
            {
                //Busco Datos de Sociedad
                InitializeSociedad();

                //Load Interface Data
                LoadData();
            }

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.LoadData()'
        protected void LoadData()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.LoadData()'
        {
            var dbComun = new Comun.CamaraComunEntities();
            var info = CultureInfo.CurrentCulture.TextInfo;

            //Ciudades
            var colCiudades = new Comun.CiudadesRepository().FecthInDominicanRepublic(Helper.CiudadesPrincipales, Helper.IdPaisRD);
            ddlCiudad.BindCollection(colCiudades, Comun.Ciudades.PropColumns.CiudadId, Comun.Ciudades.PropColumns.Nombre);


            //Sectores por Default
            var ciudadDefaultId = Convert.ToInt32(this.ddlCiudad.SelectedItem.Value);
            var colSectores = dbComun.Sectores.Where(s => s.CiudadId == ciudadDefaultId)
                .OrderBy(s => s.Nombre).ToList()
                .Select(s => new { s.SectorId, Nombre = info.ToTitleCase(s.Nombre.ToLower()) });

            ddlSector.BindCollection(colSectores, Comun.Sectores.PropColumns.SectorId, Comun.Sectores.PropColumns.Nombre);



            if (this.SociedadRegistro.Registros.Direcciones != null)
            {
                this.txtDireccionEmpCalle.Text = this.SociedadRegistro.Registros.Direcciones.Calle;
                this.txtDireccionEmpNumero.Text = this.SociedadRegistro.Registros.Direcciones.Numero;

                ddlCiudad.SelectedValue = this.SociedadRegistro.Registros.Direcciones.CiudadId != null ?
                    this.SociedadRegistro.Registros.Direcciones.CiudadId.ToString() :
                    String.Empty;

                ddlSector.SelectedValue = this.SociedadRegistro.Registros.Direcciones.SectorId != null ?
                    this.SociedadRegistro.Registros.Direcciones.SectorId.ToString() :
                    String.Empty;

                this.txtApartadoPostal.Text = this.SociedadRegistro.Registros.Direcciones.ApartadoPostal;
            }
        }


        // Filtro de los sectores en base a la ciudad escogida
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.ddlCiudad_SelectedIndexChanged(object, EventArgs)'
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.ddlCiudad_SelectedIndexChanged(object, EventArgs)'
        {
            var info = CultureInfo.CurrentCulture.TextInfo;
            var dbComun = new Comun.CamaraComunEntities();
            int ciudadID = ddlCiudad.SelectedItem != null ? int.Parse(ddlCiudad.SelectedValue) : 0;

            var coSectores = dbComun.Sectores.Where(a => a.CiudadId == ciudadID)
                .OrderBy(a => a.Nombre).ToList()
                .Select(a => new { a.SectorId, Nombre = info.ToTitleCase(a.Nombre.ToLower()) });
            ddlSector.BindCollection(coSectores, Comun.Sectores.PropColumns.SectorId, Comun.Sectores.PropColumns.Nombre);

            if (ddlSector.Items.Count == 0)
            {
                ddlSector.Visible = false;
                lblSectores.Text = "No Aplica";
            }
            else
            {
                ddlSector.Visible = true;
                lblSectores.Text = String.Empty;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.btnEnviarModificacion_Click(object, EventArgs)'
        protected void btnEnviarModificacion_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModDomicilioProv.btnEnviarModificacion_Click(object, EventArgs)'
        {

            this.RegistroNuevo.DireccionCalle = this.txtDireccionEmpCalle.Text;
            this.RegistroNuevo.DireccionNumero = this.txtDireccionEmpNumero.Text;
            this.RegistroNuevo.DireccionCiudadId = Convert.ToInt32(this.ddlCiudad.SelectedItem.Value);
            this.RegistroNuevo.DireccionCiudad = this.ddlCiudad.SelectedItem.Text;
            this.RegistroNuevo.DireccionApartadoPostal = this.txtApartadoPostal.Text;

            //Guardar transaccion
            GuardarObjetoModificacion();

            //Envio para revision de documentos.
            Response.Redirect("/Empresas/RevisionDocumentos.aspx");
        }
    }
}