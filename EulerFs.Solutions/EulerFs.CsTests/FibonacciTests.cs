using NUnit.Framework;
using EulerFs.Common;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class FibonacciTests
    {
        private Fibonacci _fibonacci;

        [SetUp]
        public void BeforeEach()
        {
            _fibonacci = new Fibonacci();
        }

        [Test]
        public void FirstHundredTermsCorrect()
        {
            Assert.That(_fibonacci[0], Is.EqualTo(0));
            Assert.That(_fibonacci[1], Is.EqualTo(1));
            for (var i = 2; i < 100; i++)
            {
                Assert.That(_fibonacci[i], Is.EqualTo(_fibonacci[i - 1] + _fibonacci[i - 2]));
            }
        }
    }
}
