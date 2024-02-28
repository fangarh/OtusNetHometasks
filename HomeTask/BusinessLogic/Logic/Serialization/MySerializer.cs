using BusinessContracts;
using Logic.Serialization.Helpers;

namespace Logic.Serialization
{
    public class MySerializer : IMySerializer
    {
        private IMyExtSerializeBuilder _serializeBuilder;
        private IMyExtSerializer _serializer;

        public MySerializer(IMyExtSerializeBuilder serializeBuilder = null)
        {
            _serializeBuilder = serializeBuilder ?? new SerializedStringBuilder();
            _serializer = new MyExtSerializer();
        }

        public string SerializeToString(object obj)
        {
            _serializer.Serialize(obj, _serializeBuilder);
            return _serializeBuilder.SerializeToString();
        }

        public T ParseSerializedString<T>(string str) where T : new()
        {
            _serializeBuilder.ParseSerializedString(str);
            return _serializer.DeSerialize<T>(_serializeBuilder);
        }
    }
}
