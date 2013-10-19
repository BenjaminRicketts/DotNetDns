using System.Net;

namespace DotNetDns.Common.Records
{
    public class ARecord : ResourceRecord
    {
        public override string Content { get { return IpAddress.ToString(); } }

        public IPAddress IpAddress { get; set; }

        public override RecordType Type { get { return RecordType.A; } }
    }
}