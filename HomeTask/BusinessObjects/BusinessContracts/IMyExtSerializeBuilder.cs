namespace BusinessContracts
{
    public interface IMyExtSerializeBuilder
    {
        void Flush();
        void Append(string property, object? data);
        object? Get(string property);
        string SerializeToString();
        void ParseSerializedString(string str);
        void SaveToFile(string path);
        void LoadFromFile(string path);
    }
}
