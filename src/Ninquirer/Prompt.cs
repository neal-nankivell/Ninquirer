﻿#nullable enable
using Ninquirer.Internal;

namespace Ninquirer
{
    public static class Prompt
    {
        private static IColoredConsole _console = new ColoredConsole();
        private static Confirm _confirm = new Confirm(_console);
        private static PressAnyKeyToContinue _pressAnyKeyToContiner = new PressAnyKeyToContinue(_console);
        public static bool Confirm(string message) => _confirm.Ask(message);
        public static void PressAnyKeyToContinue(bool hideResult = false) => _pressAnyKeyToContiner.Ask(hideResult);
    }
}
