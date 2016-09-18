using NUnit.Framework;
using EulerFs.Solutions;
using System.Linq;
using System;

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

        [Test]
        public void Solution003Test()
        {
            var solution = _solutions.Solution003;

            Assert.That(solution, Is.EqualTo(6857));
        }

        [Test]
        public void Solution004Test()
        {
            var solution = _solutions.Solution004;

            Assert.That(solution, Is.EqualTo(906609));
        }
    }
}
