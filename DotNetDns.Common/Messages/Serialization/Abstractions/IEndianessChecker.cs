using System;

namespace DotNetDns.Common.Messages.Serialization
{
    public interface IEndianessChecker
    {
        bool IsLittleEndianSystem { get; }
    }
}