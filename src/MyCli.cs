using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace cliTest0
{
    [Command(Name = nameof(MyCli), Description = "CLI using C# example project")]
    public class MyCli
    {
        [Required]
        [Argument(0, Description = "your name")]
        private string Name { get; }

        [Option()]
        [AllowedValues("english", "spanish", IgnoreCase = true)]
        public string Language { get; } = "english";

        private readonly CommandLineApplication _commandLineApplication;
        private readonly IConsole _console;
        private readonly ILogger<Program> _logger;
        private readonly IGreeter _greeter;

        public MyCli(ILogger<Program> logger, IGreeter greeter, CommandLineApplication commandLineApplication, IConsole console)
        {
            _logger = logger;
            _greeter = greeter;
            _commandLineApplication = commandLineApplication;
            _console = console;
            _logger.LogInformation("Constructed!");
        }

        //  Defines a callback for when this command is invoked.
        private void OnExecute()
        {
            _greeter.Greet(Name, Language);
        }
    }
}