﻿using EulerFs.Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class PrimeTests
    {
        private Prime _prime;

        [SetUp]
        public void BeforeEach()
        {
            _prime = new Prime();
        }

        [Test]
        public void FirstTenPrimesCorrect()
        {
            var expected = new List<int>
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29
            };

            Assert.That(Enumerable.Range(0, 10).Select(i => _prime[i]), Is.EqualTo(expected));
        }

        [Test]
        public void PrimeFactorizationWorks()
        {
            var expected = new List<int> { 5, 7, 13, 29 };

            var actual = _prime.Factorize(13195);
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void LowestCommonMultipleWorks()
        {
            var expected = 2520;

            var source = Enumerable.Range(1, 10)
                .Select(i => (long)i)
                .ToArray();

            var actual = _prime.LCM(source);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NumberOfFactorsWorks()
        {
            var expected = 6;

            var actual = _prime.NumberOfFactors(28);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FactorizesCorrectly()
        {
            var expected = new[] {1, 2, 4, 71, 142, 284};

            var actual = _prime.Factors(284);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
