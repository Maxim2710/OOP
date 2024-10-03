using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[,] matrix1;
        private double[,] matrix2;
        private double[,] result;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMatrixGrids();
        }

        // Инициализация начальных таблиц для матриц
        private void InitializeMatrixGrids()
        {
            UpdateMatrix1Grid();
            UpdateMatrix2Grid();
        }

        // Инициализация первой матрицы
        private void UpdateMatrix1Grid()
        {
            if (matrix1Columns != null && matrix1Rows != null)
            {
                // Теперь правильно: rows = выбранное количество строк, columns = выбранное количество столбцов
                int rows = matrix1Rows.SelectedIndex + 1;
                int columns = matrix1Columns.SelectedIndex + 1;

                matrix1 = new double[rows, columns]; // Строки, столбцы
                InitializeGrid(grid1, columns, rows); // Вызов с правильными параметрами
            }
        }

        // Инициализация второй матрицы
        private void UpdateMatrix2Grid()
        {
            if (matrix2Columns != null && matrix1Columns != null)
            {
                // Количество строк второй матрицы должно совпадать с количеством столбцов первой
                int rows = matrix1Columns.SelectedIndex + 1;
                int columns = matrix2Columns.SelectedIndex + 1;

                matrix2 = new double[rows, columns]; // Строки, столбцы
                InitializeGrid(grid2, columns, rows); // Вызов с правильными параметрами
            }
        }

        // Универсальный метод для создания таблицы с границами
        private void InitializeGrid(Grid grid, int columns, int rows)
        {
            if (grid == null)
                return;

            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();

            // Добавляем столбцы
            for (int x = 0; x < columns; x++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Добавляем строки
            for (int y = 0; y < rows; y++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }

            // Заполнение TextBox'ами внутри Border для отображения границ
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    // Создаем TextBox для ячейки
                    TextBox textBox = new TextBox
                    {
                        Text = "0", // Значение по умолчанию
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        TextAlignment = TextAlignment.Center
                    };

                    // Создаем границу вокруг TextBox
                    Border border = new Border
                    {
                        BorderThickness = new Thickness(1), // Толщина границ
                        BorderBrush = Brushes.Black, // Цвет границ
                        Child = textBox // Вставляем TextBox внутрь границы
                    };

                    // Устанавливаем позицию в сетке
                    border.SetValue(Grid.RowProperty, y);
                    border.SetValue(Grid.ColumnProperty, x);

                    // Добавляем границу (с TextBox внутри) в Grid
                    grid.Children.Add(border);
                }
            }
        }



        // Событие при изменении выбора количества строк или столбцов первой матрицы
        private void Matrix1Dimensions_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateMatrix1Grid();
            UpdateMatrix2Grid(); // Вторая матрица зависит от первой, поэтому нужно обновить и её
        }

        // Событие при изменении выбора количества столбцов второй матрицы
        private void Matrix2Dimensions_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateMatrix2Grid();
        }

        // Метод для получения значений из таблицы
        // Получение значений из сетки и обновление матрицы
        private void GetValuesFromGrid(Grid grid, double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    // Получаем Border из grid.Children
                    Border border = (Border)grid.Children[r * columns + c];
                    // Получаем TextBox, который находится внутри Border
                    TextBox t = (TextBox)border.Child;
                    // Считываем значение из TextBox и преобразуем его в double
                    matrix[r, c] = double.Parse(t.Text);
                }
            }
        }


        // Метод для расчета
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int m1rows = matrix1Rows.SelectedIndex + 1;
            int m1columns_m2rows = matrix1Columns.SelectedIndex + 1;
            int m2columns = matrix2Columns.SelectedIndex + 1;

            matrix1 = new double[m1rows, m1columns_m2rows]; // Строки, столбцы
            matrix2 = new double[m1columns_m2rows, m2columns]; // Строки, столбцы
            result = new double[m1rows, m2columns]; // Строки первой матрицы, столбцы второй

            GetValuesFromGrid(grid1, matrix1);
            GetValuesFromGrid(grid2, matrix2);

            // Умножение матриц
            for (int row = 0; row < m1rows; row++)
            {
                for (int column = 0; column < m2columns; column++)
                {
                    double accumulator = 0;
                    for (int cell = 0; cell < m1columns_m2rows; cell++)
                    {
                        accumulator += matrix1[row, cell] * matrix2[cell, column];
                    }
                    result[row, column] = accumulator;
                }
            }

            // Отображение результата
            InitializeGrid(grid3, m2columns, m1rows);
            for (int r = 0; r < m1rows; r++)
            {
                for (int c = 0; c < m2columns; c++)
                {
                    // Получаем Border из grid3.Children
                    Border border = (Border)grid3.Children[r * m2columns + c];
                    // Получаем TextBox, который находится внутри Border
                    TextBox t = (TextBox)border.Child;
                    // Присваиваем результат вычисления
                    t.Text = result[r, c].ToString();
                }
            }
        }
    }
}