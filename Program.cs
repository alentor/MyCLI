using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cliTest0
{
    public class Program
    {
        // static async Task Main(string[] args)
        // {
        //     await Host.CreateDefaultBuilder(args)
        //             .ConfigureServices((hostContext, services) =>
        //             {
        //                 // Add Console service.
        //                 services.AddHostedService<ConsoleHostedService>();
        //                 services.AddSingleton(new ConsoleArgs(args));
        //             })
        //             .RunConsoleAsync();
        // }


        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "The subject")]
        public string Subject { get; } = "world";

        [Option(ShortName = "n")]
        public int Count { get; } = 1;

        private void OnExecute()
        {
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine($"Hello {Subject}!");
            }
        }
    }
}