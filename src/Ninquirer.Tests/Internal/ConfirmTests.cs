using System;
using System.Linq;
using NUnit.Framework;

namespace Ninquirer.Internal.Tests
{
    public class Tests
    {
        [TestCase('q', 'w', 'Y', ExpectedResult = true)]
        [TestCase('Y', ExpectedResult = true)]
        [TestCase('q', 'w', 'n', ExpectedResult = false)]
        [TestCase('n', ExpectedResult = false)]
        public bool Confirm(params char[] inputSequence)
        {
            if (!inputSequence.Any(input => input == 'Y' || input == 'n'))
            {
                Assert.Fail(@"Invalid input sequence for this test,
there needs to be a Y or n. Otherwise the the test will hang");
            }

            var sut = new Confirm(GenerateReadKeySequence(inputSequence), Console.Write);
            return sut.Ask("Test Question??");
        }

        public Func<ConsoleKeyInfo> GenerateReadKeySequence(params char[] characters)
        {
            int index = 0;
            return () =>
            {
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