using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2
{
    public static class GCDAlgorithms
    {
        public static int FindGCDEuclid(int a, int b)
        {
            if (a == 0) return b;
            while (b != 0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        public static int FindGCDEuclid(int a, int b, int c)
        {
            int d = FindGCDEuclid(a, b);
            return FindGCDEuclid(d, c);
        }

        public static int FindGCDEuclid(int a, int b, int c, int d)
        {
            int e = FindGCDEuclid(a, b, c);
            return FindGCDEuclid(e, d);
        }

        public static int FindGCDEuclid(int a, int b, int c, int d, int e)
        {
            int f = FindGCDEuclid(a, b, c, d);
            return FindGCDEuclid(f, e);
        }

        // Перегрузка с params для обработки неопределённого числа параметров
        public static int FindGCDEuclid(params int[] numbers)
        {
            if (numbers.Length == 0) throw new ArgumentException("Необходимо передать хотя бы одно число");

            int gcd = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                gcd = FindGCDEuclid(gcd, numbers[i]);
            }
            return gcd;
        }
    }

}
