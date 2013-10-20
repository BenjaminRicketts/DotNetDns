using System.Collections.Generic;
namespace DotNetDns.Common.Records
{
    public class SoaRecord : ResourceRecord
    {
        public override string Content 
        { 
            get 
            {
                return string.Join(
                            " ",
                            PrimaryNameserver,
                            ResponsibleMailBox,
                            SerialNumber,
                            RefreshSeconds,
                            RetrySeconds,
                            ExpirySeconds,
                            MinimumTimeToLiveSeconds);
            } 
        }

        public int ExpirySeconds { get; set; }

        public int MinimumTimeToLiveSeconds { get; set; }

        public string PrimaryNameserver { get; set; }

        public int RefreshSeconds { get; set; }

        public string ResponsibleMailBox { get; set; }

        public int RetrySeconds { get; set; }

        public uint SerialNumber { get; set; }

        public override RecordType Type { get { return RecordType.SOA; } }
    }
}