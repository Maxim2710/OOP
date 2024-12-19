namespace MyCustomCollections.Interfaces
{
    public interface ICustomDictionary<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        bool Remove(TKey key);
        TValue Get(TKey key);
        bool ContainsKey(TKey key);
        int Count { get; }
    }
}