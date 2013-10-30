namespace DotNetDns.Common.Messages.Serialization.Serializers
{
    internal class IdSerializer : PropertySerializer
    {
        internal IdSerializer(IEndianessChecker endianessChecker)
            : base(endianessChecker)
        {
        }

        internal override SerializationState Deserialize(SerializationState state)
        {
            state.Message.Id = DeserializeUnsignedShort(state);

            return state;
        }
    }
}