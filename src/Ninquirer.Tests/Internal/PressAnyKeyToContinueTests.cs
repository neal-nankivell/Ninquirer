using AutoFixture.NUnit3;
using Ninquirer.Tests.Builders;
using NUnit.Framework;

namespace Ninquirer.Internal.Tests
{
    public class PressAnyKeyToContinueTests
    {
        [Test, AutoData]
        public void AllKeysContinue(char input)
        {
            var consoleMock = new ConsoleMockBuilder()
                .WithReadKeySequence(input)
                .Build();

            var sut = new PressAnyKeyToContinue(consoleMock.Object);

            sut.Ask();

            Assert.Pass($"Ask did not block when ReadKey returned {input}");
        }
    }
}