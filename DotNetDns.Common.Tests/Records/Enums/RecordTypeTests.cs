using System;
using System.Collections.Generic;
using System.Linq;
using DotNetDns.Common.Records;
using NUnit.Framework;

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

        private IEnumerable<TestCaseData> RecordTypeTestCases
        {
            get
            {
                return new List<TestCaseData>
                {
                    new TestCaseData(RecordType.A, (byte)1)
                };
            }
        }
    }
}