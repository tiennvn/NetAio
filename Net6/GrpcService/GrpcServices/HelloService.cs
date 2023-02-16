using GrpcService.Contract;
using ProtoBuf.Grpc;

namespace GrpcService.Services
{
    public class HelloService : IHelloService
    {
        public Task<HelloDataReply> SayHelloNewAsync(HelloDataRequest request, CallContext context = default)
        {
            var result = new HelloDataReply
            {
                Message = $"HelloDataReply {request.Name}"
            };

            return Task.FromResult(result);
        }
    }
}
