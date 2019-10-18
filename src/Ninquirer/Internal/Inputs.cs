using System;

namespace Ninquirer.Internal
{
    public class Input
    {
        private readonly IColoredConsole _console;

        public Input(IColoredConsole console) =>
            _console = console ?? throw new ArgumentNullException(nameof(console));

        public string Ask(string question)
        {
            _console.Write(
                ("\r? ", ConsoleColor.DarkGreen),
                ($"{question} ", default)
            );

            return _console.ReadLine();
        }
    }
}