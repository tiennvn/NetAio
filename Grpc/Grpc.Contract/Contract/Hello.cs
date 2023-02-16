using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace GrpcService.Contract;

[DataContract]
public class HelloDataReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; } = "";
}

[DataContract]
public class HelloDataRequest
{
    [DataMember(Order = 1)]
    public string Name { get; set; } = "";
}

[ServiceContract]
public interface IHelloService
{
    [OperationContract]
    Task<HelloDataReply> SayHelloNewAsync(HelloDataRequest request, CallContext context = default);
}