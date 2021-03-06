﻿using System;

namespace DotNetDns.Common.Records
{
    public enum RecordType : byte
    {
        A = 1,
        NS = 2,
        [Obsolete("Obsolete - use an MX record.")]
        MD = 3,
        [Obsolete("Obsolete - use an MX record.")]
        MF = 4,
        CNAME = 5,
        SOA = 6,
        MB = 7,
        MG = 8,
        MR = 9,
        NULL = 10,
        WKS = 11,
        PTR = 12,
        HINFO = 13,
        MINFO = 14,
        MX = 15
    }
}