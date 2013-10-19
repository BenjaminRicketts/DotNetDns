using System;
using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public abstract class BaseResourceRecordTests<T> where T : ResourceRecord
    {
        protected abstract RecordType ExpectedType { get; }

        protected T Record { get; private set; }

        [SetUp]
        public void SetupTest()
        {
            Record = Activator.CreateInstance<T>();
        }

        [Test]
        public void Record_Type_Is_Correct()
        {
            Assert.That(Record.Type, Is.EqualTo(ExpectedType));
        }
    }
}