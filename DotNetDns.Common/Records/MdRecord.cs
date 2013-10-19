using System;

namespace DotNetDns.Common.Records
{
    [Obsolete("Obsolete - use an MX record.")]
    public class MdRecord : ResourceRecord
    {
        public override string Content { get { return MailDestination; } }

        public string MailDestination { get; set; }

        public override RecordType Type { get { return RecordType.MD; } }
    }
}