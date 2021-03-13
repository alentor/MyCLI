using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cliTest0
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await new HostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IGreeter, Greeter>();
                    services.AddSingleton(PhysicalConsole.Singleton);
                })
                .RunCommandLineApplicationAsync<MyCli>(args);
        }
    }
}