﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseReportingConsole.ExpenseReportsService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExpenseReport", Namespace="http://schemas.datacontract.org/2004/07/ExpenseReportingService.Models")]
    [System.SerializableAttribute()]
    public partial class ExpenseReport : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime AddedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ExpenseReportIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Added {
            get {
                return this.AddedField;
            }
            set {
                if ((this.AddedField.Equals(value) != true)) {
                    this.AddedField = value;
                    this.RaisePropertyChanged("Added");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ExpenseReportId {
            get {
                return this.ExpenseReportIdField;
            }
            set {
                if ((this.ExpenseReportIdField.Equals(value) != true)) {
                    this.ExpenseReportIdField = value;
                    this.RaisePropertyChanged("ExpenseReportId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExpenseReportsService.IExpenseReportsService")]
    public interface IExpenseReportsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/GetData", ReplyAction="http://tempuri.org/IExpenseReportsService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/GetData", ReplyAction="http://tempuri.org/IExpenseReportsService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/Initilize", ReplyAction="http://tempuri.org/IExpenseReportsService/InitilizeResponse")]
        void Initilize();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/Initilize", ReplyAction="http://tempuri.org/IExpenseReportsService/InitilizeResponse")]
        System.Threading.Tasks.Task InitilizeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/QueryExpenseReports", ReplyAction="http://tempuri.org/IExpenseReportsService/QueryExpenseReportsResponse")]
        ExpenseReportingConsole.ExpenseReportsService.ExpenseReport[] QueryExpenseReports();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/QueryExpenseReports", ReplyAction="http://tempuri.org/IExpenseReportsService/QueryExpenseReportsResponse")]
        System.Threading.Tasks.Task<ExpenseReportingConsole.ExpenseReportsService.ExpenseReport[]> QueryExpenseReportsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/AddExpenseReport", ReplyAction="http://tempuri.org/IExpenseReportsService/AddExpenseReportResponse")]
        void AddExpenseReport(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/AddExpenseReport", ReplyAction="http://tempuri.org/IExpenseReportsService/AddExpenseReportResponse")]
        System.Threading.Tasks.Task AddExpenseReportAsync(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/DeleteExpenseReport", ReplyAction="http://tempuri.org/IExpenseReportsService/DeleteExpenseReportResponse")]
        void DeleteExpenseReport(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseReportsService/DeleteExpenseReport", ReplyAction="http://tempuri.org/IExpenseReportsService/DeleteExpenseReportResponse")]
        System.Threading.Tasks.Task DeleteExpenseReportAsync(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExpenseReportsServiceChannel : ExpenseReportingConsole.ExpenseReportsService.IExpenseReportsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExpenseReportsServiceClient : System.ServiceModel.ClientBase<ExpenseReportingConsole.ExpenseReportsService.IExpenseReportsService>, ExpenseReportingConsole.ExpenseReportsService.IExpenseReportsService {
        
        public ExpenseReportsServiceClient() {
        }
        
        public ExpenseReportsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExpenseReportsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseReportsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseReportsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public void Initilize() {
            base.Channel.Initilize();
        }
        
        public System.Threading.Tasks.Task InitilizeAsync() {
            return base.Channel.InitilizeAsync();
        }
        
        public ExpenseReportingConsole.ExpenseReportsService.ExpenseReport[] QueryExpenseReports() {
            return base.Channel.QueryExpenseReports();
        }
        
        public System.Threading.Tasks.Task<ExpenseReportingConsole.ExpenseReportsService.ExpenseReport[]> QueryExpenseReportsAsync() {
            return base.Channel.QueryExpenseReportsAsync();
        }
        
        public void AddExpenseReport(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report) {
            base.Channel.AddExpenseReport(report);
        }
        
        public System.Threading.Tasks.Task AddExpenseReportAsync(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report) {
            return base.Channel.AddExpenseReportAsync(report);
        }
        
        public void DeleteExpenseReport(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report) {
            base.Channel.DeleteExpenseReport(report);
        }
        
        public System.Threading.Tasks.Task DeleteExpenseReportAsync(ExpenseReportingConsole.ExpenseReportsService.ExpenseReport report) {
            return base.Channel.DeleteExpenseReportAsync(report);
        }
    }
}
