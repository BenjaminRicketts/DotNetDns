namespace DotNetDns.Common.Records
{
    public class MInfoRecord : ResourceRecord
    {
        public override string Content { get { return string.Concat(ResponsibleMailBox, " ", ErrorMailBox); } }

        public string ErrorMailBox { get; set; }

        public string ResponsibleMailBox { get; set; }

        public override RecordType Type { get { return RecordType.MINFO; } }
    }
}