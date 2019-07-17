using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using WebApplication1;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.DocketHttpHandler.Http2UnencryptedSupport", true);

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:50051");
            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

            var reply2 = client.GetBytesAsync(new HelloRequest { Name = "bob" });
           
            Console.WriteLine("Greeting: " + reply.Message);
            Console.ReadKey();
        }
    }
}
