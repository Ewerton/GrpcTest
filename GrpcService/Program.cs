using GrpcService.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc(opt =>
            {
                opt.EnableDetailedErrors = true;
            });

            // Added to make GRPC Call to work!!! https://stackoverflow.com/a/74495702/256925
            builder.WebHost.ConfigureKestrel(options =>
            {
                // Setup a HTTP/2 endpoint without TLS.
                options.ListenAnyIP(8000, o => o.Protocols = HttpProtocols.Http2);
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}