using OnlineStore.Interfaces;

namespace OnlineStore.Models
{
    public class PercentageDiscount : IDiscount
    {
        public string Description { get; private set; }
        public decimal DiscountPercentage { get; private set; }

        public PercentageDiscount(string description, decimal discountPercentage)
        {
            Description = description;
            DiscountPercentage = discountPercentage;
        }

        public decimal Apply(decimal originalPrice)
        {
            return originalPrice * (1 - DiscountPercentage / 100);
        }
    }
}
