using System;
using System.Linq;
using Ninquirer.Internal;

namespace Ninquirer.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ColoredConsole.WriteLine("Welcome to the ninquire Demo!", ConsoleColor.DarkMagenta);
            ColoredConsole.WriteLine("Our goal is to make asking those tough questions easier. 🙋", ConsoleColor.Cyan);

            ColoredConsole.WriteLine("\n// e.g. A Yes/No decision can be requested with the following snipit.", ConsoleColor.DarkGray);
            ColoredConsole.WriteLine(
                ("bool ", ConsoleColor.DarkBlue),
                ("result = ", default),
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("Confirm", ConsoleColor.DarkRed),
                ("(", ConsoleColor.DarkGray),
                ("\"Would you like to see the default colors in your Terminal?\"", ConsoleColor.DarkGreen),
                (");\n", ConsoleColor.DarkGray)
            );

            ColoredConsole.WriteLine("// Try pressing keys to see how the prompt gives feedback", ConsoleColor.DarkGray);
            ColoredConsole.WriteLine("// note: confirmation requires an uppercase Y\n", ConsoleColor.DarkGray);

            if (Prompt.Confirm("Would you like to see the default colors in your Terminal?"))
            {
                ColoredConsole.WriteLine(
                    Enum.GetValues(typeof(ConsoleColor))
                        .Cast<ConsoleColor?>()
                        .Select(color => ($"•{color}• ", color))
                        .ToArray());
            };

            ColoredConsole.WriteLine("\n// After an option has been selected, the result is shown on the same line as the question\n", ConsoleColor.DarkGray);
        }
    }
}
