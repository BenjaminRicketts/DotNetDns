namespace DotNetDns.Common.Records
{
    public class PtrRecord : ResourceRecord
    {
        public override string Content { get { return Pointer; } }

        public string Pointer { get; set; }

        public override RecordType Type { get { return RecordType.PTR; } }
    }
}