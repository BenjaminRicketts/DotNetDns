using System;
using DotNetDns.Common.Message.Serialization;
using NUnit.Framework;
using Fasterflect;
using DotNetDns.TestHelpers.Assertions;

namespace DotNetDns.Common.Tests.Message.Serialization
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