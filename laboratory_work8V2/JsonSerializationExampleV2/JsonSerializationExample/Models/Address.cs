namespace JsonSerializationExample.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{Street}, {City}, {PostalCode}";
        }
    }
}
