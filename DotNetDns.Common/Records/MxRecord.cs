namespace DotNetDns.Common.Records
{
    public class MxRecord : ResourceRecord
    {
        public override string Content { get { return string.Concat(Preference, " ", Exchange); } }

        public string Exchange { get; set; }

        public short Preference { get; set; }

        public override RecordType Type { get { return RecordType.MX; } }
    }
}