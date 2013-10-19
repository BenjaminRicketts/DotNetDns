using System;

namespace DotNetDns.Common.Records
{
    public enum RecordClass : byte
    {
        Internet = 1,
        [Obsolete("Obsolete - used only for examples in some obsolete RFCs.")]
        CSNet = 2,
        CHAOS = 3,
        Hesiod = 4
    }
}