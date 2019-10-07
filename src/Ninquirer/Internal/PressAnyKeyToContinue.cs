using System;

namespace Ninquirer.Internal
{
    public class PressAnyKeyToContinue
    {
        private readonly IColoredConsole _console;

        public PressAnyKeyToContinue(IColoredConsole console)
            => _console = console ?? throw new ArgumentNullException(nameof(console));

        public void Ask(bool hideResult = false)
        {
            const string message = "Press any key to continue: ";
            _console.Write(message, default);
            _console.ReadKey();
            if (hideResult)
            {
                _console.Backspace(message.Length);
            }
            else
            {
                _console.WriteLine("✔ 🎉", ConsoleColor.DarkGreen);
            }
        }
    }
}