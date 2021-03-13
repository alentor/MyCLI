using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace cliTest0
{
    [Command(Name = nameof(MyCli), Description = "CLI using C# example project")]
    public class MyCli
    {
        [Argument(0, Description = "your name")]
        private string Name { get; } = "dependency injection";

        // [Option("-l|--language", Description = "your desired language")]
        [Option()]
        [AllowedValues("english", "spanish", IgnoreCase = true)]
        public string Language { get; } = "english";

        private readonly ILogger<Program> _logger;
        private readonly IGreeter _greeter;

        public MyCli(ILogger<Program> logger, IGreeter greeter)
        {
            _logger = logger;
            _greeter = greeter;

            _logger.LogInformation("Constructed!");
            _greeter.Greet(Name, Language);
        }

        private void OnExecute()
        {
            _greeter.Greet(Name, Language);
        }
    }
}