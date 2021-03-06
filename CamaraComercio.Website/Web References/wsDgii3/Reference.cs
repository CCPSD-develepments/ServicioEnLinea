//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CamaraComercio.Website.wsDgii3 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="wsDGIISoap", Namespace="http://DGII.GOV.DO/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(rTemplate))]
    public partial class wsDGII : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GeneraAutorizacionPagoOperationCompleted;
        
        private System.Threading.SendOrPostCallback CalcularAutorizacionPagoOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaAutorizacionPagoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public wsDGII() {
            this.Url = global::CamaraComercio.Website.Properties.Settings.Default.CamaraComercio_Website_wsDgii3_wsDGII;
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
        public event GeneraAutorizacionPagoCompletedEventHandler GeneraAutorizacionPagoCompleted;
        
        /// <remarks/>
        public event CalcularAutorizacionPagoCompletedEventHandler CalcularAutorizacionPagoCompleted;
        
        /// <remarks/>
        public event ConsultaAutorizacionPagoCompletedEventHandler ConsultaAutorizacionPagoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://DGII.GOV.DO/GeneraAutorizacionPago", RequestNamespace="http://DGII.GOV.DO/", ResponseNamespace="http://DGII.GOV.DO/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public rGeneraAutorizacionPago GeneraAutorizacionPago(string pUsuario, string pPassword, string pRnc, decimal pMontoCapital) {
            object[] results = this.Invoke("GeneraAutorizacionPago", new object[] {
                        pUsuario,
                        pPassword,
                        pRnc,
                        pMontoCapital});
            return ((rGeneraAutorizacionPago)(results[0]));
        }
        
        /// <remarks/>
        public void GeneraAutorizacionPagoAsync(string pUsuario, string pPassword, string pRnc, decimal pMontoCapital) {
            this.GeneraAutorizacionPagoAsync(pUsuario, pPassword, pRnc, pMontoCapital, null);
        }
        
        /// <remarks/>
        public void GeneraAutorizacionPagoAsync(string pUsuario, string pPassword, string pRnc, decimal pMontoCapital, object userState) {
            if ((this.GeneraAutorizacionPagoOperationCompleted == null)) {
                this.GeneraAutorizacionPagoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGeneraAutorizacionPagoOperationCompleted);
            }
            this.InvokeAsync("GeneraAutorizacionPago", new object[] {
                        pUsuario,
                        pPassword,
                        pRnc,
                        pMontoCapital}, this.GeneraAutorizacionPagoOperationCompleted, userState);
        }
        
        private void OnGeneraAutorizacionPagoOperationCompleted(object arg) {
            if ((this.GeneraAutorizacionPagoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GeneraAutorizacionPagoCompleted(this, new GeneraAutorizacionPagoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://DGII.GOV.DO/CalcularAutorizacionPago", RequestNamespace="http://DGII.GOV.DO/", ResponseNamespace="http://DGII.GOV.DO/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public decimal CalcularAutorizacionPago(decimal pMontoCapital) {
            object[] results = this.Invoke("CalcularAutorizacionPago", new object[] {
                        pMontoCapital});
            return ((decimal)(results[0]));
        }
        
        /// <remarks/>
        public void CalcularAutorizacionPagoAsync(decimal pMontoCapital) {
            this.CalcularAutorizacionPagoAsync(pMontoCapital, null);
        }
        
        /// <remarks/>
        public void CalcularAutorizacionPagoAsync(decimal pMontoCapital, object userState) {
            if ((this.CalcularAutorizacionPagoOperationCompleted == null)) {
                this.CalcularAutorizacionPagoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCalcularAutorizacionPagoOperationCompleted);
            }
            this.InvokeAsync("CalcularAutorizacionPago", new object[] {
                        pMontoCapital}, this.CalcularAutorizacionPagoOperationCompleted, userState);
        }
        
        private void OnCalcularAutorizacionPagoOperationCompleted(object arg) {
            if ((this.CalcularAutorizacionPagoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CalcularAutorizacionPagoCompleted(this, new CalcularAutorizacionPagoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://DGII.GOV.DO/ConsultaAutorizacionPago", RequestNamespace="http://DGII.GOV.DO/", ResponseNamespace="http://DGII.GOV.DO/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public rGeneraAutorizacionPago ConsultaAutorizacionPago(string pUsuario, string pPassword, string pNumeroAutorizacion) {
            object[] results = this.Invoke("ConsultaAutorizacionPago", new object[] {
                        pUsuario,
                        pPassword,
                        pNumeroAutorizacion});
            return ((rGeneraAutorizacionPago)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaAutorizacionPagoAsync(string pUsuario, string pPassword, string pNumeroAutorizacion) {
            this.ConsultaAutorizacionPagoAsync(pUsuario, pPassword, pNumeroAutorizacion, null);
        }
        
        /// <remarks/>
        public void ConsultaAutorizacionPagoAsync(string pUsuario, string pPassword, string pNumeroAutorizacion, object userState) {
            if ((this.ConsultaAutorizacionPagoOperationCompleted == null)) {
                this.ConsultaAutorizacionPagoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaAutorizacionPagoOperationCompleted);
            }
            this.InvokeAsync("ConsultaAutorizacionPago", new object[] {
                        pUsuario,
                        pPassword,
                        pNumeroAutorizacion}, this.ConsultaAutorizacionPagoOperationCompleted, userState);
        }
        
        private void OnConsultaAutorizacionPagoOperationCompleted(object arg) {
            if ((this.ConsultaAutorizacionPagoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaAutorizacionPagoCompleted(this, new ConsultaAutorizacionPagoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://DGII.GOV.DO/")]
    public partial class rGeneraAutorizacionPago : rTemplate {
        
        private string numeroAutorizacionField;
        
        private decimal montoAutorizacionPagoField;
        
        private System.DateTime fechaLimiteAutorizacionField;
        
        private System.DateTime fechaPagoAutorizacionField;
        
        private int pagadaField;
        
        /// <remarks/>
        public string NumeroAutorizacion {
            get {
                return this.numeroAutorizacionField;
            }
            set {
                this.numeroAutorizacionField = value;
            }
        }
        
        /// <remarks/>
        public decimal MontoAutorizacionPago {
            get {
                return this.montoAutorizacionPagoField;
            }
            set {
                this.montoAutorizacionPagoField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime FechaLimiteAutorizacion {
            get {
                return this.fechaLimiteAutorizacionField;
            }
            set {
                this.fechaLimiteAutorizacionField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime FechaPagoAutorizacion {
            get {
                return this.fechaPagoAutorizacionField;
            }
            set {
                this.fechaPagoAutorizacionField = value;
            }
        }
        
        /// <remarks/>
        public int Pagada {
            get {
                return this.pagadaField;
            }
            set {
                this.pagadaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(rGeneraAutorizacionPago))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://DGII.GOV.DO/")]
    public abstract partial class rTemplate {
        
        private int codigoMensajeField;
        
        private string descripcionMensajeField;
        
        private string rNC_CedulaField;
        
        private string nombreRazonSocialField;
        
        /// <remarks/>
        public int CodigoMensaje {
            get {
                return this.codigoMensajeField;
            }
            set {
                this.codigoMensajeField = value;
            }
        }
        
        /// <remarks/>
        public string DescripcionMensaje {
            get {
                return this.descripcionMensajeField;
            }
            set {
                this.descripcionMensajeField = value;
            }
        }
        
        /// <remarks/>
        public string RNC_Cedula {
            get {
                return this.rNC_CedulaField;
            }
            set {
                this.rNC_CedulaField = value;
            }
        }
        
        /// <remarks/>
        public string NombreRazonSocial {
            get {
                return this.nombreRazonSocialField;
            }
            set {
                this.nombreRazonSocialField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GeneraAutorizacionPagoCompletedEventHandler(object sender, GeneraAutorizacionPagoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GeneraAutorizacionPagoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GeneraAutorizacionPagoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public rGeneraAutorizacionPago Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((rGeneraAutorizacionPago)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void CalcularAutorizacionPagoCompletedEventHandler(object sender, CalcularAutorizacionPagoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CalcularAutorizacionPagoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CalcularAutorizacionPagoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public decimal Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ConsultaAutorizacionPagoCompletedEventHandler(object sender, ConsultaAutorizacionPagoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaAutorizacionPagoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaAutorizacionPagoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public rGeneraAutorizacionPago Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((rGeneraAutorizacionPago)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591