namespace OnlineStore.Interfaces
{
    public interface IDiscount
    {
        string Description { get; }
        decimal DiscountPercentage { get; }
        decimal Apply(decimal originalPrice);
    }
}
