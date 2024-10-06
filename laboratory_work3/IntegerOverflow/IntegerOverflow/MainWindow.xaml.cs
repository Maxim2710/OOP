using System;
using System.Windows;

namespace IntegerOverflow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoMultiply_Click(object sender, RoutedEventArgs e)
        {
            // Переменные для хранения чисел
            int number1, number2;

            // Проверка корректности ввода для первого числа
            if (!int.TryParse(FirstNumberTextBox.Text, out number1))
            {
                MessageBox.Show("Пожалуйста, введите корректное целое число в первое поле.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка корректности ввода для второго числа
            if (!int.TryParse(SecondNumberTextBox.Text, out number2))
            {
                MessageBox.Show("Пожалуйста, введите корректное целое число во второе поле.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Используем checked для отслеживания переполнения
                checked
                {
                    int result = number1 * number2;
                    ResultTextBlock.Text = $"Результат: {result}";
                }
            }
            catch (OverflowException)
            {
                // Обрабатываем переполнение
                MessageBox.Show("Произошло переполнение при умножении!", "Ошибка переполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                ResultTextBlock.Text = "Обнаружено переполнение!";
            }
        }
    }
}
