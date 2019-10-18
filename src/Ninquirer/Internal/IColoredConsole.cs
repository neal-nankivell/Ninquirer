using System;

namespace Ninquirer.Internal
{
    public interface IColoredConsole
    {
        void Write(params (string message, ConsoleColor? color)[] messages);

        void Write(string message, ConsoleColor? color = null);

        void WriteLine(params (string message, ConsoleColor? color)[] messages);

        public void WriteLine(string message, ConsoleColor? color = null);

        void Backspace(int length);

        ConsoleKeyInfo ReadKey();

        string ReadLine();

        void SetCursorPosition(int left, int top);

        int CursorTop { get; }

        int WindowWidth { get; }
    }
}