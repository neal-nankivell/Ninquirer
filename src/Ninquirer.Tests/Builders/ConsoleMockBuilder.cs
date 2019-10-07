using System;
using Moq;
using Ninquirer.Internal;

namespace Ninquirer.Tests.Builders
{
    public class ConsoleMockBuilder
    {
        private char[] _inputSequence;

        public ConsoleMockBuilder WithReadKeySequence(params char[] inputSequence)
        {
            _inputSequence = inputSequence;
            return this;
        }

        public Mock<IColoredConsole> Build()
        {
            Mock<IColoredConsole> mock = new Mock<IColoredConsole>();

            var readKey = GenerateReadKeySequence(_inputSequence);
            mock.Setup(m => m.ReadKey()).Returns(() => readKey());

            return mock;
        }

        private Func<ConsoleKeyInfo> GenerateReadKeySequence(params char[] characters)
        {
            int index = 0;
            return () =>
            {
                if (characters == null || characters.Length <= index)
                {
                    throw new InvalidOperationException($"Console Mock not configured for .ReadKey() {index + 1} times");
                }
                var character = characters[index];
                index++;
                return new ConsoleKeyInfo(
                    character,
                    (ConsoleKey)character,
                    false,
                    false,
                    false
                );
            };
        }
    }
}