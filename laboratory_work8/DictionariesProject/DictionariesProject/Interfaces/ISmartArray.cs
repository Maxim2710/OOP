namespace MyCustomCollections.Interfaces
{
    public interface ISmartArray<T>
    {
        T this[int index] { get; set; }
        int Length { get; }
    }
}
