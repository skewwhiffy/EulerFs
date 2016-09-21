﻿using EulerFs.Solutions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Test]
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
    }
}
