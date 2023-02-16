using GrpcService.Contract;
using ProtoBuf.Grpc;

namespace GrpcService.Services
{
    public class MultiplyService : IMultiplyService
    {
        public Task<MultiplyResult> MultiplyCalculateAsync(MultiplyRequest request, CallContext context = default)
        {
            var result = new MultiplyResult() { Result = request.X * request.Y };
            return Task.FromResult(result);
        }


    }
}
