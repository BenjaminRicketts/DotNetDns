using DotNetDns.Common.Extensions;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Extensions
{
    [TestFixture]
    public class IntegerExtensionsTests
    {
        [Test]
        [TestCase(-1, true)]
        [TestCase(0, false)]
        [TestCase(1, false)]
        public void Negative_Numbers_Are_Correctly_Identified(int numberToTest, bool expectedResult)
        {
            Assert.That(numberToTest.IsNegative(), Is.EqualTo(expectedResult));
        }
    }
}