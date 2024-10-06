using System;

namespace MatrixMultiplicationModify
{
    public class Matrix
    {
        public double[,] Data { get; private set; }

        public Matrix(int rows, int columns)
        {
            Data = new double[rows, columns];
        }

        public void SetValue(int row, int column, double value)
        {
            Data[row, column] = value;
        }

        public double GetValue(int row, int column)
        {
            return Data[row, column];
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            int m1rows = matrix1.Data.GetLength(0);
            int m1columns_m2rows = matrix1.Data.GetLength(1);
            int m2columns = matrix2.Data.GetLength(1);

            // Проверка на совместимость
            if (m1columns_m2rows != matrix2.Data.GetLength(0))
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы.");
            }

            Matrix result = new Matrix(m1rows, m2columns);

            for (int row = 0; row < m1rows; row++)
            {
                for (int column = 0; column < m2columns; column++)
                {
                    double accumulator = 0;
                    for (int cell = 0; cell < m1columns_m2rows; cell++)
                    {
                        // Проверка значений первой матрицы
                        if (matrix1.GetValue(row, cell) < 0)
                        {
                            throw new ArgumentException($"Matrix1 содержит недопустимое значение в ячейке [{cell}, {row}].");
                        }

                        // Проверка значений второй матрицы
                        if (matrix2.GetValue(cell, column) < 0)
                        {
                            throw new ArgumentException($"Matrix2 содержит недопустимое значение в ячейке [{column}, {cell}].");
                        }

                        accumulator += matrix1.GetValue(row, cell) * matrix2.GetValue(cell, column);
                    }
                    result.SetValue(row, column, accumulator);
                }
            }

            return result;
        }
    }
}
