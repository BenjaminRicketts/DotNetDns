using System;
namespace DotNetDns.Common.Records
{
    public enum RecordType : byte
    {
        A = 1,
        NS = 2,
        [Obsolete("Obsolete - use an MX record.")]
        MD = 3
    }
}