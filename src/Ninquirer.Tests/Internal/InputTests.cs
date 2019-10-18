using AutoFixture.NUnit3;
using NUnit.Framework;
using Ninquirer.Tests.Builders;

namespace Ninquirer.Internal.Tests
{
    public class InputTests
    {
        [Test, AutoData]
        public void InputReturnsValue(string input)
        {
            var consoleMock = new ConsoleMockBuilder()
                .WithReadLineSequence(input)
                .Build();

            var sut = new Input(consoleMock.Object);

            var result = sut.Ask("Question?");

            Assert.That(result, Is.EqualTo(input));
        }
    }
}