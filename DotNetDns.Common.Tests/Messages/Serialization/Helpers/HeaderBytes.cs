using System;

namespace DotNetDns.Common.Tests.Messages.Serialization
{
    internal class HeaderBytes
    {
        private byte[] _headerBytes;

        internal HeaderBytes()
        {
            _headerBytes = new byte[4];
        }

        internal HeaderBytes WithFlagBytes(byte[] bytes)
        {
            SetBytesAt(2, bytes);
            return this;
        }

        internal HeaderBytes WithIdBytes(byte[] bytes)
        {
            SetBytesAt(0, bytes);
            return this;
        }

        internal byte[] ToArray()
        {
            return _headerBytes;
        }

        private void SetBytesAt(int index, byte[] bytes)
        {
            Array.Copy(bytes, 0, _headerBytes, index, bytes.Length);
        }
    }
}