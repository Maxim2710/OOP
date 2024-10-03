using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    public static class MathUtilities
    {
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
    }
}
