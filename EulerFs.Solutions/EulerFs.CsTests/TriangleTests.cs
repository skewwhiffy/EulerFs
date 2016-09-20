using EulerFs.Common;
using NUnit.Framework;

namespace EulerFs.CsTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void TriangleWorks()
        {
            var triangle = new Triangle();
            var expected = 0;
            for (var i = 0; i < 100; i++)
            {
                expected += i;
                Assert.That(triangle[i], Is.EqualTo(expected));
            }
        }
    }
}
