using System;

namespace Ninquirer.Internal
{
    public delegate void ColoredWrite(params (string message, ConsoleColor? color)[] messages);

    public static class ColoredConsole
    {
        public static void Write(params (string message, ConsoleColor? color)[] messages)
        {
            foreach ((string message, ConsoleColor? color) in messages)
            {
                Write(message, color);
            }
        }

        public static void Write(string message, ConsoleColor? color = null)
        {
            var temp = Console.ForegroundColor;
            var newColor = color ?? temp;

            Console.ForegroundColor = newColor;
            Console.Write(message);
            Console.ForegroundColor = temp;
        }

        public static void WriteLine(params (string message, ConsoleColor? color)[] messages)
        {
            Write(messages);
            Write(Environment.NewLine, default);
        }

        public static void WriteLine(string message, ConsoleColor? color = null)
            => Write(message + Environment.NewLine, color);

        public static void Backspace(int length)
        {
            var backspace = new string('\b', length);
            var whitespace = new string(' ', length);
            Console.Write(backspace + whitespace + backspace);
        }
    }
}