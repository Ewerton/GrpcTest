using System.Globalization;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;

namespace GrpcClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Delay();
             CallGrpcService1();
            //CallGrpcService2();
        }

        public static void Delay()
        {
            System.Threading.Thread.Sleep(3000);
        }

        public static void CallGrpcService1()
        {
            string address = System.Environment.GetEnvironmentVariable("GrpcServiceUrl");
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress(address);
            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void CallGrpcService2()
        {
            string address = System.Environment.GetEnvironmentVariable("GrpcServiceUrl");

            var channel = CreateAuthenticatedChannel(address);
            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
        }

        private static GrpcChannel CreateAuthenticatedChannel(string address)
        {
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(""))
                {
                    metadata.Add("Authorization", $"Bearer {""}");
                }
                return Task.CompletedTask;
            });

            var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(ChannelCredentials.Insecure, credentials),
                UnsafeUseInsecureChannelCallCredentials = true
            });
            return channel;
        }

    }
}