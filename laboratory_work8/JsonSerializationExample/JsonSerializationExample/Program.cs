using JsonSerializationExample.Models;
using JsonSerializationExample.Services;
using JsonSerializationExample.Interfaces;
using System;
using System.Collections.Generic;

namespace JsonSerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JSON Serialization Example with Nested Structure:");

            // Создаём сложный объект Person
            var person = new Person
            {
                Name = "Alice",
                Age = 30,
                Email = "alice@example.com",
                HomeAddress = new Address
                {
                    Street = "123 Main St",
                    City = "Wonderland",
                    PostalCode = "12345"
                },
                Phones = new List<Phone>
                {
                    new Phone { Type = "Mobile", Number = "+1234567890" },
                    new Phone { Type = "Work", Number = "+0987654321" }
                }
            };

            // Используем JsonSerializerService
            IJsonSerializer serializer = new JsonSerializerService();

            // Сериализация
            Console.WriteLine("\nSerializing object...");
            var json = serializer.Serialize(person);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);

            // Десериализация
            Console.WriteLine("\nDeserializing JSON...");
            var deserializedPerson = serializer.Deserialize<Person>(json);
            Console.WriteLine("Deserialized Object:");
            Console.WriteLine(deserializedPerson);
        }
    }
}
