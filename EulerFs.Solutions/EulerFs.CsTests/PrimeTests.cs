using EulerFs.Common;
using NUnit.Framework;
using System;
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
    }
}
