#nullable enable
using System;

namespace Ninquirer.Internal
{
    public class Confirm
    {
        private readonly IColoredConsole _console;

        public Confirm(IColoredConsole console)
            => _console = console ?? throw new ArgumentNullException(nameof(console));

        public bool Ask(string message)
        {
            bool isValid(ConsoleKeyInfo consoleKeyInfo) => consoleKeyInfo switch
            {
                { KeyChar: 'Y' } => true,
                { KeyChar: 'n' } => true,
                _ => false,
            };

            ConsoleKeyInfo input;
            _console.Write(("\r? ", ConsoleColor.DarkGreen), (message, default), (" (Y/n)  ", ConsoleColor.DarkGray));
            do
            {
                input = _console.ReadKey();
                if (char.IsLetterOrDigit(input.KeyChar))
                {
                    _console.Write(($"\b{input.KeyChar}", ConsoleColor.Red));
                }
            }
            while (!isValid(input));
            _console.Backspace(8);
            _console.Write(
                input switch
                {
                    { KeyChar: 'Y' } => (" Yes", ConsoleColor.DarkGreen),
                    _ => (" No", ConsoleColor.DarkRed)
                },
                (Environment.NewLine, default)
            );

            return input.KeyChar == 'Y';
        }
    }
}
