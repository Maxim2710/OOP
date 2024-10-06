using System.Windows;
using System.Windows.Controls;
using Task2._4;

namespace MatrixMultiplicationModify
{
    public partial class MainWindow : Window
    {
        private Matrix matrix1;
        private Matrix matrix2;
        private Matrix result;
        private UIHandler uiHandler;

        public MainWindow()
        {
            InitializeComponent();
            uiHandler = new UIHandler();
            InitializeMatrixGrids();
        }

        private void InitializeMatrixGrids()
        {
            UpdateMatrix1Grid();
            UpdateMatrix2Grid();
        }

        private void UpdateMatrix1Grid()
        {
            if (matrix1Columns != null && matrix1Rows != null && grid1 != null)
            {
                int rows = matrix1Rows.SelectedIndex + 1;
                int columns = matrix1Columns.SelectedIndex + 1;

                matrix1 = new Matrix(rows, columns);
                uiHandler.InitializeGrid(grid1, columns, rows);
            }
        }

        private void UpdateMatrix2Grid()
        {
            if (matrix2Columns != null && matrix2Rows != null && grid2 != null)
            {
                int rows = matrix2Rows.SelectedIndex + 1;  // Изменено на matrix2Rows
                int columns = matrix2Columns.SelectedIndex + 1;

                matrix2 = new Matrix(rows, columns);
                uiHandler.InitializeGrid(grid2, columns, rows);
            }
        }

        private void Matrix1Dimensions_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateMatrix1Grid();
            UpdateMatrix2Grid();
        }

        private void Matrix2Dimensions_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateMatrix2Grid();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int m1rows = matrix1Rows.SelectedIndex + 1;
                int m1columns_m2rows = matrix1Columns.SelectedIndex + 1;
                int m2rows = matrix2Rows.SelectedIndex + 1;  // Изменено на matrix2Rows
                int m2columns = matrix2Columns.SelectedIndex + 1;

                matrix1 = new Matrix(m1rows, m1columns_m2rows);
                matrix2 = new Matrix(m2rows, m2columns);

                uiHandler.GetValuesFromGrid(grid1, matrix1);
                uiHandler.GetValuesFromGrid(grid2, matrix2);

                result = Matrix.Multiply(matrix1, matrix2);
                uiHandler.DisplayResult(grid3, result);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
