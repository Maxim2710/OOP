using System;

namespace Task1Hard1
{
    public class TypeConverter
    {
        public static dynamic ConvertToType(string input, string type)
        {
            switch (type)
            {
                case "char":
                    return Convert.ToChar(input);
                case "string":
                    return input.ToString();
                case "byte":
                    return Convert.ToByte(input);
                case "int":
                    return Convert.ToInt32(input);
                case "float":
                    return Convert.ToSingle(input);
                case "double":
                    return Convert.ToDouble(input);
                case "decimal":
                    return Convert.ToDecimal(input);
                case "bool":
                    return Convert.ToBoolean(input);
                case "object":
                    return (object)input;
                default:
                    throw new InvalidOperationException("Неизвестный тип.");
            }
        }

        public static dynamic ExplicitConversion(dynamic value, string targetType)
        {
            switch (targetType)
            {
                case "char":
                    return Convert.ToChar(value);
                case "string":
                    return value.ToString();
                case "byte":
                    return Convert.ToByte(value);
                case "int":
                    return Convert.ToInt32(value);
                case "float":
                    return Convert.ToSingle(value);
                case "double":
                    return Convert.ToDouble(value);
                case "decimal":
                    return Convert.ToDecimal(value);
                case "bool":
                    return Convert.ToBoolean(value);
                case "object":
                    return (object)value;
                default:
                    throw new InvalidOperationException("Неизвестный тип.");
            }
        }
    }
}
