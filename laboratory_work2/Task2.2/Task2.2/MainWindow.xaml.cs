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

namespace Task2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindGCD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Разделение строки на числа
                int[] numbers = inputNumbers.Text.Split(',').Select(int.Parse).ToArray();

                // Нахождение GCD
                int gcd = GCDAlgorithms.FindGCDEuclid(numbers);

                // Отображение результата
                resultGCD.Content = $"GCD: {gcd}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}