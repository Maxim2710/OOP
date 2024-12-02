namespace JsonSerializationExample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Address HomeAddress { get; set; } // Вложенный объект
        public List<Phone> Phones { get; set; } // Коллекция объектов

        public override string ToString()
        {
            var phonesString = Phones != null ? string.Join(", ", Phones.Select(p => p.ToString())) : "No Phones";
            return $"{Name}, Age: {Age}, Email: {Email}, Address: {HomeAddress}, Phones: [{phonesString}]";
        }
    }
}
