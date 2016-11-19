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

        [Test]
        public void Solution005Test()
        {
            var solution = _solutions.Solution005;

            Assert.That(solution, Is.EqualTo(232792560));
        }

        [Test]
        public void Solution006Test()
        {
            var solution = _solutions.Solution006;

            Assert.That(solution, Is.EqualTo(25164150));
        }

        [Test]
        public void Solution007Test()
        {
            var solution = _solutions.Solution007;

            Assert.That(solution, Is.EqualTo(104743));
        }

        [Test]
        public void Solution008Test()
        {
            var solution = _solutions.Solution008;

            Assert.That(solution, Is.EqualTo(23514624000L));
        }

        [Test, Explicit]
        public void Solution009Test()
        {
            var solution = _solutions.Solution009;

            Assert.That(solution, Is.EqualTo(31875000));
        }

        [Test]
        public void Solution010Test()
        {
            var solution = _solutions.Solution010;

            Assert.That(solution, Is.EqualTo(142913828922));
        }
    }
}
