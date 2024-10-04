using System;
using System.Windows;

namespace Task1Hard2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator _calculator;

        public MainWindow()
        {
            InitializeComponent();
            _calculator = new Calculator(); // Инициализация калькулятора
        }

        // Обработчик нажатия на кнопку
        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double y))
            {
                // Вычисление грубой оценки
                double exampleResult = _calculator.CalculateExampleApproximation(y);

                // Вывод результата в интерфейсе
                ResultLabel.Content = exampleResult.ToString();
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }
    }
}
