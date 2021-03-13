namespace cliTest0
{
    public class ConsoleArgs
    {
        public string[] Args { get; }

        public ConsoleArgs(string[] args)
        {
            if (args != null)
                Args = args;
        }
    }
}