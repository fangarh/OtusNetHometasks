using BusinessContracts;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Logic.Serialization
{
    public class MyJsonSerializer: IMySerializer
    {
        public string SerializeToString(object obj)
        {
            return JsonSerializer.Serialize(obj, JsonOptions());
        }

        public T ParseSerializedString<T>(string jsonString) where T : new()
        {
            return JsonSerializer.Deserialize<T>(jsonString, JsonOptions());
        }

        static JsonSerializerOptions JsonOptions()
        {
            var opt = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
            };
            return opt;
        }
    }
}
