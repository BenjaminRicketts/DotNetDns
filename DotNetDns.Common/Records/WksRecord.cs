using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDns.Common.Records
{
    public class WksRecord : ResourceRecord
    {
        public override string Content { get { return string.Empty; } }

        public override RecordType Type { get { return RecordType.WKS; } }
    }
}