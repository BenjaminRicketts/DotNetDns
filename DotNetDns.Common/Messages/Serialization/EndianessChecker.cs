using System;
using DotNetDns.Bootstrapper.Ioc.Attributes;

namespace DotNetDns.Common.Messages.Serialization
{
    [Singleton]
    public class EndianessChecker : IEndianessChecker
    {
        public bool IsLittleEndianSystem 
        { 
            get 
            {
                return BitConverter.IsLittleEndian;
            } 
        }
    }
}