using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace GrpcService.Contract
{
    [DataContract]
    public class MultiplyRequest
    {
        [DataMember(Order = 1)]
        public int X { get; set; }

        [DataMember(Order = 2)]
        public int Y { get; set; }
    }

    [DataContract]
    public class MultiplyResult
    {
        [DataMember(Order = 1)]
        public int Result { get; set; }
    }

    [ServiceContract]
    public interface IMultiplyService
    {
        [OperationContract]
        Task<MultiplyResult> MultiplyCalculateAsync(MultiplyRequest request, CallContext context = default);
    }
}
