using System;

namespace DotNetDns.Common.Messages.Serialization
{
    public interface IMessageSerializer
    {
        Message DeserializeFromBytes(byte[] bytes);
    }
}