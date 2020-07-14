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

        public int? AskInt(string question)
        {
            ConsoleKeyInfo input;
            var rawInput = "";
            var maxLen = 0;
            int? value = null;
            do
            {
                _console.Write(
                    ("\r? ", ConsoleColor.DarkGreen),
                    ($"{question} {rawInput}{new string(' ', maxLen - rawInput.Length)}", default)
                );
                input = _console.ReadKey();
                int tempValue;
                string tempInput = rawInput + input.KeyChar;
                if (int.TryParse(tempInput, out tempValue) || tempInput == "-")
                {
                    value = tempValue;
                    rawInput += input.KeyChar;
                    maxLen = Math.Max(maxLen, rawInput.Length);
                }
                else if (input.Key == ConsoleKey.Backspace && rawInput.Length > 0)
                {
                    rawInput = rawInput[..^1];
                }

            }
            while (input.Key != ConsoleKey.Enter);

            _console.WriteLine();

            return value;
        }
    }
}