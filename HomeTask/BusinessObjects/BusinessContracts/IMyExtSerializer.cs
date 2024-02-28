namespace BusinessContracts
{

    public interface IMyExtSerializer
    {
        void Serialize(object serializingObject, IMyExtSerializeBuilder builder);
            

        TSerialize DeSerialize<TSerialize>(IMyExtSerializeBuilder serializingObject) where TSerialize: new();
    }
}
