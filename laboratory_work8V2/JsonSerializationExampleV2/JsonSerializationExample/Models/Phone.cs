namespace JsonSerializationExample.Models
{
    public class Phone
    {
        public string Type { get; set; } // Например, "Mobile", "Work"
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{Type}: {Number}";
        }
    }
}
