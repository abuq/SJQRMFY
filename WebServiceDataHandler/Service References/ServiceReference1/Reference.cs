﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceDataHandler.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="com.pdcss.axis.soap.webService", ConfigurationName="ServiceReference1.OpenAxisWebService")]
    public interface OpenAxisWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="getIndexValueReturn")]
        string getIndexValue(string index_code, string beg_year, string beg_month, string beg_day, string end_year, string end_month, string end_day, string fybm, string bmbm, string rybm, string others);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Vector))]
        [return: System.ServiceModel.MessageParameterAttribute(Name="getQueryInfoReturn")]
        object[] getQueryInfo(string json);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://xml.apache.org/xml-soap")]
    public partial class Vector : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object[] itemField;
        
        /// <remarks/>
        public object[] item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("item");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OpenAxisWebServiceChannel : WebServiceDataHandler.ServiceReference1.OpenAxisWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OpenAxisWebServiceClient : System.ServiceModel.ClientBase<WebServiceDataHandler.ServiceReference1.OpenAxisWebService>, WebServiceDataHandler.ServiceReference1.OpenAxisWebService {
        
        public OpenAxisWebServiceClient() {
        }
        
        public OpenAxisWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OpenAxisWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OpenAxisWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OpenAxisWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getIndexValue(string index_code, string beg_year, string beg_month, string beg_day, string end_year, string end_month, string end_day, string fybm, string bmbm, string rybm, string others) {
            return base.Channel.getIndexValue(index_code, beg_year, beg_month, beg_day, end_year, end_month, end_day, fybm, bmbm, rybm, others);
        }
        
        public object[] getQueryInfo(string json) {
            return base.Channel.getQueryInfo(json);
        }
    }
}
