using DotNetDns.Common.Records;

namespace DotNetDns.Common.Tests.Records
{
    public class WksRecordTests : BaseResourceRecordTests<WksRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.WKS; } }
    }
}