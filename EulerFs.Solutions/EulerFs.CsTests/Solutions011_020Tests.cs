﻿using EulerFs.Solutions;
using NUnit.Framework;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class Solutions011_020Tests
    {
        private Solutions011_020 _solutions;

        [SetUp]
        public void BeforeEach()
        {
            _solutions = new Solutions011_020();
        }

        [Test]
        public void Solution011Works()
        {
            var solution = _solutions.Solution011;

            Assert.That(solution, Is.EqualTo(70600674));
        }

        [Test, Explicit]
        public void Solution012Works()
        {
            var solution = _solutions.Solution012;

            Assert.That(solution, Is.EqualTo(76576500));
        }

        [Test]
        public void Solution013Works()
        {
            var solution = _solutions.Solution013;

            Assert.That(solution, Is.EqualTo("5537376230"));
        }

        [Test]
        public void Solution014Works()
        {
            var solution = _solutions.Solution014;

            Assert.That(solution, Is.EqualTo(837799));
        }

        [Test]
        public void Solution015Works()
        {
            var solution = _solutions.Solution015;

            Assert.That(solution, Is.EqualTo(137846528820));
        }

        [Test]
        public void Solution016Works()
        {
            var solution = _solutions.Solution016;

            Assert.That(solution, Is.EqualTo(1366));
        }

        [Test]
        public void Solution017Works()
        {
            var solution = _solutions.Solution017;

            Assert.That(solution, Is.EqualTo(21124));
        }

        [Test]
        public void Solution018Works()
        {
            var solution = _solutions.Solution018;

            Assert.That(solution, Is.EqualTo(1074));
        }

        [Test]
        public void Solution019Works()
        {
            var solution = _solutions.Solution019;

            Assert.That(solution, Is.EqualTo(171));
        }

        [Test]
        public void Solution020Works()
        {
            var solution = _solutions.Solution020;

            Assert.That(solution, Is.EqualTo(648));
        }
    }
}
