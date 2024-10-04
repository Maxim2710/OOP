using System;

namespace Task1Hard2
{
    public class Calculator
    {
        // Грубая оценка из примера
        public double CalculateExampleApproximation(double y)
        {
            int D = 0;

            if (y > 1)
            {
                D = (int)Math.Floor(Math.Log10(y)) + 1; // число цифр слева от запятой
            }
            else if (y < 1)
            {
                D = -CountLeadingZeros(y); // число нулей справа от запятой (со знаком минус)
            }

            int n = (D % 2 == 0) ? (D / 2 - 1) : (D - 1) / 2;

            if (D % 2 == 0)
            {
                return 6 * Math.Pow(10, n);
            }
            else
            {
                return 2 * Math.Pow(10, n);
            }
        }

        // Подсчет числа ведущих нулей для y < 1
        private int CountLeadingZeros(double y)
        {
            int count = 0;
            while (y < 1)
            {
                y *= 10;
                count++;
            }
            return count;
        }
    }
}
