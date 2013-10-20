namespace DotNetDns.Common.Records
{
    public class NullRecord : ResourceRecord
    {
        public override string Content { get { return Data; } }

        public string Data { get; set; }

        public override RecordType Type { get { return RecordType.NULL; } }
    }
}