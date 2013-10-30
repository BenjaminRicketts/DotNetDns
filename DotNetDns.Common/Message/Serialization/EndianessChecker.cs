using System;
using DotNetDns.Bootstrapper.Ioc.Attributes;

namespace DotNetDns.Common.Message.Serialization
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