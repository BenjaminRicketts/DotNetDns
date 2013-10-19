using System;
using DotNetDns.Common.Records;
using Fasterflect;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class RecordClassTests
    {
        [Test]
        [TestCase(RecordClass.Internet, 1)]
        [TestCase(RecordClass.CSNet, 2)]
        [TestCase(RecordClass.CHAOS, 3)]
        [TestCase(RecordClass.Hesiod, 4)]
        public void Record_Classes_Map_To_The_Correct_Byte_Values(RecordClass recordClass, byte expectedValue)
        {
            Assert.That((byte)recordClass, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Obselete_Record_Classes_Are_Marked_As_Such()
        {
            var expectedMessage = "Obsolete - used only for examples in some obsolete RFCs.";
            var attribute = RecordClass.CSNet.Attribute<ObsoleteAttribute>();

            Assert.That(attribute.Message, Is.EqualTo(expectedMessage));
        }
    }
}