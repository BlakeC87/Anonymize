namespace DirectSupply.Anonymize.Service.Caching
{
    public interface ICache
    {
        void AddItem(string key, object value);
        object GetItem(string key);
        bool ContainsKey(string key);
    }
}
