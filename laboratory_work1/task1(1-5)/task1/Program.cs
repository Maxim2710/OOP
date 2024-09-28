using System;

namespace laboratory_work1
{
    public class Program
    {
        static void Main()
        {
            firstMethod();
            secondMethod();
            thirdMethod();
            FourthTask();
            FifthTask();
        }

        static void firstMethod()
        {
            /*
            Таблица неявных преобразований типов:

            sbyte   →   short, int, long, float, double, decimal или nint
            byte    →   short, ushort, int, uint, long, ulong, float, double, decimal, nint или nuint
            short   →   int, long, float, double или decimal либо nint
            ushort  →   int, uint, long, ulong, float, double или decimal, nint или nuint
            int     →   long, float, double или decimal, nint
            uint    →   long, ulong, float, double или decimal либо nuint
            long    →   float, double или decimal
            ulong   →   float, double или decimal
            float   →   double
            nint    →   long, float, double или decimal
            nuint   →   ulong, float, double или decimal
            */

            // 1. Неявное преобразование от меньшего типа к большему
            int intVal = 42;                // int -> double
            double doubleVal = intVal;      // Неявное преобразование int в double

            // 2. Неявное преобразование типа byte в int
            byte byteVal = 10;
            int intFromByte = byteVal;      // byte -> int

            // 3. Неявное преобразование типа float в double
            float floatVal = 5.5f;
            double doubleFromFloat = floatVal; // float -> double

            // 4. Неявное преобразование типа char в int
            char charVal = 'A';
            int intFromChar = charVal;      // char -> int

            // Примеры неявных преобразований ссылочных типов:

            // 1. Преобразование производного типа в базовый
            DerivedClass derived = new DerivedClass();
            BaseClass baseClass = derived;  // DerivedClass -> BaseClass

            // 2. Неявное преобразование null в любой ссылочный тип
            string nullString = null;       // null -> string
            object nullObject = null;       // null -> object

            // 3. Неявное преобразование строки в object
            string str = "Hello World";
            object obj = str;               // string -> object
        }

        static void secondMethod()
        {
            /*
            Таблица явных преобразований типов:

            sbyte   →   byte, ushort, uint, ulong или nuint
            byte    →   sbyte
            short   →   sbyte, byte, ushort, uint, ulong или nuint
            ushort  →   sbyte, byte или short
            int     →   sbyte, byte, short, ushort, uint, ulong или nuint
            uint    →   sbyte, byte, short, ushort, int или nint
            long    →   sbyte, byte, short, ushort, int, uint, ulong, nint или nuint
            ulong   →   sbyte, byte, short, ushort, int, uint, long, nint или nuint
            float   →   sbyte, byte, short, ushort, int, uint, long, ulong, decimal, nint или nuint
            double  →   sbyte, byte, short, ushort, int, uint, long, ulong, float, decimal, nint или nuint
            decimal →   sbyte, byte, short, ushort, int, uint, long, ulong, float, double, nint или nuint
            nint    →   sbyte, byte, short, ushort, int, uint, ulong или nuint
            nuint   →   sbyte, byte, short, ushort, int, uint, long или nint
            */

            // Примеры явных преобразований простых типов:
            double doubleVal = 42.58;
            int intFromDouble = (int)doubleVal;      // double -> int

            long longVal = 10000;
            short shortFromLong = (short)longVal;    // long -> short

            float floatVal = 5.7f;
            byte byteFromFloat = (byte)floatVal;     // float -> byte

            decimal decimalVal = 123.45m;
            int intFromDecimal = (int)decimalVal;    // decimal -> int

            // Примеры явных преобразований ссылочных типов:
            object obj = "Hello World";
            string strFromObject = (string)obj;      // object -> string

            BaseClass baseClass = new DerivedClass();
            DerivedClass derivedFromBase = (DerivedClass)baseClass; // BaseClass -> DerivedClass
        }

        static void thirdMethod()
        {
            // Пример безопасного приведения ссылочных типов с помощью операторов as и is
            object numberObject = 54.4;

            // Использование оператора 'as' для приведения типа
            string stringValue = numberObject as string;
            if (stringValue != null)
            {
                Console.WriteLine($"Это строка: {stringValue}");
            }
            else
            {
                Console.WriteLine("numberObject не строка");
            }

            // Использование оператора 'is' для проверки и приведения типа
            if (numberObject is double doubleValue)
            {
                Console.WriteLine($"Это число {doubleValue}");
            }
            else
            {
                Console.WriteLine("numberObject не double");
            }
        }

        static void FourthTask()
        {
            // Пользовательское преобразование типов Implicit, Explicit;

            WeightKilograms kg = new WeightKilograms(70); // 70 кг
            WeightPounds lb = kg; // Неявное преобразование в фунты
            Console.WriteLine(lb.Value); // 154.3234

            lb.Value = 150; // Установка нового значения в фунтах
            kg = (WeightKilograms)lb; // Явное преобразование в килограммы
            Console.WriteLine(kg.Value); // 68.18181818181819
        }

        static void FifthTask()
        {
            // Преобразование строки в число с помощью класса Convert
            string strNumber = "123";
            int convertedNumber = Convert.ToInt32(strNumber);
            Console.WriteLine($"Преобразование строки '{strNumber}' в число с помощью Convert: {convertedNumber}"); // 123

            // Преобразование строки в число с помощью метода Parse
            string strNumber2 = "456";
            try
            {
                int parsedNumber = int.Parse(strNumber2);
                Console.WriteLine($"Преобразование строки '{strNumber2}' в число с помощью Parse: {parsedNumber}"); // 456
            }
            catch (FormatException)
            {
                Console.WriteLine($"Ошибка: '{strNumber2}' не является корректным числом.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Ошибка: '{strNumber2}' слишком велико или слишком мало для типа Int32.");
            }

            // Преобразование строки в число с помощью метода TryParse
            string strNumber3 = "789abc"; // некорректное число
            int tryParsedNumber;
            bool isParsed = int.TryParse(strNumber3, out tryParsedNumber);
            if (isParsed)
            {
                Console.WriteLine($"Преобразование строки '{strNumber3}' в число с помощью TryParse: {tryParsedNumber}");
            }
            else
            {
                Console.WriteLine($"Ошибка: '{strNumber3}' не удалось преобразовать в число.");
            }

            // Пример с корректным числом для TryParse
            string strNumber4 = "1000";
            isParsed = int.TryParse(strNumber4, out tryParsedNumber);
            if (isParsed)
            {
                Console.WriteLine($"Преобразование строки '{strNumber4}' в число с помощью TryParse: {tryParsedNumber}"); // 1000
            }
            else
            {
                Console.WriteLine($"Ошибка: '{strNumber4}' не удалось преобразовать в число.");
            }
        }

    }

    // Класс для представления веса в фунтах
    public class WeightPounds
    {
        public double Value;

        public WeightPounds(double value)
        {
            Value = value;
        }

        // Явное преобразование (Explicit) из фунтов в килограммы
        public static explicit operator WeightKilograms(WeightPounds wp)
        {
            return new WeightKilograms(wp.Value * 0.453592);
        }
    }

    // Класс для представления веса в килограммах
    public class WeightKilograms
    {
        public double Value;

        public WeightKilograms(double value)
        {
            Value = value;
        }

        // Неявное преобразование (Implicit) из килограммов в фунты
        public static implicit operator WeightPounds(WeightKilograms wk)
        {
            return new WeightPounds(wk.Value / 0.453592);
        }
    }


    class BaseClass { }

    class DerivedClass : BaseClass { }
}