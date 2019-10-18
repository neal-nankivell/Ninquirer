using System;
using System.Linq;
using Ninquirer.Internal;

namespace Ninquirer.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ColoredConsole console = new ColoredConsole();

            var name = Prompt.Input("What is your name?");
            console.WriteLine(($"Hi {name}", ConsoleColor.DarkGreen));

            console.WriteLine(
                "Welcome to the ninquire Demo!",
                ConsoleColor.DarkMagenta
            );
            console.WriteLine(
                "Our goal is to make asking those tough questions easier. 🙋",
                ConsoleColor.Cyan
            );

            Prompt.PressAnyKeyToContinue(true);

            console.WriteLine(
                "\n// e.g. A Yes/No decision can be requested with the following snipit.",
                ConsoleColor.DarkGray);
            console.WriteLine(
                ("bool ", ConsoleColor.DarkBlue),
                ("result = ", default),
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("Confirm", ConsoleColor.DarkRed),
                ("(", ConsoleColor.DarkGray),
                (
                    "\"Would you like to see the default colors in your Terminal?\"",
                    ConsoleColor.DarkGreen
                ),
                (");\n", ConsoleColor.DarkGray)
            );

            Prompt.PressAnyKeyToContinue(true);

            console.WriteLine(
                "// Try pressing keys to see how the prompt gives feedback",
                ConsoleColor.DarkGray
            );
            console.WriteLine(
                "// note: confirmation requires an uppercase Y\n",
                ConsoleColor.DarkGray
            );

            if (Prompt.Confirm(
                "Would you like to see the colors configured in your Terminal?"))
            {
                console.WriteLine(
                    Enum.GetValues(typeof(ConsoleColor))
                        .Cast<ConsoleColor?>()
                        .Select(color => ($"•{color}• ", color))
                        .ToArray());
            }
            else
            {
                console.WriteLine("🦄 🌈 Here are some emojis instead!");
            }

            console.WriteLine(
                "\n// After an option has been selected, the chosen result is shown on the same line as the question",
                ConsoleColor.DarkGray
            );
            console.WriteLine(
                ("// ", ConsoleColor.DarkGray),
                ("Yes ", ConsoleColor.DarkGreen),
                ("or ", ConsoleColor.DarkGray),
                ("No", ConsoleColor.Red));

            Prompt.PressAnyKeyToContinue(true);

            console.WriteLine(
                "\n// Another common user input we often want is even simplier, this snippit allows us to wait for any input",
                ConsoleColor.DarkGray
            );
            console.WriteLine(
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("PressAnyKeyToContinue", ConsoleColor.DarkRed),
                ("();\n", ConsoleColor.DarkGray)
            );

            Prompt.PressAnyKeyToContinue();

            console.WriteLine(
                "// Hang on that one remained in terminal window, but earlier they were going away?\n",
                ConsoleColor.DarkGray
            );

            Prompt.PressAnyKeyToContinue();

            console.WriteLine(
                "\n// The default behaviour is to keep the result in the console, but this can be changed with a parameter",
                ConsoleColor.DarkGray
            );
            console.WriteLine(
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("PressAnyKeyToContinue", ConsoleColor.DarkRed),
                ("(hideResult: ", ConsoleColor.DarkGray),
                ("false", ConsoleColor.DarkYellow),
                (");\n", ConsoleColor.DarkGray)
            );

            Prompt.PressAnyKeyToContinue(true);
            console.WriteLine("// 👻 🎃 😱");

            console.WriteLine(
                "\n\n// Selection of a single item from a list can be made using:",
                ConsoleColor.DarkGray
            );

            console.WriteLine(
                ("string ", ConsoleColor.DarkBlue),
                ("color = ", default),
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("Select", ConsoleColor.DarkRed),
                ("(\n", ConsoleColor.DarkGray),
                (
                    "\t\"What is your favourite colour?\"",
                    ConsoleColor.DarkGreen
                ),
                (",\n", ConsoleColor.DarkGray),
                ("\t\"Red\"", ConsoleColor.DarkGreen),
                (",\n", ConsoleColor.DarkGray),
                ("\t\"Green\"", ConsoleColor.DarkGreen),
                (",\n", ConsoleColor.DarkGray),
                ("\t\"Blue\"", ConsoleColor.DarkGreen),
                (");\n", ConsoleColor.DarkGray)
            );

            console.WriteLine(
                "\n// Or passing an array",
                ConsoleColor.DarkGray
            );
            console.WriteLine(
                ("string ", ConsoleColor.DarkBlue),
                ("color = ", default),
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("Select", ConsoleColor.DarkRed),
                ("(\n", ConsoleColor.DarkGray),
                (
                    "\t\"What is your favourite colour?\"",
                    ConsoleColor.DarkGreen
                ),
                (",\n", ConsoleColor.DarkGray),
                ("\tEnum.", ConsoleColor.DarkMagenta),
                ("GetValues", ConsoleColor.DarkRed),
                ("(", ConsoleColor.DarkGray),
                ("typeof", ConsoleColor.DarkBlue),
                ("(", ConsoleColor.DarkGray),
                ("ConsoleColor", ConsoleColor.DarkMagenta),
                ("))\n", ConsoleColor.DarkGray),

                ("\t\t.Cast", ConsoleColor.DarkRed),
                ("<", ConsoleColor.DarkGray),
                ("ConsoleColor", ConsoleColor.DarkMagenta),
                (">()\n", ConsoleColor.DarkGray),

                ("\t\t.Select", ConsoleColor.DarkRed),
                ("(x => x.", ConsoleColor.DarkGray),
                ("ToString", ConsoleColor.DarkRed),
                ("()))\n", ConsoleColor.DarkGray),

                ("\t\t.ToArray", ConsoleColor.DarkRed),
                ("()\n", ConsoleColor.DarkGray),

                ("\t);\n", ConsoleColor.DarkGray)
            );

            Prompt.PressAnyKeyToContinue(true);

            var color = Prompt.Select(
                "What is your favourite colour?",
                Enum.GetValues(typeof(ConsoleColor))
                    .Cast<ConsoleColor>()
                    .Select(x => x.ToString())
                    .ToArray()
                );

            console.WriteLine($"// You selected {color}!", ConsoleColor.DarkGray);

            Prompt.PressAnyKeyToContinue(true);

            console.WriteLine(
                "\n\n// Selection of multiple items from a list can be made using:",
                ConsoleColor.DarkGray
            );

            console.WriteLine(
                ("string[] ", ConsoleColor.DarkBlue),
                ("colors = ", default),
                ("Prompt.", ConsoleColor.DarkMagenta),
                ("SelectMulitple", ConsoleColor.DarkRed),
                ("(\n", ConsoleColor.DarkGray),
                (
                    "\t\"What are your favourite colours?\"",
                    ConsoleColor.DarkGreen
                ),
                (",\n", ConsoleColor.DarkGray),
                ("\tEnum.", ConsoleColor.DarkMagenta),
                ("GetValues", ConsoleColor.DarkRed),
                ("(", ConsoleColor.DarkGray),
                ("typeof", ConsoleColor.DarkBlue),
                ("(", ConsoleColor.DarkGray),
                ("ConsoleColor", ConsoleColor.DarkMagenta),
                ("))\n", ConsoleColor.DarkGray),

                ("\t\t.Cast", ConsoleColor.DarkRed),
                ("<", ConsoleColor.DarkGray),
                ("ConsoleColor", ConsoleColor.DarkMagenta),
                (">()\n", ConsoleColor.DarkGray),

                ("\t\t.Select", ConsoleColor.DarkRed),
                ("(x => x.", ConsoleColor.DarkGray),
                ("ToString", ConsoleColor.DarkRed),
                ("()))\n", ConsoleColor.DarkGray),

                ("\t\t.ToArray", ConsoleColor.DarkRed),
                ("()\n", ConsoleColor.DarkGray),

                ("\t);\n", ConsoleColor.DarkGray)
            );

            Prompt.PressAnyKeyToContinue(true);

            var colors = Prompt.SelectMulitple(
                "What are your favourite colours?",
                Enum.GetValues(typeof(ConsoleColor))
                    .Cast<ConsoleColor>()
                    .Select(x => x.ToString())
                    .ToArray()
                );
        }
    }
}
