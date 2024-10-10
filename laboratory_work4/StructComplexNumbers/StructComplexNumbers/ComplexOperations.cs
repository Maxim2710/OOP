using System;

namespace StructComplexNumbers
{
    // Класс для работы с экспоненциальной формой
    public static class ComplexOperations
    {
        // Преобразование в экспоненциальную форму
        public static (double, double) ToExponentialForm(ComplexNumber complex)
            => (complex.Magnitude, complex.Argument);

        // Преобразование из экспоненциальной формы обратно
        public static ComplexNumber FromExponentialForm(double magnitude, double argument)
            => new ComplexNumber(magnitude * Math.Cos(argument), magnitude * Math.Sin(argument));
    }
}
