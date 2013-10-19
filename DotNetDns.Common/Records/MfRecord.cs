using System;

namespace DotNetDns.Common.Records
{
    [Obsolete("Obsolete - use an MX record.")]
    public class MfRecord : ResourceRecord
    {
        public override string Content { get { return MailForwarder; } }

        public string MailForwarder { get; set; }

        public override RecordType Type { get { return RecordType.MF; } }
    }
}