﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthClient.TransferServiceNs {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TransferServiceNs.ITransferService")]
    public interface ITransferService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransferService/Transfer", ReplyAction="http://tempuri.org/ITransferService/TransferResponse")]
        string Transfer(string targetAppId, string transferToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransferService/ValidateTransfer", ReplyAction="http://tempuri.org/ITransferService/ValidateTransferResponse")]
        string ValidateTransfer(string sourceAppId, string transferToken);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITransferServiceChannel : AuthClient.TransferServiceNs.ITransferService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TransferServiceClient : System.ServiceModel.ClientBase<AuthClient.TransferServiceNs.ITransferService>, AuthClient.TransferServiceNs.ITransferService {
        
        public TransferServiceClient() {
        }
        
        public TransferServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TransferServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TransferServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TransferServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Transfer(string targetAppId, string transferToken) {
            return base.Channel.Transfer(targetAppId, transferToken);
        }
        
        public string ValidateTransfer(string sourceAppId, string transferToken) {
            return base.Channel.ValidateTransfer(sourceAppId, transferToken);
        }
    }
}
