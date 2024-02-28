using BusinessContracts;
using Logic.Serialization;

namespace ReflectionsTest
{
    internal class HomeTaskTests
    {
        public string MySerializationTest(IMySerializer serializer, object obj, int serializationCount)
        {
            string str = "";
            for (int i = 0; i < serializationCount; i++)
            {
                str = serializer.SerializeToString(obj);
            }

            return str;
        }

        public T MyDeserializationTest<T>(IMySerializer serializer, string serializedString, int serializationCount) where T: new()
        {
            T result = default(T);

            
            for (int i = 0; i < serializationCount; i++)
            {
                result = serializer.ParseSerializedString<T>(serializedString);
            }

            return result;
        }


    }
}
