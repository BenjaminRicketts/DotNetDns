using System;
using System.Collections.Generic;
using DotNetDns.Common.Messages.Serialization.Serializers;

namespace DotNetDns.Common.Messages.Serialization
{
    public class MessageSerializer : IMessageSerializer
    {
        private readonly IEndianessChecker _endianessChecker;
        private IList<PropertySerializer> _serializers;

        private IList<PropertySerializer> Serializers
        {
            get
            {
                if (_serializers == null)
                {
                    _serializers = new List<PropertySerializer>
                    {
                        new IdSerializer(_endianessChecker),
                        new FlagsSerializer(_endianessChecker)
                    };
                }

                return _serializers;
            }
        }

        public MessageSerializer(IEndianessChecker endianessChecker)
        {
            _endianessChecker = endianessChecker;
        }

        public Message DeserializeFromBytes(byte[] bytes)
        {
            ValidateBytes(bytes);

            var state = CreateState(bytes);

            foreach (var serializer in Serializers)
                state = serializer.Deserialize(state);

            return state.Message;
        }

        private SerializationState CreateState(byte[] bytes)
        {
            return new SerializationState
            {
                Message = new Message(),
                MessageBytes = bytes
            };
        }

        private void ValidateBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new Exception("Null bytes cannot be deserialized into a Message.");
        }
    }
}