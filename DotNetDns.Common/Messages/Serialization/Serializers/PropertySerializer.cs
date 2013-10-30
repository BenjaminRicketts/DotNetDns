using System;

namespace DotNetDns.Common.Messages.Serialization.Serializers
{
    internal abstract class PropertySerializer
    {
        private readonly IEndianessChecker _endianessChecker;

        internal PropertySerializer(IEndianessChecker endianessChecker)
        {
            _endianessChecker = endianessChecker;
        }

        internal abstract SerializationState Deserialize(SerializationState state);

        protected ushort DeserializeUnsignedShort(SerializationState state)
        {
            ushort number;

            if (_endianessChecker.IsLittleEndianSystem)
                number = (ushort)((state.GetNextMessageByte() << 8) | state.GetNextMessageByte());
            else
                number = (ushort)(state.GetNextMessageByte() | (state.GetNextMessageByte() << 8));

            return number;
        }
    }
}