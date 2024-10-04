using System.Collections.Generic;

namespace Task1Hard1
{
    public class ConversionManager
    {
        private readonly List<string> allTypes = new List<string>
        {
            "char", "string", "byte", "int", "float", "double", "decimal", "bool", "object"
        };

        private readonly Dictionary<string, ConversionRule> conversionRules;

        public ConversionManager()
        {
            conversionRules = new Dictionary<string, ConversionRule>
            {
                { "byte", new ConversionRule { ImplicitConversions = new List<string> { "int", "float", "double", "decimal" },
                                              ExplicitConversions = new List<string> { "char", "string", "bool", "object", "decimal" } } },
                { "int", new ConversionRule { ImplicitConversions = new List<string> { "float", "double", "decimal" },
                                              ExplicitConversions = new List<string> { "char", "string", "byte", "bool", "object" } } },
                { "float", new ConversionRule { ImplicitConversions = new List<string> { "double" },
                                                ExplicitConversions = new List<string> { "char", "string", "byte", "int", "bool", "object" } } },
                { "char", new ConversionRule { ImplicitConversions = new List<string> { "string" },
                                              ExplicitConversions = new List<string> { "byte", "int", "float", "double", "decimal", "bool", "object" } } },
                { "object", new ConversionRule { ImplicitConversions = new List<string> { "string", "char", "byte", "int", "float", "double", "decimal", "bool" },
                                               ExplicitConversions = new List<string> { "char", "string", "byte", "int", "float", "double", "decimal", "bool" } } },
                { "string", new ConversionRule { ExplicitConversions = new List<string> { "char", "byte", "int", "float", "double", "decimal", "bool", "object" } } },
                { "double", new ConversionRule { ExplicitConversions = new List<string> { "char", "string", "byte", "int", "float", "bool", "object" } } },
                { "decimal", new ConversionRule { ExplicitConversions = new List<string> { "char", "string", "byte", "int", "float", "double", "bool", "object" } } },
                { "bool", new ConversionRule { ExplicitConversions = new List<string> { "char", "string", "byte", "int", "float", "double", "decimal", "object" } } }
            };
        }

        public List<string> GetAllTypes() => allTypes;

        public bool CanImplicitlyConvert(string sourceType, string targetType) =>
            conversionRules.TryGetValue(sourceType, out var rule) && rule.ImplicitConversions.Contains(targetType);

        public bool CanExplicitlyConvert(string sourceType, string targetType) =>
            conversionRules.TryGetValue(sourceType, out var rule) && rule.ExplicitConversions.Contains(targetType);
    }
}
