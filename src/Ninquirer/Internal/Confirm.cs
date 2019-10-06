#nullable enable
using System;

namespace Ninquirer.Internal
{
    public class Confirm
    {
        private readonly Func<ConsoleKeyInfo> _readKey;
        private readonly ColoredWrite _write;

        public Confirm() : this(() => Console.ReadKey(true), ColoredConsole.Write) { }

        public Confirm(Func<ConsoleKeyInfo> readKey, ColoredWrite write)
            => (_readKey, _write) = (readKey, write);

        public bool Ask(string message)
        {
            bool isValid(ConsoleKeyInfo consoleKeyInfo) => consoleKeyInfo switch
            {
                { KeyChar: 'Y' } => true,
                { KeyChar: 'n' } => true,
                _ => false,
            };

            ConsoleKeyInfo input;
            _write(("\r? ", ConsoleColor.DarkGreen), (message, default), (" (Y/n)  ", ConsoleColor.DarkGray));
            do
            {
                input = _readKey();
                if (char.IsLetterOrDigit(input.KeyChar))
                {
                    _write(($"\b{input.KeyChar}", ConsoleColor.Red));
                }
            }
            while (!isValid(input));
            ColoredConsole.Backspace(8);
            _write(
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
