using System;
using System.Threading;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cliTest0
{
    public class ConsoleHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IConfiguration _configuration;
        private readonly ConsoleArgs _consoleArgs;

        public ConsoleHostedService(ILogger<ConsoleHostedService> logger, IHostApplicationLifetime appLifetime, IConfiguration configuration, ConsoleArgs consoleArgs)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _configuration = configuration;
            _consoleArgs = consoleArgs;
            var app = new CommandLineApplication();
            app.HelpOption();
            app.Option<string>("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        _logger.LogInformation("Hello World, bellow is the logLevel for 'dafault'");
                        _logger.LogInformation(_configuration.GetSection("Logging").GetSection("LogLevel").GetValue<string>("Default"));
                        if (_consoleArgs.Args.Length > 0)
                            _logger.LogInformation(_consoleArgs.Args[0]);
                        // Simulate real work is being done
                        await Task.Delay(1000);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception!");
                    }
                    finally
                    {
                        // Stop the application once the work is done
                        _appLifetime.StopApplication();
                    }
                });
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}