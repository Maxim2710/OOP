using System;
using System.Security.Cryptography;
using System.Text;

namespace HashingProject
{
    class Program
    {
        static void Main()
        {
            // Ваша строка ФИО с пробелами вместо запятых
            string fullName = "Примак Максим Вячеславович";

            // Хэширование MD5
            string md5Hash = ComputeHash(fullName, new MD5CryptoServiceProvider());
            Console.WriteLine($"MD5 Hash: {md5Hash}");

            // Хэширование SHA256
            string sha256Hash = ComputeHash(fullName, new SHA256CryptoServiceProvider());
            Console.WriteLine($"SHA256 Hash: {sha256Hash}");
        }

        // Метод для вычисления хэша
        static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            // Преобразование строки в массив байтов с использованием кодировки UTF-8
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Вычисление хэша
            byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            // Преобразование хэша из байтов в строку шестнадцатеричных символов
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // Преобразование байта в шестнадцатеричный формат
            }
            return sb.ToString();
        }
    }
}
