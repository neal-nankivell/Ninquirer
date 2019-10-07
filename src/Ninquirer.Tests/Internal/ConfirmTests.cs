using System.Linq;
using Ninquirer.Tests.Builders;
using NUnit.Framework;

namespace Ninquirer.Internal.Tests
{
    public class Tests
    {
        [TestCase('q', 'w', 'Y', ExpectedResult = true)]
        [TestCase('Y', ExpectedResult = true)]
        [TestCase('y', 'y', 'n', ExpectedResult = false)]
        [TestCase('q', 'w', 'n', ExpectedResult = false)]
        [TestCase('n', ExpectedResult = false)]
        public bool Confirm(params char[] inputSequence)
        {
            if (!inputSequence.Any(input => input == 'Y' || input == 'n'))
            {
                Assert.Fail(@"Invalid input sequence for this test,
there needs to be a Y or n. Otherwise the the test will hang");
            }

            var consoleMock = new ConsoleMockBuilder()
                .WithReadKeySequence(inputSequence)
                .Build();

            var sut = new Confirm(consoleMock.Object);

            return sut.Ask("Test Question??");
        }
    }
}