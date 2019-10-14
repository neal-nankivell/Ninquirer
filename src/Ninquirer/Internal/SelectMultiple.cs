using System;
using System.Collections.Generic;
using System.Linq;

namespace Ninquirer.Internal
{
    public class SelectMulitple
    {
        private readonly IColoredConsole _console;

        private static ConsoleKey[] nextKeys = new[] {
            ConsoleKey.Tab,
            ConsoleKey.DownArrow,
            ConsoleKey.J
        };

        private static ConsoleKey[] previousKeys = new[] {
            ConsoleKey.UpArrow,
            ConsoleKey.K
        };
        public SelectMulitple(IColoredConsole console)
            => _console = console ?? throw new ArgumentNullException(nameof(console));

        public string[] Ask(string question, string[] options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (options.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            bool isEnterKey(ConsoleKeyInfo? info) => info?.Key == ConsoleKey.Enter;
            bool isSpaceKey(ConsoleKeyInfo? info) => info?.Key == ConsoleKey.Spacebar;

            ConsoleKeyInfo input;
            HashSet<int> selection = new HashSet<int>();
            int index = 0;

            do
            {
                _console.Write(
                    ("\r? ", ConsoleColor.DarkGreen),
                    (question, default)
                );

                (string message, ConsoleColor? color) Format(string option, int i)
                {
                    bool selected = selection.Contains(i);
                    bool highlighted = i == index;

                    string bullet = selected ? "⦿" : "○";
                    string prefix = highlighted ? "▶" : " ";
                    ConsoleColor? color = (selected, highlighted) switch
                    {
                        { highlighted: true } => ConsoleColor.DarkGreen,
                        { selected: true } => ConsoleColor.DarkBlue,
                        _ => (ConsoleColor?)default
                    };

                    return ($"\n {prefix} {bullet} {option}", color);
                }

                _console.Write(options.Select(Format).ToArray());

                input = _console.ReadKey();

                index = input switch
                {
                    { Key: var key } when nextKeys.Contains(key) => (index + 1) % options.Length,
                    { Key: var key } when previousKeys.Contains(key) => (index - 1 + options.Length) % options.Length,
                    _ => index
                };

                if (isSpaceKey(input))
                {
                    if (selection.Contains(index))
                    {
                        selection.Remove(index);
                    }
                    else
                    {
                        selection.Add(index);
                    }
                }

                _console.SetCursorPosition(0, _console.CursorTop - options.Length);


            } while (!isEnterKey(input));

            var result = selection.Select(i => options[i]).ToArray();
            _console.Write(
                ("\r? ", ConsoleColor.DarkGreen),
                (question, default),
                ($" {string.Join(", ", result)}", ConsoleColor.DarkGreen)
            );

            // Hack to "clear" the list of options shown
            // This overwrites all the lines with whitespace.
            // This is a hack because the lines are not truly cleared to empty.
            _console.Write(
                options.Select((option, i) => ($"\n{new string(' ', _console.WindowWidth)}", (ConsoleColor?)default))
                .ToArray()
            );

            _console.SetCursorPosition(0, _console.CursorTop - options.Length + 1);

            return result;
        }
    }
}