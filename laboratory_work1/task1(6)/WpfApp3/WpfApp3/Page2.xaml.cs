using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Frame _mainFrame;

        public Page2(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private static readonly Dictionary<string, int> NumberTypes = new Dictionary<string, int>
        {
            { "Арабские цифры", 0 },
            { "Римские цифры", 1 },
        };

        private string _currentFromType = "Арабские цифры";
        private string _currentToType = "Римские цифры";

        private readonly Dictionary<int, string> _romanNumerals = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        private readonly Dictionary<string, int> _romanToArabicMap = new Dictionary<string, int>
        {
            { "CM", 900 },
            { "M", 1000 },
            { "CD", 400 },
            { "D", 500 },
            { "XC", 90 },
            { "C", 100 },
            { "XL", 40 },
            { "L", 50 },
            { "IX", 9 },
            { "X", 10 },
            { "IV", 4 },
            { "V", 5 },
            { "I", 1 }
        };

        private void NavigateToPage1_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Page1(_mainFrame));
        }

        private void FromTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                _currentFromType = selectedItem.Content.ToString();
            }
        }

        private void ToTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                _currentToType = selectedItem.Content.ToString();
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Implement logic for when the text changes in the input TextBox.
        }

        private string ConvertFromArabicToRoman(int number)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in _romanNumerals)
            {
                int arabicValue = item.Key;
                string romanSymbol = item.Value;
                int count = number / arabicValue;
                number %= arabicValue;

                for (int i = 0; i < count; i++)
                {
                    result.Append(romanSymbol);
                }
            }
            return result.ToString();
        }

        private string ConvertFromRomanToArabic(string romanNumeral)
        {
            int result = 0;

            foreach (var item in _romanToArabicMap)
            {
                int arabicValue = item.Value;
                string romanSymbol = item.Key;
                romanNumeral = romanNumeral.Replace(romanSymbol, "!");

                foreach (var character in romanNumeral)
                {
                    if (character == '!')
                    {
                        if (romanNumeral.Substring(0, 1) != "!")
                        {
                            return "";
                        }
                        result += arabicValue;
                    }
                }
                romanNumeral = romanNumeral.Replace("!", "");
            }

            return romanNumeral.Length == 0 ? result.ToString() : "";
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputValue = inputTB.Text;

            if (NumberTypes[_currentFromType] == 0) // Arabic to Roman
            {
                if (!int.TryParse(inputValue, out int arabicNumber) || arabicNumber < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative integer.");
                    return;
                }

                string romanResult = ConvertFromArabicToRoman(arabicNumber);
                OutputLabel.Content = romanResult;
            }
            else // Roman to Arabic
            {
                inputValue = inputValue.ToUpper();
                string arabicResult = ConvertFromRomanToArabic(inputValue);

                if (string.IsNullOrEmpty(arabicResult))
                {
                    MessageBox.Show("Invalid format for Roman numerals.");
                }
                else
                {
                    OutputLabel.Content = arabicResult;
                }
            }
        }
    }
}
