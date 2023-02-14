using GrpcService.Contract;
using ProtoBuf.Grpc;

namespace GrpcService.GrpcServices
{
    public class HelloService : IHelloService
    {
        public Task<Contract.HelloReply> SayHelloNewAsync(Contract.HelloRequest request, CallContext context = default)
        {
            var result = new Contract.HelloReply
            {
                Message = $"Hello {request.Name}"
            };

            return Task.FromResult(result);
        }
    }
}
