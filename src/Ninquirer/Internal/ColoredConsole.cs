using System;

namespace Ninquirer.Internal
{

    public class ColoredConsole : IColoredConsole
    {
        public int CursorTop => Console.CursorTop;

        public int WindowWidth => Console.WindowWidth;

        public void Write(params (string message, ConsoleColor? color)[] messages)
        {
            foreach ((string message, ConsoleColor? color) in messages)
            {
                Write(message, color);
            }
        }

        public void Write(string message, ConsoleColor? color = null)
        {
            var temp = Console.ForegroundColor;
            var newColor = color ?? temp;

            Console.ForegroundColor = newColor;
            Console.Write(message);
            Console.ForegroundColor = temp;
        }

        public void WriteLine(params (string message, ConsoleColor? color)[] messages)
        {
            Write(messages);
            Write(Environment.NewLine, default);
        }

        public void WriteLine(string message, ConsoleColor? color = null)
            => Write(message + Environment.NewLine, color);

        public void Backspace(int length)
        {
            var backspace = new string('\b', length);
            var whitespace = new string(' ', length);
            Console.Write(backspace + whitespace + backspace);
        }

        public ConsoleKeyInfo ReadKey() => Console.ReadKey(true);

        public string ReadLine() => Console.ReadLine();

        public void SetCursorPosition(int left, int top)
            => Console.SetCursorPosition(left, top);
    }
}