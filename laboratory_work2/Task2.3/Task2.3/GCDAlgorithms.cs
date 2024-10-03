using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    public class GCDAlgorithms
    {
        public static int FindGCDEuclid(int a, int b, out long time)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (a == 0)
            {
                time = sw.ElapsedTicks;
                return b;
            }
            while (b != 0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            time = sw.ElapsedTicks;
            return a;
        }

        public static int FindGCDStein(int u, int v, out long time)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int k;
            if (u == 0 || v == 0)
            {
                time = sw.ElapsedTicks;
                return u | v; // возвращает ненулевое значение
            }

            // Оба четные
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
                u >>= 1;

            do
            {
                while ((v & 1) == 0)
                    v >>= 1;

                if (u < v)
                    v -= u;
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;
            } while (v != 0);

            u <<= k; // возвращаем результат
            time = sw.ElapsedTicks;
            return u;
        }
    }
}
