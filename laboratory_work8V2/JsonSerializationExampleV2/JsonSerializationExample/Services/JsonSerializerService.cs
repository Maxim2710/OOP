using JsonSerializationExample.Interfaces;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace JsonSerializationExample.Services
{
    public class JsonSerializerService : IJsonSerializer
    {
        // Сериализация объекта в JSON
        public string Serialize<T>(T obj)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,  // предотвращает экранирование символа '+'
                WriteIndented = true // делает вывод в красивом формате
            };

            return JsonSerializer.Serialize(obj, options);
        }

        // Десериализация JSON в объект
        public T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
