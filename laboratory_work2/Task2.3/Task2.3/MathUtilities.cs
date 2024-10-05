using System;
using System.Text;

namespace Task2._3
{
    public static class MathUtilities
    {
        // Находим самое большое простое число меньше N
        public static int FindLargestPrimeLessThan(int n)
        {
            for (int i = n - 1; i >= 2; i--)
            {
                if (IsPrime(i))
                {
                    return i;
                }
            }
            return 2; // Возвращаем 2, если простое число не найдено (не должно произойти для n > 2)
        }

        // Проверка числа на простоту
        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Представление простого числа как суммы степеней двойки с побитовыми сдвигами
        public static string RepresentAsPowerOfTwo(int number)
        {
            StringBuilder representation = new StringBuilder();
            int shift = 0;

            while (number > 0)
            {
                // Проверяем, есть ли на текущей позиции бит 1
                if ((number & 1) == 1)
                {
                    // Добавляем представление текущей степени двойки через побитовый сдвиг
                    if (shift == 0)
                    {
                        representation.Append("(2 >> 1)");  // Представление 2^0 как 2 >> 1
                    }
                    else
                    {
                        if (representation.Length > 0)
                        {
                            representation.Append(" + ");
                        }
                        representation.Append($"(2 << {shift - 1})");  // Представление 2^shift как 2 << (shift-1)
                    }
                }
                number >>= 1;  // Сдвигаем число вправо для анализа следующего бита
                shift++;
            }

            return representation.ToString();
        }
    }
}
