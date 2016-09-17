using NUnit.Framework;
using EulerFs.Solutions;
using System.Linq;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class Solutions001_010Tests
    {
        private Solutions001_010 _solutions;

        [SetUp]
        public void BeforeEach()
        {
            _solutions = new Solutions001_010();
        }

        [Test]
        public void Solution001Test()
        {
            var solution = _solutions.Solution001;

            Assert.That(solution, Is.EqualTo(233168));
        }

        [Test]
        public void Solution002Test()
        {
            var solution = _solutions.Solution002;

            Assert.That(solution, Is.EqualTo(4613732));
        }
    }
}
