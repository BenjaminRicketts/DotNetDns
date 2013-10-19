namespace DotNetDns.Common.Records
{
    public class NsRecord : ResourceRecord
    {
        public override string Content { get { return Nameserver; } }

        public string Nameserver { get; set; }

        public override RecordType Type { get { return RecordType.NS; } }
    }
}