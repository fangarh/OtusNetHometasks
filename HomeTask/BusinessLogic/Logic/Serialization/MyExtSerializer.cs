using System.Reflection;
using BusinessContracts;

namespace Logic.Serialization
{
    public class MyExtSerializer:IMyExtSerializer
    {
        public void Serialize(object serializingObject, IMyExtSerializeBuilder builder)
        {
            Type serializingTypeInfo = serializingObject.GetType();

            var properties = serializingTypeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var fields = serializingTypeInfo.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            builder.Flush();

            foreach (PropertyInfo property in properties)
            {
                builder.Append(property.Name, property.GetValue(serializingObject));
            }

            foreach (var field in fields)
            {
                builder.Append(field.Name, field.GetValue(serializingObject));
            }
        }
        
        public TSerialize DeSerialize<TSerialize>(IMyExtSerializeBuilder serializingObject) where TSerialize: new ()
        {
            Type serializingTypeInfo = typeof(TSerialize);
            TSerialize result = new TSerialize();

            var properties = serializingTypeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var fields = serializingTypeInfo.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(result, GetElementValue(serializingObject, property.Name, property.PropertyType));
            }

            foreach (var field in fields)
            {
                field.SetValue(result, GetElementValue(serializingObject, field.Name, field.FieldType));
            }
            
            return result;
        }

        private object? GetElementValue(IMyExtSerializeBuilder sb, string name, Type t)
        {
            var valToSet = sb.Get(name);

            return valToSet == null ? null : Convert.ChangeType(valToSet, t);
        }
    }
}
