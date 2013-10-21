namespace DotNetDns.Common.Records
{
    public class HInfoRecord : ResourceRecord
    {
        public override string Content { get { return string.Concat(Cpu, " ", OperatingSystem); } }

        public string Cpu { get; set; }

        public string OperatingSystem { get; set; }

        public override RecordType Type { get { return RecordType.HINFO; } }
    }
}