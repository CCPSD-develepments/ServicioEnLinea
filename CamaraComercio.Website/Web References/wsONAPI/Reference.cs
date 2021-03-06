//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.235.
// 
#pragma warning disable 1591

namespace CamaraComercio.Website.wsONAPI {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicioCCSoap", Namespace="http://www.onapi.gob/")]
    public partial class ServicioCC : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback BuscarNombresComercialesOperationCompleted;
        
        private System.Threading.SendOrPostCallback BuscarNombrePorNumeroOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServicioCC() {
            this.Url = global::CamaraComercio.Website.Properties.Settings.Default.CamaraComercio_Website_wsONAPI_ServicioCC;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event BuscarNombresComercialesCompletedEventHandler BuscarNombresComercialesCompleted;
        
        /// <remarks/>
        public event BuscarNombrePorNumeroCompletedEventHandler BuscarNombrePorNumeroCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.onapi.gob/BuscarNombresComerciales", RequestNamespace="http://www.onapi.gob/", ResponseNamespace="http://www.onapi.gob/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ResultadoBusquedaNombre[] BuscarNombresComerciales(string texto) {
            object[] results = this.Invoke("BuscarNombresComerciales", new object[] {
                        texto});
            return ((ResultadoBusquedaNombre[])(results[0]));
        }
        
        /// <remarks/>
        public void BuscarNombresComercialesAsync(string texto) {
            this.BuscarNombresComercialesAsync(texto, null);
        }
        
        /// <remarks/>
        public void BuscarNombresComercialesAsync(string texto, object userState) {
            if ((this.BuscarNombresComercialesOperationCompleted == null)) {
                this.BuscarNombresComercialesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBuscarNombresComercialesOperationCompleted);
            }
            this.InvokeAsync("BuscarNombresComerciales", new object[] {
                        texto}, this.BuscarNombresComercialesOperationCompleted, userState);
        }
        
        private void OnBuscarNombresComercialesOperationCompleted(object arg) {
            if ((this.BuscarNombresComercialesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BuscarNombresComercialesCompleted(this, new BuscarNombresComercialesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.onapi.gob/BuscarNombrePorNumero", RequestNamespace="http://www.onapi.gob/", ResponseNamespace="http://www.onapi.gob/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ResultadoBusquedaNombre BuscarNombrePorNumero(int numero) {
            object[] results = this.Invoke("BuscarNombrePorNumero", new object[] {
                        numero});
            return ((ResultadoBusquedaNombre)(results[0]));
        }
        
        /// <remarks/>
        public void BuscarNombrePorNumeroAsync(int numero) {
            this.BuscarNombrePorNumeroAsync(numero, null);
        }
        
        /// <remarks/>
        public void BuscarNombrePorNumeroAsync(int numero, object userState) {
            if ((this.BuscarNombrePorNumeroOperationCompleted == null)) {
                this.BuscarNombrePorNumeroOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBuscarNombrePorNumeroOperationCompleted);
            }
            this.InvokeAsync("BuscarNombrePorNumero", new object[] {
                        numero}, this.BuscarNombrePorNumeroOperationCompleted, userState);
        }
        
        private void OnBuscarNombrePorNumeroOperationCompleted(object arg) {
            if ((this.BuscarNombrePorNumeroCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BuscarNombrePorNumeroCompleted(this, new BuscarNombrePorNumeroCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onapi.gob/")]
    public partial class ResultadoBusquedaNombre {
        
        private int numeroField;
        
        private string textoField;
        
        private System.DateTime expedicionField;
        
        private string titularField;
        
        private string gestorField;
        
        private string actividadField;
        
        private System.DateTime vencimientoField;
        
        /// <remarks/>
        public int Numero {
            get {
                return this.numeroField;
            }
            set {
                this.numeroField = value;
            }
        }
        
        /// <remarks/>
        public string Texto {
            get {
                return this.textoField;
            }
            set {
                this.textoField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Expedicion {
            get {
                return this.expedicionField;
            }
            set {
                this.expedicionField = value;
            }
        }
        
        /// <remarks/>
        public string Titular {
            get {
                return this.titularField;
            }
            set {
                this.titularField = value;
            }
        }
        
        /// <remarks/>
        public string Gestor {
            get {
                return this.gestorField;
            }
            set {
                this.gestorField = value;
            }
        }
        
        /// <remarks/>
        public string Actividad {
            get {
                return this.actividadField;
            }
            set {
                this.actividadField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Vencimiento {
            get {
                return this.vencimientoField;
            }
            set {
                this.vencimientoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void BuscarNombresComercialesCompletedEventHandler(object sender, BuscarNombresComercialesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BuscarNombresComercialesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BuscarNombresComercialesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ResultadoBusquedaNombre[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ResultadoBusquedaNombre[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void BuscarNombrePorNumeroCompletedEventHandler(object sender, BuscarNombrePorNumeroCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BuscarNombrePorNumeroCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BuscarNombrePorNumeroCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ResultadoBusquedaNombre Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ResultadoBusquedaNombre)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591