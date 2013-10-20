using System;
using System.Collections.Generic;
using System.Linq;
using DotNetDns.Common.Records;
using NUnit.Framework;
using Fasterflect;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class RecordTypeTests
    {
        [Test]
        [TestCaseSource("RecordTypeTestCases")]
        public void Record_Types_Map_To_The_Correct_Byte_Values(RecordType recordType, byte expectedValue)
        {
            Assert.That((byte)recordType, Is.EqualTo(expectedValue));
        }

        [Test]
        public void All_Record_Types_Are_Being_Tested()
        {
            var testedTypes = RecordTypeTestCases
                                .Select(testCase => (RecordType)(testCase.Arguments.First()))
                                .ToList();

            var nonTestedTypes = Enum.GetValues(typeof(RecordType))
                                     .OfType<RecordType>()
                                     .Except(testedTypes);

            Assert.That(nonTestedTypes, Is.Empty);
        }

        [Test]
        public void Md_Record_Type_Is_Marked_As_Obsolete()
        {
            AssertMxRecordAncestorIsObsolete(RecordType.MD);
        }

        [Test]
        public void Mf_Record_Type_Is_Marked_As_Obsolete()
        {
            AssertMxRecordAncestorIsObsolete(RecordType.MF);
        }

        public void AssertMxRecordAncestorIsObsolete(RecordType recordType)
        {
            var expectedMessage = "Obsolete - use an MX record.";
            var attribute = recordType.Attribute<ObsoleteAttribute>();

            Assert.That(attribute.Message, Is.EqualTo(expectedMessage));
        }

        private IEnumerable<TestCaseData> RecordTypeTestCases
        {
            get
            {
                return new List<TestCaseData>
                {
                    new TestCaseData(RecordType.A, (byte)1),
                    new TestCaseData(RecordType.NS, (byte)2),
                    new TestCaseData(RecordType.MD, (byte)3),
                    new TestCaseData(RecordType.MF, (byte)4),
                    new TestCaseData(RecordType.CNAME, (byte)5),
                    new TestCaseData(RecordType.SOA, (byte)6),
                    new TestCaseData(RecordType.MB, (byte)7)
                };
            }
        }
    }
}