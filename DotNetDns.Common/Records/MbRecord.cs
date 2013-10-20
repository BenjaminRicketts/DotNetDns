namespace DotNetDns.Common.Records
{
    public class MbRecord : ResourceRecord
    {
        public override string Content { get { return MailBox; } }

        public string MailBox { get; set; }

        public override RecordType Type { get { return RecordType.MB; } }
    }
}