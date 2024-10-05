using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    public static class EuclideanAlgorithm
    {
        public static int FindGCD(int a, int b)
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
    }
}
