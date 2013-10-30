using System;

namespace DotNetDns.Common.Messages.Serialization
{
    public class MessageSerializer : IMessageSerializer
    {
        public Message DeserializeFromBytes(byte[] bytes)
        {
            throw new Exception("Null bytes cannot be deserialized into a Message.");
        }
    }
}