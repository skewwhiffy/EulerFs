using System;
using System.Diagnostics;
using System.Linq;
using EulerFs.Common;
using NUnit.Framework;

namespace EulerFs.CsTests
{
    public class FactorizeTests
    {
        private Factorize _factorize;

        [SetUp]
        public void BeforeEach()
        {
            _factorize = new Factorize();
        }

        [Test]
        public void IsAbundantWorks()
        {
            for (var i = 0; i < 12; i++)
            {
                Assert.That(_factorize.IsAbundant(i), Is.False);
            }

            Assert.That(_factorize.IsAbundant(12), Is.True);
            Assert.That(_factorize.IsAbundant(8286), Is.True);
        }

        [Test]
        public void AbundantsWorks()
        {
            var abundants = _factorize.GetAbundants.TakeWhile(x => x < 2812).ToList();

            Assert.That(abundants.Count, Is.EqualTo(693));
        }

        [Test]
        public void AbundantIsFastEnough()
        {
            var timer = Stopwatch.StartNew();
            foreach (var abundant in _factorize.GetAbundants.TakeWhile(x => x < 5000))
            {
                if (timer.Elapsed > TimeSpan.FromSeconds(1))
                {
                    Console.WriteLine($"Last abundant: {abundant}");
                    Assert.Fail();
                }
            }
        }
    }
}
