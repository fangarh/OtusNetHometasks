using System.Collections;
using System.Data;
using System.Text;
using BusinessContracts;
using BusinessObjects;

namespace Logic.Serialization
{
    public class SerializedStringBuilder : IMyExtSerializeBuilder
    {
        private readonly Hashtable _dictionary = new Hashtable();

        public void Flush()
        {
            _dictionary.Clear();
        }

        public void Append(string property, object  data)
        {
            if (_dictionary.ContainsKey(property))
                throw new DuplicateNameException($"Key {property} already exists");

            _dictionary.Add(property, data??Constants.NullValue);
        }

        public object Get(string property)
        {
            if(!_dictionary.ContainsKey(property))
                throw new NullReferenceException($"Property {property} not found in collection");

            if (_dictionary[property] == null || _dictionary[property].ToString().Equals($"{Constants.NullValue}"))
                return null;

            return _dictionary[property];
        }

        public string SerializeToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (DictionaryEntry entry in _dictionary)
            {
                sb.Append($"{entry.Key}{Constants.Separator}{Constants.ValueComma}{entry.Value ?? Constants.NullValue}{Constants.ValueComma}{Constants.EndRecord}");
            }

            return sb.ToString();
        }

        public void ParseSerializedString(string str)
        {
            var stringParts = str.Split($"{Constants.EndRecord}", StringSplitOptions.RemoveEmptyEntries);
            Flush();
            foreach (var stringPart in stringParts)
            {
                var keyValueSet = stringPart.Split($"{Constants.Separator}");
                object val = keyValueSet[1].Replace($"{Constants.ValueComma}", "");

                if (val == null)
                    throw new ArgumentOutOfRangeException($"Error in parsed string {stringPart}");

                val = val.ToString().Equals(Constants.NullValue, StringComparison.InvariantCultureIgnoreCase)
                    ? null
                    : keyValueSet[1].Replace($"{Constants.ValueComma}", "");


                _dictionary.Add(keyValueSet[0], val);
            }
        }

        public void SaveToFile (string path)
        {
            if(File.Exists(path))
                File.Delete(path);

            //File.Create(path);
            
            File.WriteAllText(path, SerializeToString());
        }

        public void LoadFromFile (string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            string str = File.ReadAllText(path);

            ParseSerializedString(str);
        }
    }
}
