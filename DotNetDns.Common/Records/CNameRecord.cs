namespace DotNetDns.Common.Records
{
    public class CNameRecord : ResourceRecord
    {
        public string CanonicalName { get; set; }

        public override string Content { get { return CanonicalName; } }

        public override RecordType Type { get { return RecordType.CNAME; } }
    }
}