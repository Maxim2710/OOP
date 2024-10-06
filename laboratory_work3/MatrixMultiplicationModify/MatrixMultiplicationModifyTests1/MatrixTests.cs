using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatrixMultiplicationModify
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MatrixMultiplyTest1()
        {
            // Создание входных матриц
            Matrix matrix1 = new Matrix(2, 2);
            matrix1.SetValue(0, 0, 1);
            matrix1.SetValue(0, 1, 2);
            matrix1.SetValue(1, 0, 3);
            matrix1.SetValue(1, 1, 4);

            Matrix matrix2 = new Matrix(2, 2);
            matrix2.SetValue(0, 0, 5);
            matrix2.SetValue(0, 1, 6);
            matrix2.SetValue(1, 0, 7);
            matrix2.SetValue(1, 1, 8);

            // Ожидаемая матрица результата
            Matrix expected = new Matrix(2, 2);
            expected.SetValue(0, 0, 19); // (1*5 + 2*7)
            expected.SetValue(0, 1, 22); // (1*6 + 2*8)
            expected.SetValue(1, 0, 43); // (3*5 + 4*7)
            expected.SetValue(1, 1, 50); // (3*6 + 4*8)

            // Фактический результат
            Matrix actual = Matrix.Multiply(matrix1, matrix2);

            // Проверка ожидаемого результата с фактическим
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    Assert.AreEqual(expected.GetValue(row, column), actual.GetValue(row, column), $"Mismatch at position [{row}, {column}]");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixMultiplyTest2()
        {
            // Создание первой матрицы
            Matrix matrix1 = new Matrix(2, 2);
            matrix1.SetValue(0, 0, 1);
            matrix1.SetValue(0, 1, 2);
            matrix1.SetValue(1, 0, 3);
            matrix1.SetValue(1, 1, 4);

            // Создание второй матрицы с отрицательным значением
            Matrix matrix2 = new Matrix(2, 2);
            matrix2.SetValue(0, 0, 5);
            matrix2.SetValue(0, 1, -6); // Неправильное значение
            matrix2.SetValue(1, 0, 7);
            matrix2.SetValue(1, 1, 8);

            // Этот вызов должен вызвать исключение ArgumentException
            Matrix result = Matrix.Multiply(matrix1, matrix2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixMultiplyTest3()
        {
            // Создание несовместимых матриц
            Matrix matrix1 = new Matrix(2, 3); // 2 строки и 3 столбца
            matrix1.SetValue(0, 0, 1);
            matrix1.SetValue(0, 1, 2);
            matrix1.SetValue(0, 2, 3);
            matrix1.SetValue(1, 0, 4);
            matrix1.SetValue(1, 1, 5);
            matrix1.SetValue(1, 2, 6);

            Matrix matrix2 = new Matrix(2, 2); // 2 строки и 2 столбца
            matrix2.SetValue(0, 0, 7);
            matrix2.SetValue(0, 1, 8);
            matrix2.SetValue(1, 0, 9);
            matrix2.SetValue(1, 1, 10);

            // Этот вызов должен вызвать исключение ArgumentException из-за несовместимых размеров
            Matrix result = Matrix.Multiply(matrix1, matrix2);
        }
    }
}
