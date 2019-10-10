using System;
using System.Linq;
using Ninquirer.Tests.Builders;
using NUnit.Framework;

namespace Ninquirer.Internal.Tests
{
    public class SelectTests
    {
        [TestCase(
            new[] { ConsoleKey.DownArrow, ConsoleKey.DownArrow, ConsoleKey.Enter },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = "c")]
        [TestCase(
            new[] { ConsoleKey.DownArrow, ConsoleKey.UpArrow, ConsoleKey.Enter },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = "a")]
        [TestCase(
            new[] { ConsoleKey.Enter },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = "a")]
        [TestCase(
            new[] { ConsoleKey.UpArrow, ConsoleKey.Enter },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = "f")]
        public string Select(ConsoleKey[] inputSequence, string[] options)
        {
            if (!inputSequence.Contains(ConsoleKey.Enter))
            {
                Assert.Fail(@"Invalid input sequence for this test,
there needs to be a Enter. Otherwise the the test will hang");
            }

            var consoleMock = new ConsoleMockBuilder()
                .WithReadKeySequence(inputSequence)
                .Build();

            Select sut = new Select(consoleMock.Object);

            return sut.Ask("Test Question??", options);
        }
    }
}