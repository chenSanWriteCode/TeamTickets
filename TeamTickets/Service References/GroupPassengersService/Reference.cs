﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamTickets.GroupPassengersService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://api.lwsp.haiyisoft.com/", ConfigurationName="GroupPassengersService.GroupCertificateService")]
    public interface GroupCertificateService {
        
        // CODEGEN: 命名空间  的元素名称 return 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        TeamTickets.GroupPassengersService.testResponse test(TeamTickets.GroupPassengersService.test request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.testResponse> testAsync(TeamTickets.GroupPassengersService.test request);
        
        // CODEGEN: 命名空间  的元素名称 arg0 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        TeamTickets.GroupPassengersService.groupCertificateQueryResponse groupCertificateQuery(TeamTickets.GroupPassengersService.groupCertificateQuery request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateQueryResponse> groupCertificateQueryAsync(TeamTickets.GroupPassengersService.groupCertificateQuery request);
        
        // CODEGEN: 命名空间  的元素名称 arg0 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponse groupCertificateNumUpdate(TeamTickets.GroupPassengersService.groupCertificateNumUpdate request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponse> groupCertificateNumUpdateAsync(TeamTickets.GroupPassengersService.groupCertificateNumUpdate request);
        
        // CODEGEN: 命名空间  的元素名称 arg0 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        TeamTickets.GroupPassengersService.groupCertificateSaveResponse groupCertificateSave(TeamTickets.GroupPassengersService.groupCertificateSave request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateSaveResponse> groupCertificateSaveAsync(TeamTickets.GroupPassengersService.groupCertificateSave request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class test {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="test", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.testBody Body;
        
        public test() {
        }
        
        public test(TeamTickets.GroupPassengersService.testBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class testBody {
        
        public testBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class testResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="testResponse", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.testResponseBody Body;
        
        public testResponse() {
        }
        
        public testResponse(TeamTickets.GroupPassengersService.testResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class testResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public testResponseBody() {
        }
        
        public testResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class groupCertificateQuery {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="groupCertificateQuery", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.groupCertificateQueryBody Body;
        
        public groupCertificateQuery() {
        }
        
        public groupCertificateQuery(TeamTickets.GroupPassengersService.groupCertificateQueryBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class groupCertificateQueryBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public groupCertificateQueryBody() {
        }
        
        public groupCertificateQueryBody(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class groupCertificateQueryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="groupCertificateQueryResponse", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.groupCertificateQueryResponseBody Body;
        
        public groupCertificateQueryResponse() {
        }
        
        public groupCertificateQueryResponse(TeamTickets.GroupPassengersService.groupCertificateQueryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class groupCertificateQueryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public groupCertificateQueryResponseBody() {
        }
        
        public groupCertificateQueryResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class groupCertificateNumUpdate {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="groupCertificateNumUpdate", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.groupCertificateNumUpdateBody Body;
        
        public groupCertificateNumUpdate() {
        }
        
        public groupCertificateNumUpdate(TeamTickets.GroupPassengersService.groupCertificateNumUpdateBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class groupCertificateNumUpdateBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public groupCertificateNumUpdateBody() {
        }
        
        public groupCertificateNumUpdateBody(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class groupCertificateNumUpdateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="groupCertificateNumUpdateResponse", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponseBody Body;
        
        public groupCertificateNumUpdateResponse() {
        }
        
        public groupCertificateNumUpdateResponse(TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class groupCertificateNumUpdateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public groupCertificateNumUpdateResponseBody() {
        }
        
        public groupCertificateNumUpdateResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class groupCertificateSave {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="groupCertificateSave", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.groupCertificateSaveBody Body;
        
        public groupCertificateSave() {
        }
        
        public groupCertificateSave(TeamTickets.GroupPassengersService.groupCertificateSaveBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class groupCertificateSaveBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public groupCertificateSaveBody() {
        }
        
        public groupCertificateSaveBody(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class groupCertificateSaveResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="groupCertificateSaveResponse", Namespace="http://api.lwsp.haiyisoft.com/", Order=0)]
        public TeamTickets.GroupPassengersService.groupCertificateSaveResponseBody Body;
        
        public groupCertificateSaveResponse() {
        }
        
        public groupCertificateSaveResponse(TeamTickets.GroupPassengersService.groupCertificateSaveResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class groupCertificateSaveResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public groupCertificateSaveResponseBody() {
        }
        
        public groupCertificateSaveResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GroupCertificateServiceChannel : TeamTickets.GroupPassengersService.GroupCertificateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GroupCertificateServiceClient : System.ServiceModel.ClientBase<TeamTickets.GroupPassengersService.GroupCertificateService>, TeamTickets.GroupPassengersService.GroupCertificateService {
        
        public GroupCertificateServiceClient() {
        }
        
        public GroupCertificateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GroupCertificateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GroupCertificateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GroupCertificateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TeamTickets.GroupPassengersService.testResponse TeamTickets.GroupPassengersService.GroupCertificateService.test(TeamTickets.GroupPassengersService.test request) {
            return base.Channel.test(request);
        }
        
        public string test() {
            TeamTickets.GroupPassengersService.test inValue = new TeamTickets.GroupPassengersService.test();
            inValue.Body = new TeamTickets.GroupPassengersService.testBody();
            TeamTickets.GroupPassengersService.testResponse retVal = ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).test(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.testResponse> TeamTickets.GroupPassengersService.GroupCertificateService.testAsync(TeamTickets.GroupPassengersService.test request) {
            return base.Channel.testAsync(request);
        }
        
        public System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.testResponse> testAsync() {
            TeamTickets.GroupPassengersService.test inValue = new TeamTickets.GroupPassengersService.test();
            inValue.Body = new TeamTickets.GroupPassengersService.testBody();
            return ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).testAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TeamTickets.GroupPassengersService.groupCertificateQueryResponse TeamTickets.GroupPassengersService.GroupCertificateService.groupCertificateQuery(TeamTickets.GroupPassengersService.groupCertificateQuery request) {
            return base.Channel.groupCertificateQuery(request);
        }
        
        public string groupCertificateQuery(string arg0) {
            TeamTickets.GroupPassengersService.groupCertificateQuery inValue = new TeamTickets.GroupPassengersService.groupCertificateQuery();
            inValue.Body = new TeamTickets.GroupPassengersService.groupCertificateQueryBody();
            inValue.Body.arg0 = arg0;
            TeamTickets.GroupPassengersService.groupCertificateQueryResponse retVal = ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).groupCertificateQuery(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateQueryResponse> TeamTickets.GroupPassengersService.GroupCertificateService.groupCertificateQueryAsync(TeamTickets.GroupPassengersService.groupCertificateQuery request) {
            return base.Channel.groupCertificateQueryAsync(request);
        }
        
        public System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateQueryResponse> groupCertificateQueryAsync(string arg0) {
            TeamTickets.GroupPassengersService.groupCertificateQuery inValue = new TeamTickets.GroupPassengersService.groupCertificateQuery();
            inValue.Body = new TeamTickets.GroupPassengersService.groupCertificateQueryBody();
            inValue.Body.arg0 = arg0;
            return ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).groupCertificateQueryAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponse TeamTickets.GroupPassengersService.GroupCertificateService.groupCertificateNumUpdate(TeamTickets.GroupPassengersService.groupCertificateNumUpdate request) {
            return base.Channel.groupCertificateNumUpdate(request);
        }
        
        public string groupCertificateNumUpdate(string arg0) {
            TeamTickets.GroupPassengersService.groupCertificateNumUpdate inValue = new TeamTickets.GroupPassengersService.groupCertificateNumUpdate();
            inValue.Body = new TeamTickets.GroupPassengersService.groupCertificateNumUpdateBody();
            inValue.Body.arg0 = arg0;
            TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponse retVal = ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).groupCertificateNumUpdate(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponse> TeamTickets.GroupPassengersService.GroupCertificateService.groupCertificateNumUpdateAsync(TeamTickets.GroupPassengersService.groupCertificateNumUpdate request) {
            return base.Channel.groupCertificateNumUpdateAsync(request);
        }
        
        public System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateNumUpdateResponse> groupCertificateNumUpdateAsync(string arg0) {
            TeamTickets.GroupPassengersService.groupCertificateNumUpdate inValue = new TeamTickets.GroupPassengersService.groupCertificateNumUpdate();
            inValue.Body = new TeamTickets.GroupPassengersService.groupCertificateNumUpdateBody();
            inValue.Body.arg0 = arg0;
            return ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).groupCertificateNumUpdateAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TeamTickets.GroupPassengersService.groupCertificateSaveResponse TeamTickets.GroupPassengersService.GroupCertificateService.groupCertificateSave(TeamTickets.GroupPassengersService.groupCertificateSave request) {
            return base.Channel.groupCertificateSave(request);
        }
        
        public string groupCertificateSave(string arg0) {
            TeamTickets.GroupPassengersService.groupCertificateSave inValue = new TeamTickets.GroupPassengersService.groupCertificateSave();
            inValue.Body = new TeamTickets.GroupPassengersService.groupCertificateSaveBody();
            inValue.Body.arg0 = arg0;
            TeamTickets.GroupPassengersService.groupCertificateSaveResponse retVal = ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).groupCertificateSave(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateSaveResponse> TeamTickets.GroupPassengersService.GroupCertificateService.groupCertificateSaveAsync(TeamTickets.GroupPassengersService.groupCertificateSave request) {
            return base.Channel.groupCertificateSaveAsync(request);
        }
        
        public System.Threading.Tasks.Task<TeamTickets.GroupPassengersService.groupCertificateSaveResponse> groupCertificateSaveAsync(string arg0) {
            TeamTickets.GroupPassengersService.groupCertificateSave inValue = new TeamTickets.GroupPassengersService.groupCertificateSave();
            inValue.Body = new TeamTickets.GroupPassengersService.groupCertificateSaveBody();
            inValue.Body.arg0 = arg0;
            return ((TeamTickets.GroupPassengersService.GroupCertificateService)(this)).groupCertificateSaveAsync(inValue);
        }
    }
}
