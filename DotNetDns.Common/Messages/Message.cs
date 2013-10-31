namespace DotNetDns.Common.Messages
{
    public class Message
    {
        public ushort Id { get; set; }

        public bool IsAQuery { get; set; }

        public bool IsAuthoritative { get; set; }

        public OperationCode OperationCode { get; set; }
    }
}