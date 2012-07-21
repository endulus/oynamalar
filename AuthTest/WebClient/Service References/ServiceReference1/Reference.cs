﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAuthService")]
    public interface IAuthService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/Logon", ReplyAction="http://tempuri.org/IAuthService/LogonResponse")]
        string Logon(string username, string password, string mode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/ValidateTransfer", ReplyAction="http://tempuri.org/IAuthService/ValidateTransferResponse")]
        string ValidateTransfer(string sourceAppId, string userId, string transferId, string transferToken);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthServiceChannel : WebClient.ServiceReference1.IAuthService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthServiceClient : System.ServiceModel.ClientBase<WebClient.ServiceReference1.IAuthService>, WebClient.ServiceReference1.IAuthService {
        
        public AuthServiceClient() {
        }
        
        public AuthServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Logon(string username, string password, string mode) {
            return base.Channel.Logon(username, password, mode);
        }
        
        public string ValidateTransfer(string sourceAppId, string userId, string transferId, string transferToken) {
            return base.Channel.ValidateTransfer(sourceAppId, userId, transferId, transferToken);
        }
    }
}