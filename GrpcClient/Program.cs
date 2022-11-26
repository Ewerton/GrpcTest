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
            Delay();
            CallGrpcService();
        }

        public static void Delay()
        {
            System.Threading.Thread.Sleep(3000);
        }

        public static void CallGrpcService()
        {
            string address = System.Environment.GetEnvironmentVariable("GrpcServiceUrl");

            var channel = GrpcChannel.ForAddress(address);
            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.In.ReadLine();
            //Console.ReadKey();
        }
    }
}