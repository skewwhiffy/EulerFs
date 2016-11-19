using EulerFs.Solutions;
using NUnit.Framework;

namespace EulerFs.CsTests
{
    public class Solutions021_030Tests
    {
        private Solutions021_030 _solutions;

        [SetUp]
        public void BeforeEach()
        {
            _solutions = new Solutions021_030();
        }

        [Test]
        public void Solution21Works()
        {
            var solution = _solutions.Solution021;

            Assert.That(solution, Is.EqualTo(31626));
        }

        [Test]
        public void Solution22Works()
        {
            var solution = _solutions.Solution022;

            Assert.That(solution, Is.EqualTo(871198282));
        }

        [Test, Explicit]
        public void Solution23Works()
        {
            var solution = new Solution023Sandbox().Solution023;
            
            Assert.That(solution, Is.EqualTo(4179871));
        }
    }
}
