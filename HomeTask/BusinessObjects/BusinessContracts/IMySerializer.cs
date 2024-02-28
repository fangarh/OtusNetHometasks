namespace BusinessContracts;

public interface IMySerializer
{
    string SerializeToString(object obj);
    T ParseSerializedString<T>(string str) where T : new();
}