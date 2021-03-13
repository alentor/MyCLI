using System;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace cliTest0
{
    public interface IGreeter
    {
        void Greet(string name, string language);
    }

    class Greeter : IGreeter
    {
        private readonly IConsole _console;
        private readonly ILogger<Greeter> _logger;

        public Greeter(ILogger<Greeter> logger, IConsole console)
        {
            _logger = logger;
            _console = console;

            _logger.LogInformation("Constructed!");
        }

        public void Greet(string name, string language)
        {
            string greeting = language switch
            {
                "english" => $"Hello {name}",
                "spanish" => $"Hola {name}",
                _ => throw new InvalidOperationException("validation should have caught this"),
            };
            _console.WriteLine(greeting, name);
        }
    }
}