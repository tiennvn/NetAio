using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace GrpcService.Contract;

[DataContract]
public class HelloReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; } = "";
}

[DataContract]
public class HelloRequest
{
    [DataMember(Order = 1)]
    public string Name { get; set; } = "";
}

[ServiceContract]
public interface IHelloService
{
    [OperationContract]
    Task<HelloReply> SayHelloNewAsync(HelloRequest request, CallContext context = default);
}