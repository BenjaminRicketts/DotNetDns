using System;

namespace DotNetDns.Common.Message.Serialization
{
    public interface IEndianessChecker
    {
        bool IsLittleEndianSystem { get; }
    }
}