using System;

namespace DotNetDns.Common.Messages.Serialization.Serializers
{
    internal class FlagsSerializer : PropertySerializer
    {
        internal FlagsSerializer(IEndianessChecker endianessChecker)
            : base(endianessChecker)
        {
        }

        internal override SerializationState Deserialize(SerializationState state)
        {
            var flags = DeserializeUnsignedShort(state);

            state.Message.IsAQuery = IsSelectedBitFalse(flags, 0x8000);
            state.Message.OperationCode = (OperationCode)((flags & 0x7800) >> 11);
            state.Message.IsAuthoritative = IsSelectedBitTrue(flags, 0x0400);

            return state;
        }

        private bool IsSelectedBitFalse(ushort flags, ushort bitToCheck)
        {
            return !IsSelectedBitTrue(flags, bitToCheck);
        }

        private bool IsSelectedBitTrue(ushort flags, ushort bitToCheck) 
        {
            return (flags & bitToCheck) != 0;
        }
    }
}