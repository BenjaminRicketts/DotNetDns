using System;

namespace DotNetDns.Common.Message.Serialization
{
    public class MessageSerializer
    {
        public Message DeserializeFromBytes(byte[] bytes)
        {
            throw new Exception("Null bytes cannot be deserialized into a Message.");
        }
    }
}