﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthClient.LogicServiceNS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LogicServiceNS.ILogicService")]
    public interface ILogicService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogicService/DoWork", ReplyAction="http://tempuri.org/ILogicService/DoWorkResponse")]
        void DoWork();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILogicServiceChannel : AuthClient.LogicServiceNS.ILogicService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogicServiceClient : System.ServiceModel.ClientBase<AuthClient.LogicServiceNS.ILogicService>, AuthClient.LogicServiceNS.ILogicService {
        
        public LogicServiceClient() {
        }
        
        public LogicServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LogicServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogicServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogicServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
    }
}
