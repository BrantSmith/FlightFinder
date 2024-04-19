using FlightFinder.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FlightFinder.UnitTest
{
    public class FlightFinderTests
    {
        private readonly FlightFinderController _controller;
        private readonly ILogger<FlightFinderController> _mockLogger;

        public FlightFinderTests()
        {
            var mock = new Mock<ILogger<FlightFinderController>>();
            _mockLogger = mock.Object;

            _controller = new FlightFinderController(_mockLogger);
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("flight", 1)]
        [TestCase("lightf", 1)]
        [TestCase("flightflight", 2)]
        [TestCase("fflliigghhtt", 2)]
        [TestCase("lightfabc", 1)]
        [TestCase("flight@!thgilf&^abcd)fliab(cght", 3)]
        [TestCase("abc", 0)]
        [TestCase("abcdefghijklm", 0)]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla at sapien feugiat, aliquet nisi ut, egestas enimh", 1)]
        [TestCase("The quick brown fox jumps over the lazy dog", 1)]
        [TestCase("", 0)]
        public void CountOccurrences(string input, int expected)
        {
            var actual = _controller.Get(input);
            Assert.That(expected, Is.EqualTo(actual), $"String '{input}' does not have the expected count - Expected: {expected}, Actual: {actual}");
        }
    }
}