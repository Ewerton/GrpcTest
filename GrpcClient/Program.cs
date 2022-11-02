using System.Reflection;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Delay();
            CallGrpcService();
        }

        public static void Delay()
        {
            System.Threading.Thread.Sleep(3000);
        }

        public static void CallGrpcService()
        {
            string serviceUrl = System.Environment.GetEnvironmentVariable("GrpcServiceUrl");

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress(serviceUrl);
            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


    }
}