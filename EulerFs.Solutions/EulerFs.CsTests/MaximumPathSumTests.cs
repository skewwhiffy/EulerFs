using EulerFs.Common;
using NUnit.Framework;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class MaximumPathSumTests
    {
        private MaximumPathSum _instance;

        [SetUp]
        public void BeforeEach()
        {
            _instance = new MaximumPathSum(
                @"3
7 4
2 4 6
8 5 9 3");
        }

        [Test]
        public void CanAccessElements()
        {
            Assert.That(_instance[0], Is.EqualTo(new[] {3}));

            Assert.That(_instance[3], Is.EqualTo(new[] {8, 5, 9, 3}));
        }

        [Test]
        public void SubPathWorks()
        {
            var subPath = _instance.SubPathAt(2, 1);

            Assert.That(subPath[0], Is.EqualTo(new[] { 4 }));
            Assert.That(subPath[1], Is.EqualTo(new[] { 5, 9 }));
        }

        [Test]
        public void ValueWorks()
        {
            var value = _instance.Value;

            Assert.That(value, Is.EqualTo(23));
        }
    }
}
