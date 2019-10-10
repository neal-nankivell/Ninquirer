
using System;
using System.Linq;

namespace Ninquirer.Internal
{
    public class Select
    {
        private readonly IColoredConsole _console;

        private static ConsoleKey[] nextKeys = new[] { ConsoleKey.Tab, ConsoleKey.DownArrow, ConsoleKey.J };
        private static ConsoleKey[] previousKeys = new[] { ConsoleKey.UpArrow, ConsoleKey.K };

        public Select(IColoredConsole console)
            => _console = console ?? throw new ArgumentNullException(nameof(console));

        public string Ask(string question, params string[] options)
        {
            if (options == null) { throw new ArgumentNullException(nameof(options)); }
            if (options.Length == 0) { throw new ArgumentOutOfRangeException(nameof(options)); }

            bool isEnterKey(ConsoleKeyInfo? info) => info?.Key == ConsoleKey.Enter;
            ConsoleKeyInfo input;
            int index = 0;

            do
            {
                _console.Write(
                    ("\r? ", ConsoleColor.Green),
                    (question, default)
                );
                _console.Write(
                    options.Select((option, i) => ($"\n •{option} ", i == index ? ConsoleColor.DarkGreen : (ConsoleColor?)default))
                    .ToArray()
                );
                input = _console.ReadKey();

                index = input switch
                {
                    { Key: var key } when nextKeys.Contains(key) => (index + 1) % options.Length,
                    { Key: var key } when previousKeys.Contains(key) => (index - 1 + options.Length) % options.Length,
                    _ => index
                };

                _console.SetCursorPosition(0, _console.CursorTop - options.Length);

            } while (!isEnterKey(input));

            _console.Write(
                ("\r? ", ConsoleColor.Green),
                (question, default),
                ($" {options[index]}", ConsoleColor.Green)
            );

            // Hack to "clear" the list of options shown
            // This overwrites all the lines with whitespace.
            // This is a hack because the lines are not truly cleared to empty.
            _console.Write(
                options.Select((option, i) => ($"\n{new string(' ', _console.WindowWidth)}", (ConsoleColor?)default))
                .ToArray()
            );

            _console.SetCursorPosition(0, _console.CursorTop - options.Length + 1);

            return options[index];
        }
    }
}