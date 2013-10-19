using System;
using DotNetDns.Common.Extensions;

namespace DotNetDns.Common.Records
{
    public abstract class ResourceRecord
    {
        private int _timeToLiveSeconds;

        public RecordClass Class { get; set; }

        public int TimeToLiveSeconds 
        {
            get { return _timeToLiveSeconds; }
            set
            {
                ValidateTimeToLiveSeconds(value);
                _timeToLiveSeconds = value;
            }
        }

        public ResourceRecord()
        {
            Class = RecordClass.Internet;
        }

        private void ValidateTimeToLiveSeconds(int seconds)
        {
            if (seconds.IsNegative())
                throw new ArgumentException(string.Concat(seconds, " seconds is not a valid time to live. Value must be positive."));
        }
    }
}