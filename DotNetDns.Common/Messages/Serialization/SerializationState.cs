namespace DotNetDns.Common.Messages.Serialization
{
    internal class SerializationState
    {

        internal Message Message { get; set; }

        internal byte[] MessageBytes { get; set; }

        private int BufferPosition { get; set; }

        internal byte GetNextMessageByte()
        {
            return MessageBytes[BufferPosition++];
        }
    }
}