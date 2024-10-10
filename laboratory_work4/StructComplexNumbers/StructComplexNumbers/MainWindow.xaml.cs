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

namespace StructComplexNumbers
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

        // Обработчик кнопки "Сложить"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((z1, z2) => z1 + z2, "Сложение");
        }

        // Обработчик кнопки "Вычесть"
        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((z1, z2) => z1 - z2, "Вычитание");
        }

        // Обработчик кнопки "Умножить"
        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((z1, z2) => z1 * z2, "Умножение");
        }

        // Обработчик кнопки "Разделить"
        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation((z1, z2) => z1 / z2, "Деление");
        }

        // Универсальный метод для выполнения операции
        private void PerformOperation(Func<ComplexNumber, ComplexNumber, ComplexNumber> operation, string operationName)
        {
            try
            {
                // Чтение комплексных чисел из текстовых полей
                double real1 = double.Parse(Real1TextBox.Text);
                double imaginary1 = double.Parse(Imaginary1TextBox.Text);
                double real2 = double.Parse(Real2TextBox.Text);
                double imaginary2 = double.Parse(Imaginary2TextBox.Text);

                // Создание комплексных чисел
                ComplexNumber z1 = new ComplexNumber(real1, imaginary1);
                ComplexNumber z2 = new ComplexNumber(real2, imaginary2);

                // Выполнение операции
                ComplexNumber result = operation(z1, z2);
                ResultTextBlock.Text = $"{operationName}: {result}";

                // Преобразование в экспоненциальную форму
                var (magnitude, argument) = ComplexOperations.ToExponentialForm(result);
                ResultTextBlock.Text += $"\nЭкспоненциальная форма: {magnitude} * e^({argument}i)";

                // Обратное преобразование
                ComplexNumber original = ComplexOperations.FromExponentialForm(magnitude, argument);
                ResultTextBlock.Text += $"\nОбратное преобразование: {original}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ошибка: Деление на ноль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}