//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CamaraComercio.Website.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://content/wsdeploy/wscsi.asmx")]
        public string CamaraComercio_Website_svrkofax_wsCSI {
            get {
                return ((string)(this["CamaraComercio_Website_svrkofax_wsCSI"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://content/VisorWeb/DocumentWebService.asmx")]
        public string CamaraComercio_Website_kofaxVisorWeb_DocumentWebService {
            get {
                return ((string)(this["CamaraComercio_Website_kofaxVisorWeb_DocumentWebService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.onapi.gob.do/cte/serviciocc.asmx")]
        public string CamaraComercio_Website_wsOnapi2_ServicioCC {
            get {
                return ((string)(this["CamaraComercio_Website_wsOnapi2_ServicioCC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.dgii.gov.do/wsCamaraComercioTest/WSdgii.asmx")]
        public string CamaraComercio_Website_wsDgii3_wsDGII {
            get {
                return ((string)(this["CamaraComercio_Website_wsDgii3_wsDGII"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://websrm24:1042/wsRegistroMercantil.asmx")]
        public string CamaraComercio_Website_wsReporteRM_wsRegistroMercantil {
            get {
                return ((string)(this["CamaraComercio_Website_wsReporteRM_wsRegistroMercantil"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:37249/Facturacion/ServicioFacturacion.asmx")]
        public string CamaraComercio_Website_wsFacturacion_ServicioFacturacion {
            get {
                return ((string)(this["CamaraComercio_Website_wsFacturacion_ServicioFacturacion"]));
            }
        }
    }
}
