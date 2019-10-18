using System;
using System.Linq;
using Moq;
using Ninquirer.Internal;

namespace Ninquirer.Tests.Builders
{
    public class ConsoleMockBuilder
    {
        private char[] _inputSequence;

        private string[] _readLineSequence;

        public ConsoleMockBuilder WithReadKeySequence(params char[] inputSequence)
        {
            _inputSequence = inputSequence;
            return this;
        }

        public ConsoleMockBuilder WithReadKeySequence(params ConsoleKey[] inputSequence)
            => WithReadKeySequence(inputSequence.Select(x => (char)x).ToArray());

        public ConsoleMockBuilder WithReadLineSequence(params string[] sequence)
        {
            _readLineSequence = sequence;
            return this;
        }

        public Mock<IColoredConsole> Build()
        {
            Mock<IColoredConsole> mock = new Mock<IColoredConsole>();

            var readKey = GenerateReadKeySequence(_inputSequence);
            var readLine = GenerateReadLineSequence(_readLineSequence);
            mock.Setup(m => m.ReadKey()).Returns(() => readKey());
            mock.Setup(m => m.ReadLine()).Returns(() => readLine());

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

        private Func<string> GenerateReadLineSequence(string[] inputSequence)
        {
            int index = 0;
            return () =>
            {
                if (inputSequence == null || inputSequence.Length <= index)
                {
                    throw new InvalidOperationException(
                        $"Console Mock not configured for .ReadLine() {index + 1} times"
                    );
                }

                var line = inputSequence[index];
                index++;
                return line;
            };
        }
    }
}