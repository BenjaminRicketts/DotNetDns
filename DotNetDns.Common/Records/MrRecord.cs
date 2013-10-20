namespace DotNetDns.Common.Records
{
    public class MrRecord : ResourceRecord 
    {
        public override string Content { get { return MailRename; } }

        public string MailRename { get; set; }

        public override RecordType Type { get { return RecordType.MR; } }
    }
}