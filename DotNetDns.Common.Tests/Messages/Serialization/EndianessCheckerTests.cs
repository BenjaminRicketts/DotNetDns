using System;
using DotNetDns.Common.Messages.Serialization;
using DotNetDns.TestHelpers.Assertions;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Messages.Serialization
{
    [TestFixture]
    public class EndianessCheckerTests
    {
        [Test]
        public void Chcker_Class_Is_A_Singleton()
        {
            ClassAssertions.AssertClassIsSingleton<EndianessChecker>();
        }

        [Test]
        public void Is_Little_Endian_System_Returns_Bit_Converter_Value()
        {
            var isLittleEndian = new EndianessChecker().IsLittleEndianSystem;

            Assert.That(isLittleEndian, Is.EqualTo(BitConverter.IsLittleEndian));
        }
    }
}