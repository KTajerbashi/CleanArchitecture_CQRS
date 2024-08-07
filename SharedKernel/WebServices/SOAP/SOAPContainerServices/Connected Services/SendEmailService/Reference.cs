﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SendEmailService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmailOption", Namespace="http://tempuri.org/")]
    internal partial class EmailOption : object
    {
        
        private string UsernameField;
        
        private string PasswordField;
        
        private string TextMessageField;
        
        private string ContactNumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        internal string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        internal string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        internal string TextMessage
        {
            get
            {
                return this.TextMessageField;
            }
            set
            {
                this.TextMessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        internal string ContactNumber
        {
            get
            {
                return this.ContactNumberField;
            }
            set
            {
                this.ContactNumberField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmailResult", Namespace="http://tempuri.org/")]
    internal partial class EmailResult : object
    {
        
        private string ContactNumberField;
        
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        internal string ContactNumber
        {
            get
            {
                return this.ContactNumberField;
            }
            set
            {
                this.ContactNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        internal bool IsSuccess
        {
            get
            {
                return this.IsSuccessField;
            }
            set
            {
                this.IsSuccessField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SendEmailService.SendEmail_ServiceSoap")]
    internal interface SendEmail_ServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Send", ReplyAction="*")]
        System.Threading.Tasks.Task<SendEmailService.SendResponse> SendAsync(SendEmailService.SendRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Recieve", ReplyAction="*")]
        System.Threading.Tasks.Task<SendEmailService.RecieveResponse> RecieveAsync(SendEmailService.RecieveRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    internal partial class SendRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Send", Namespace="http://tempuri.org/", Order=0)]
        public SendEmailService.SendRequestBody Body;
        
        public SendRequest()
        {
        }
        
        public SendRequest(SendEmailService.SendRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    internal partial class SendRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SendEmailService.EmailOption email;
        
        public SendRequestBody()
        {
        }
        
        public SendRequestBody(SendEmailService.EmailOption email)
        {
            this.email = email;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    internal partial class SendResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendResponse", Namespace="http://tempuri.org/", Order=0)]
        public SendEmailService.SendResponseBody Body;
        
        public SendResponse()
        {
        }
        
        public SendResponse(SendEmailService.SendResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    internal partial class SendResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SendEmailService.EmailResult SendResult;
        
        public SendResponseBody()
        {
        }
        
        public SendResponseBody(SendEmailService.EmailResult SendResult)
        {
            this.SendResult = SendResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    internal partial class RecieveRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Recieve", Namespace="http://tempuri.org/", Order=0)]
        public SendEmailService.RecieveRequestBody Body;
        
        public RecieveRequest()
        {
        }
        
        public RecieveRequest(SendEmailService.RecieveRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    internal partial class RecieveRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int a;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int b;
        
        public RecieveRequestBody()
        {
        }
        
        public RecieveRequestBody(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    internal partial class RecieveResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RecieveResponse", Namespace="http://tempuri.org/", Order=0)]
        public SendEmailService.RecieveResponseBody Body;
        
        public RecieveResponse()
        {
        }
        
        public RecieveResponse(SendEmailService.RecieveResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    internal partial class RecieveResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SendEmailService.EmailResult RecieveResult;
        
        public RecieveResponseBody()
        {
        }
        
        public RecieveResponseBody(SendEmailService.EmailResult RecieveResult)
        {
            this.RecieveResult = RecieveResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    internal interface SendEmail_ServiceSoapChannel : SendEmailService.SendEmail_ServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    internal partial class SendEmail_ServiceSoapClient : System.ServiceModel.ClientBase<SendEmailService.SendEmail_ServiceSoap>, SendEmailService.SendEmail_ServiceSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SendEmail_ServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(SendEmail_ServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), SendEmail_ServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SendEmail_ServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SendEmail_ServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SendEmail_ServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SendEmail_ServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SendEmail_ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SendEmailService.SendResponse> SendEmailService.SendEmail_ServiceSoap.SendAsync(SendEmailService.SendRequest request)
        {
            return base.Channel.SendAsync(request);
        }
        
        public System.Threading.Tasks.Task<SendEmailService.SendResponse> SendAsync(SendEmailService.EmailOption email)
        {
            SendEmailService.SendRequest inValue = new SendEmailService.SendRequest();
            inValue.Body = new SendEmailService.SendRequestBody();
            inValue.Body.email = email;
            return ((SendEmailService.SendEmail_ServiceSoap)(this)).SendAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SendEmailService.RecieveResponse> SendEmailService.SendEmail_ServiceSoap.RecieveAsync(SendEmailService.RecieveRequest request)
        {
            return base.Channel.RecieveAsync(request);
        }
        
        public System.Threading.Tasks.Task<SendEmailService.RecieveResponse> RecieveAsync(int a, int b)
        {
            SendEmailService.RecieveRequest inValue = new SendEmailService.RecieveRequest();
            inValue.Body = new SendEmailService.RecieveRequestBody();
            inValue.Body.a = a;
            inValue.Body.b = b;
            return ((SendEmailService.SendEmail_ServiceSoap)(this)).RecieveAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.SendEmail_ServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.SendEmail_ServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.SendEmail_ServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44343/SOAPs/SendEmail_Service.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.SendEmail_ServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44343/SOAPs/SendEmail_Service.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            SendEmail_ServiceSoap,
            
            SendEmail_ServiceSoap12,
        }
    }
}
