﻿//------------------------------------------------------------------------------
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

namespace BarcodeLCDDashboardMono.VRArcadeServer {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IDashboardService", Namespace="http://tempuri.org/")]
    public partial class DashboardService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PopulateContentOperationCompleted;
        
        private System.Threading.SendOrPostCallback BarcodeInputOperationCompleted;
        
        private System.Threading.SendOrPostCallback MarkCleanProvidedOperationCompleted;
        
        private System.Threading.SendOrPostCallback MarkHelpProvidedOperationCompleted;
        
        private System.Threading.SendOrPostCallback PrintBarcodeWithBookingReferenceOperationCompleted;
        
        private System.Threading.SendOrPostCallback BarcodeDonePrintingOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DashboardService() {
            this.Url = global::BarcodeLCDDashboardMono.Properties.Settings.Default.BarcodeLCDDashboardMono_localhost_DashboardService;
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
        public event PopulateContentCompletedEventHandler PopulateContentCompleted;
        
        /// <remarks/>
        public event BarcodeInputCompletedEventHandler BarcodeInputCompleted;
        
        /// <remarks/>
        public event MarkCleanProvidedCompletedEventHandler MarkCleanProvidedCompleted;
        
        /// <remarks/>
        public event MarkHelpProvidedCompletedEventHandler MarkHelpProvidedCompleted;
        
        /// <remarks/>
        public event PrintBarcodeWithBookingReferenceCompletedEventHandler PrintBarcodeWithBookingReferenceCompleted;
        
        /// <remarks/>
        public event BarcodeDonePrintingCompletedEventHandler BarcodeDonePrintingCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDashboardService/PopulateContent", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public DashboardModuleInfo PopulateContent([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string IP) {
            object[] results = this.Invoke("PopulateContent", new object[] {
                        IP});
            return ((DashboardModuleInfo)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateContentAsync(string IP) {
            this.PopulateContentAsync(IP, null);
        }
        
        /// <remarks/>
        public void PopulateContentAsync(string IP, object userState) {
            if ((this.PopulateContentOperationCompleted == null)) {
                this.PopulateContentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateContentOperationCompleted);
            }
            this.InvokeAsync("PopulateContent", new object[] {
                        IP}, this.PopulateContentOperationCompleted, userState);
        }
        
        private void OnPopulateContentOperationCompleted(object arg) {
            if ((this.PopulateContentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateContentCompleted(this, new PopulateContentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDashboardService/BarcodeInput", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void BarcodeInput([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string IP, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Barcode) {
            this.Invoke("BarcodeInput", new object[] {
                        IP,
                        Barcode});
        }
        
        /// <remarks/>
        public void BarcodeInputAsync(string IP, string Barcode) {
            this.BarcodeInputAsync(IP, Barcode, null);
        }
        
        /// <remarks/>
        public void BarcodeInputAsync(string IP, string Barcode, object userState) {
            if ((this.BarcodeInputOperationCompleted == null)) {
                this.BarcodeInputOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBarcodeInputOperationCompleted);
            }
            this.InvokeAsync("BarcodeInput", new object[] {
                        IP,
                        Barcode}, this.BarcodeInputOperationCompleted, userState);
        }
        
        private void OnBarcodeInputOperationCompleted(object arg) {
            if ((this.BarcodeInputCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BarcodeInputCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDashboardService/MarkCleanProvided", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void MarkCleanProvided([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string IP) {
            this.Invoke("MarkCleanProvided", new object[] {
                        IP});
        }
        
        /// <remarks/>
        public void MarkCleanProvidedAsync(string IP) {
            this.MarkCleanProvidedAsync(IP, null);
        }
        
        /// <remarks/>
        public void MarkCleanProvidedAsync(string IP, object userState) {
            if ((this.MarkCleanProvidedOperationCompleted == null)) {
                this.MarkCleanProvidedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMarkCleanProvidedOperationCompleted);
            }
            this.InvokeAsync("MarkCleanProvided", new object[] {
                        IP}, this.MarkCleanProvidedOperationCompleted, userState);
        }
        
        private void OnMarkCleanProvidedOperationCompleted(object arg) {
            if ((this.MarkCleanProvidedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MarkCleanProvidedCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDashboardService/MarkHelpProvided", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void MarkHelpProvided([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string IP) {
            this.Invoke("MarkHelpProvided", new object[] {
                        IP});
        }
        
        /// <remarks/>
        public void MarkHelpProvidedAsync(string IP) {
            this.MarkHelpProvidedAsync(IP, null);
        }
        
        /// <remarks/>
        public void MarkHelpProvidedAsync(string IP, object userState) {
            if ((this.MarkHelpProvidedOperationCompleted == null)) {
                this.MarkHelpProvidedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMarkHelpProvidedOperationCompleted);
            }
            this.InvokeAsync("MarkHelpProvided", new object[] {
                        IP}, this.MarkHelpProvidedOperationCompleted, userState);
        }
        
        private void OnMarkHelpProvidedOperationCompleted(object arg) {
            if ((this.MarkHelpProvidedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MarkHelpProvidedCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDashboardService/PrintBarcodeWithBookingReference", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PrintBarcodeWithBookingReference([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string bookingRef, int waiverID, [System.Xml.Serialization.XmlIgnoreAttribute()] bool waiverIDSpecified) {
            object[] results = this.Invoke("PrintBarcodeWithBookingReference", new object[] {
                        bookingRef,
                        waiverID,
                        waiverIDSpecified});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PrintBarcodeWithBookingReferenceAsync(string bookingRef, int waiverID, bool waiverIDSpecified) {
            this.PrintBarcodeWithBookingReferenceAsync(bookingRef, waiverID, waiverIDSpecified, null);
        }
        
        /// <remarks/>
        public void PrintBarcodeWithBookingReferenceAsync(string bookingRef, int waiverID, bool waiverIDSpecified, object userState) {
            if ((this.PrintBarcodeWithBookingReferenceOperationCompleted == null)) {
                this.PrintBarcodeWithBookingReferenceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPrintBarcodeWithBookingReferenceOperationCompleted);
            }
            this.InvokeAsync("PrintBarcodeWithBookingReference", new object[] {
                        bookingRef,
                        waiverID,
                        waiverIDSpecified}, this.PrintBarcodeWithBookingReferenceOperationCompleted, userState);
        }
        
        private void OnPrintBarcodeWithBookingReferenceOperationCompleted(object arg) {
            if ((this.PrintBarcodeWithBookingReferenceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PrintBarcodeWithBookingReferenceCompleted(this, new PrintBarcodeWithBookingReferenceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDashboardService/BarcodeDonePrinting", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void BarcodeDonePrinting(int waiverID, [System.Xml.Serialization.XmlIgnoreAttribute()] bool waiverIDSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string bookingRef, bool isSuccess, [System.Xml.Serialization.XmlIgnoreAttribute()] bool isSuccessSpecified) {
            this.Invoke("BarcodeDonePrinting", new object[] {
                        waiverID,
                        waiverIDSpecified,
                        bookingRef,
                        isSuccess,
                        isSuccessSpecified});
        }
        
        /// <remarks/>
        public void BarcodeDonePrintingAsync(int waiverID, bool waiverIDSpecified, string bookingRef, bool isSuccess, bool isSuccessSpecified) {
            this.BarcodeDonePrintingAsync(waiverID, waiverIDSpecified, bookingRef, isSuccess, isSuccessSpecified, null);
        }
        
        /// <remarks/>
        public void BarcodeDonePrintingAsync(int waiverID, bool waiverIDSpecified, string bookingRef, bool isSuccess, bool isSuccessSpecified, object userState) {
            if ((this.BarcodeDonePrintingOperationCompleted == null)) {
                this.BarcodeDonePrintingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBarcodeDonePrintingOperationCompleted);
            }
            this.InvokeAsync("BarcodeDonePrinting", new object[] {
                        waiverID,
                        waiverIDSpecified,
                        bookingRef,
                        isSuccess,
                        isSuccessSpecified}, this.BarcodeDonePrintingOperationCompleted, userState);
        }
        
        private void OnBarcodeDonePrintingOperationCompleted(object arg) {
            if ((this.BarcodeDonePrintingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BarcodeDonePrintingCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/VRArcadeServer")]
    public partial class DashboardModuleInfo {
        
        private EnumsClientRunningMode currentRunningModeField;
        
        private bool currentRunningModeFieldSpecified;
        
        private string currentRunningTitleField;
        
        private bool isRequireAssistantField;
        
        private bool isRequireAssistantFieldSpecified;
        
        private EnumsLiveClientStatus liveClientStatusField;
        
        private bool liveClientStatusFieldSpecified;
        
        private System.DateTime timeStampField;
        
        private bool timeStampFieldSpecified;
        
        /// <remarks/>
        public EnumsClientRunningMode CurrentRunningMode {
            get {
                return this.currentRunningModeField;
            }
            set {
                this.currentRunningModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrentRunningModeSpecified {
            get {
                return this.currentRunningModeFieldSpecified;
            }
            set {
                this.currentRunningModeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CurrentRunningTitle {
            get {
                return this.currentRunningTitleField;
            }
            set {
                this.currentRunningTitleField = value;
            }
        }
        
        /// <remarks/>
        public bool IsRequireAssistant {
            get {
                return this.isRequireAssistantField;
            }
            set {
                this.isRequireAssistantField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsRequireAssistantSpecified {
            get {
                return this.isRequireAssistantFieldSpecified;
            }
            set {
                this.isRequireAssistantFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public EnumsLiveClientStatus LiveClientStatus {
            get {
                return this.liveClientStatusField;
            }
            set {
                this.liveClientStatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LiveClientStatusSpecified {
            get {
                return this.liveClientStatusFieldSpecified;
            }
            set {
                this.liveClientStatusFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TimeStamp {
            get {
                return this.timeStampField;
            }
            set {
                this.timeStampField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeStampSpecified {
            get {
                return this.timeStampFieldSpecified;
            }
            set {
                this.timeStampFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="Enums.ClientRunningMode", Namespace="http://schemas.datacontract.org/2004/07/VRGameSelectorServerDTO")]
    public enum EnumsClientRunningMode {
        
        /// <remarks/>
        NONE,
        
        /// <remarks/>
        TIMING_ON,
        
        /// <remarks/>
        NO_TIMING_ON,
        
        /// <remarks/>
        ENDED_MANUAL,
        
        /// <remarks/>
        ENDED_TIMING,
        
        /// <remarks/>
        ENDED_EMERGENCY,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="Enums.LiveClientStatus", Namespace="http://schemas.datacontract.org/2004/07/VRGameSelectorServerDTO")]
    public enum EnumsLiveClientStatus {
        
        /// <remarks/>
        NONE,
        
        /// <remarks/>
        OFFLINE,
        
        /// <remarks/>
        ONLINE,
        
        /// <remarks/>
        GAMEOVER_FOR_CLEANING,
        
        /// <remarks/>
        CLEANING_DONE,
        
        /// <remarks/>
        IN_GAME_SELECTOR,
        
        /// <remarks/>
        IN_GAME_STARTING,
        
        /// <remarks/>
        IN_GAME,
        
        /// <remarks/>
        GAME_EXITING,
        
        /// <remarks/>
        ERROR,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void PopulateContentCompletedEventHandler(object sender, PopulateContentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateContentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateContentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DashboardModuleInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DashboardModuleInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void BarcodeInputCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void MarkCleanProvidedCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void MarkHelpProvidedCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void PrintBarcodeWithBookingReferenceCompletedEventHandler(object sender, PrintBarcodeWithBookingReferenceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PrintBarcodeWithBookingReferenceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PrintBarcodeWithBookingReferenceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void BarcodeDonePrintingCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591