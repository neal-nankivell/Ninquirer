using System;
using System.Linq;
using Ninquirer.Tests.Builders;
using NUnit.Framework;

namespace Ninquirer.Internal.Tests
{
    public class SelectMultipleTests
    {
        [TestCase(
            new[] {
                ConsoleKey.DownArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.Spacebar,
                ConsoleKey.Enter
            },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = new[] { "c" })]
        [TestCase(
            new[] {
                ConsoleKey.DownArrow,
                ConsoleKey.UpArrow,
                ConsoleKey.Spacebar,
                ConsoleKey.Enter
            },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = new[] { "a" })]
        [TestCase(
            new[] {
                ConsoleKey.Spacebar,
                ConsoleKey.Enter
            },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = new[] { "a" })]
        [TestCase(
            new[] {
                ConsoleKey.UpArrow,
                ConsoleKey.Spacebar,
                ConsoleKey.Enter
            },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = new[] { "f" })]
        [TestCase(
            new[] {
                ConsoleKey.UpArrow,
                ConsoleKey.Enter
            },
            new[] { "a", "b", "c", "d", "e", "f" },
            ExpectedResult = new string[0])]
        public string[] SelectMultiple(
            ConsoleKey[] inputSequence,
            string[] options)
        {
            if (!inputSequence.Contains(ConsoleKey.Enter))
            {
                Assert.Fail(@"Invalid input sequence for this test,
there needs to be a Enter. Otherwise the the test will hang");
            }

            var consoleMock = new ConsoleMockBuilder()
                .WithReadKeySequence(inputSequence)
                .Build();

            SelectMulitple sut = new SelectMulitple(consoleMock.Object);

            return sut.Ask("Test Question??", options);
        }
    }
}