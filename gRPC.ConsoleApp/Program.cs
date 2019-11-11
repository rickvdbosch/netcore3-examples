using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPC.Service01;

namespace GrpcExamples.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool quit;
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            do
            {
                Console.Write("Please enter your name: ");
                var name = Console.ReadLine();
                quit = name.Equals("q", StringComparison.OrdinalIgnoreCase);
                if (!quit)
                {
                    var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
                    Console.WriteLine("Greeting: " + reply.Message);
                }
            } while (!quit);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}