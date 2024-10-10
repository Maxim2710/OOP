using System;

namespace StructComplexNumbers
{
    // Структура комплексного числа
    public readonly struct ComplexNumber
    {
        public double Real { get; init; }
        public double Imaginary { get; init; }

        // Конструктор
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // task 2

        // Модуль числа |z| = sqrt(a^2 + b^2)
        public readonly double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        // Аргумент числа (угол) theta = atan2(b, a)
        public readonly double Argument => Math.Atan2(Imaginary, Real);

        // task3

        // Операторы сложения
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
            => new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);

        // Операторы вычитания
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
            => new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);

        // Операторы умножения (формула: (a + bi) * (c + di) = (ac - bd) + (ad + bc)i)
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
            => new ComplexNumber(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                                 c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);

        // Оператор деления
        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            double denom = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
            return new ComplexNumber((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denom,
                                     (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denom);
        }

        // task 4

        // Оператор сравнения ==
        public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
            => c1.Real == c2.Real && c1.Imaginary == c2.Imaginary;

        // Оператор сравнения !=
        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
            => !(c1 == c2);

        // Переопределение Equals и GetHashCode
        public override bool Equals(object? obj)
            => obj is ComplexNumber other && this == other;

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);


        // task 5

        // Перегрузка ToString
        public override string ToString()
            => $"{Real} {(Imaginary >= 0 ? "+" : "-")} {Math.Abs(Imaginary)}i";
    }
}
