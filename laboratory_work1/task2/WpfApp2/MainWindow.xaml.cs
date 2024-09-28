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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Переменные для хранения значений
        private static decimal initialGuess = 0;
        private static decimal decimalNumber = 0;
        private static double doubleNumber = 0;
        private static int iterationCount = 0;
        private static bool hasCalculated = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (hasCalculated)
            {
                outputLabel.Content = "";
            }
            iterationCount = 0;

            // Вычисляем квадратный корень стандартным методом
            double standardSquareRoot = Math.Sqrt(doubleNumber);
            frameworkLabel.Content = string.Format("{0}", standardSquareRoot);

            // Вычисляем квадратный корень методом Ньютона
            decimal newtonSquareRoot = CalculateSquareRoot(decimalNumber, initialGuess, false);
            newtonLabel.Content = string.Format("{0}", newtonSquareRoot);
            iterationCount = 0;
            hasCalculated = true;
        }

        private void NextIterationButton_Click(object sender, RoutedEventArgs e)
        {
            if (iterationCount == 0)
            {
                outputLabel.Content = "";
            }
            if (string.IsNullOrEmpty(frameworkLabel.Content.ToString()))
            {
                double standardSquareRoot = Math.Sqrt(doubleNumber);
                frameworkLabel.Content = string.Format("{0}", standardSquareRoot);
            }

            decimal newtonSquareRoot = CalculateSquareRoot(decimalNumber, initialGuess, true);
            if (newtonSquareRoot != -1)
            {
                newtonLabel.Content = string.Format("{0}", initialGuess);
                iterationCount = 0;
                hasCalculated = true;
            }
        }

        private decimal CalculateSquareRoot(decimal number, decimal guess, bool isIteration)
        {
            decimal tolerance = Convert.ToDecimal(Math.Pow(10, -28));
            decimal result = ((number / guess) + guess) / 2;

            while (Math.Abs(result - guess) > tolerance)
            {
                outputLabel.Content += string.Format("Итерация: {0}\nПогрешность: {1}\nЗначение корня: {2}\n\n", iterationCount, Math.Abs(result - guess), result);

                if (isIteration)
                {
                    guess = result;
                    iterationCount++;
                    initialGuess = guess;
                    return -1; // Возвращаем -1 для указания на необходимость продолжения
                }

                guess = result;
                result = ((number / guess) + guess) / 2;
                iterationCount++;
            }

            if (iterationCount == 0)
            {
                outputLabel.Content += string.Format("Итерация: {0}\nПогрешность: {1}\nЗначение корня: {2}\n\n", iterationCount, Math.Abs(result - guess), result);
            }
            return result;
        }

        private void InputGuessTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(inputGuessTextBox.Text.Replace(".", ","), out decimal guessValue) && guessValue > 0)
            {
                initialGuess = guessValue;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите положительное число.");
            }
        }

        private void InputNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(inputNumberTextBox.Text.Replace(".", ","), out decimal numberValue) && numberValue > 0)
            {
                decimalNumber = numberValue;
                doubleNumber = (double)numberValue;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите положительное число.");
            }
        }
    }
}