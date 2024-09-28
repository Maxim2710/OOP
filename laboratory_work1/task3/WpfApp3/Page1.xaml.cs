using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Frame _mainFrame;

        public Page1(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private static readonly Dictionary<int, char> HexDigits = new Dictionary<int, char>
        {
            { 0, '0' },
            { 1, '1' },
            { 2, '2' },
            { 3, '3' },
            { 4, '4' },
            { 5, '5' },
            { 6, '6' },
            { 7, '7' },
            { 8, '8' },
            { 9, '9' },
            { 10, 'A' },
            { 11, 'B' },
            { 12, 'C' },
            { 13, 'D' },
            { 14, 'E' },
            { 15, 'F' }
        };

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add logic for when text changes in the input TextBox if needed.
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate the input number
            if (!TryGetInputNumber(inputTextBox.Text, out int inputNumber))
            {
                MessageBox.Show("Please enter a valid non-negative integer.");
                return;
            }

            // Validate the target base
            if (!TryGetBase(endTextBox.Text, out int targetBase))
            {
                MessageBox.Show("Please enter a valid base (2-16).");
                return;
            }

            // Perform the conversion and display the result
            StringBuilder convertedResult = ConvertNumberToBase(inputNumber, targetBase);
            ResultLabel.Content = convertedResult.ToString();
        }

        private bool TryGetInputNumber(string input, out int number)
        {
            // Try to parse the input number and ensure it's non-negative
            return int.TryParse(input, out number) && number >= 0;
        }

        private bool TryGetBase(string input, out int baseValue)
        {
            // Try to parse the base and ensure it's within the valid range
            return int.TryParse(input, out baseValue) && baseValue >= 2 && baseValue <= 16;
        }

        private static StringBuilder ConvertNumberToBase(int number, int baseValue)
        {
            StringBuilder result = new StringBuilder();
            if (number == 0) return new StringBuilder("0"); // Handle zero case

            while (number > 0)
            {
                int remainder = number % baseValue;
                number /= baseValue;
                result.Insert(0, HexDigits[remainder]);
            }

            return result;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Optional: Add logic for when selection changes in a ListBox if needed.
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the next page
            _mainFrame.Navigate(new Page2(_mainFrame)); // Update with your actual next page
        }

        public void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back if possible
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }
    }
}
