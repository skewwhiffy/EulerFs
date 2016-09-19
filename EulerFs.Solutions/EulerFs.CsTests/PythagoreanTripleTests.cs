using EulerFs.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class PythagoreanTripleTests
    {
        private PythagoreanTriple _pt;

        [SetUp]
        public void BeforeEach()
        {
            _pt = new PythagoreanTriple();
        }

        [Test]
        public void FindTriplesWorks()
        {
            var triples = _pt.UpTo(13);

            Assert.That(ContainsTriple(triples, 3, 4, 5));
            Assert.That(ContainsTriple(triples, 5, 12, 13));
            Assert.That(ContainsTriple(triples, 6, 8, 10));
        }

        private bool ContainsTriple(IEnumerable<Tuple<int, int, int>> triples, int a, int b, int c)
        {
            foreach(var t in triples)
            {
                if (t.Item1 == a && t.Item2 == b && t.Item3 == c)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
