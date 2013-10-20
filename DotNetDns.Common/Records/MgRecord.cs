namespace DotNetDns.Common.Records
{
    public class MgRecord : ResourceRecord
    {
        public override string Content { get { return MailGroup; } }

        public string MailGroup { get; set; }

        public override RecordType Type { get { return RecordType.MG; } }
    }
}