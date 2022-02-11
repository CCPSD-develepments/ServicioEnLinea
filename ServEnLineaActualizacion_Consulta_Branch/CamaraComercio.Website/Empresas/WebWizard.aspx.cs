using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using CamaraComercio.Website.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Comun = CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using SRM = CamaraComercio.DataAccess.EF.SRM;
using Telerik.Web.UI;
using CamaraComercio.DataAccess.EF.CamaraComun;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebWizard'
    public partial class WebWizard : EnvioDatosPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebWizard'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebWizard.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebWizard.Page_Load(object, EventArgs)'
        {
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);
            Wizard1.NextButtonClick += Wizard1_ButtonClick;
            Wizard1.PreviousButtonClick += Wizard1_ButtonClick;
            Wizard1.FinishButtonClick += Wizard1_ButtonClick;
            Wizard1.Load += Wizard1_Load;

            if (IsPostBack) return;

            LimpiarObjetosSession();

            //Objetos de acceso a datos
            var db = new CamaraWebsiteEntities();

            //Transaccion
            var trans = db.Transacciones.FirstOrDefault(a => (a.TransaccionId == IdTransaciones) && a.UserName == User.Identity.Name.ToLower());
            if (trans == null) return;

            // Creando el folder en ShareBase
            if (Helper.ShareBaseEnabled)
            {
                var client = new WSShareBase.OnlineChamberServiceClient();
                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    var httpRequestProperty = new HttpRequestMessageProperty();
                    httpRequestProperty.Headers["token"] = Helper.ShareBaseToken;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;

                    var resp = client.CreateFolderOnSharebase(trans.TransaccionId.ToString(), Helper.NombreCarpetaShareBase);
                    trans.FolderId = resp.Entity;
                    db.SaveChanges();
                    client.Close();
                }
            }

            //Header
            var registro = db.Registros.Where(r => r.RegistroId == trans.RegistroId).FirstOrDefault();
            if (registro != null)
            {
                if (registro.RegistroMercantil.HasValue && registro.RegistroMercantil > 0)
                {
                    var dbSrm = SRM.CamaraSRMEntitiesFactory.CreateSrmEntitiesContext(this.CamaraId);
                    var empresa = dbSrm.SociedadesRegistros
                        .Where(s => s.NumeroRegistro == registro.RegistroMercantil).FirstOrDefault();

                    if (empresa != null)
                    {
                        this.lblNombreEmpresa.Text = empresa.Sociedades.NombreSocial;
                    }
                }
                else
                {
                    var sociedad = db.Sociedades.Where(s => s.RegistroId == registro.RegistroId).FirstOrDefault();
                    this.lblNombreEmpresa.Text = this.lblNombreEmpresa.Text = sociedad.NombreSocial;
                }
            }

            //Aqui grabo el log de la transaccion que se creo
            LogTransaccionesMethods.GrabarLogTransacciones(IdTransaciones, Request.RawUrl, false, User.Identity.Name);
        }

        EnvioDatosUserControl getUserControl(int stepIndex)
        {
            var currentStep = this.Wizard1.WizardSteps[stepIndex];
            foreach (var item in currentStep.Controls)
            {
                if (item is EnvioDatosUserControl)
                {
                    return item as EnvioDatosUserControl;
                }
            }
            return null;
        }

        private void Wizard1_Load(object sender, EventArgs e)
        {
            getUserControl(0).ControlLoad(null);
        }

        private void Wizard1_ButtonClick(object sender, WizardNavigationEventArgs e)
        {
            // Validando si se puede pasar de página...
            e.Cancel = !getUserControl(e.CurrentStepIndex).ValidateNext();

            if (!e.Cancel)
            {
                // Ejecutando la carga de la siguiente...
                getUserControl(e.NextStepIndex).ControlLoad(null);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebWizard.Wizard1_PreRender(object, EventArgs)'
        protected void Wizard1_PreRender(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebWizard.Wizard1_PreRender(object, EventArgs)'
        {
            Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            SideBarList.DataSource = Wizard1.WizardSteps;
            SideBarList.DataBind();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebWizard.GetClassForWizardStep(object)'
        protected string GetClassForWizardStep(object wizardStep)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebWizard.GetClassForWizardStep(object)'
        {
            WizardStep step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }
            int stepIndex = Wizard1.WizardSteps.IndexOf(step);

            if (stepIndex < Wizard1.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > Wizard1.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
            }
        }
    }
}