using Grpc.Net.Client;
using GrpcService.Contract;
using ProtoBuf.Grpc.Client;

namespace GrpcClient
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:6003");
            var client = channel.CreateGrpcService<IHelloService>();

            var reply = await client.SayHelloNewAsync(new HelloDataRequest { Name = "Grpc client test" });

            Console.WriteLine($"Reply object: {@reply}", reply);

            Console.WriteLine($"Reply Message: {reply.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}