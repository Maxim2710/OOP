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

namespace Task2._1
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
                int num1 = int.Parse(firstNumber.Text);
                int num2 = int.Parse(secondNumber.Text);
                int gcd = EuclideanAlgorithm.FindGCD(num1, num2); // Изменено
                resultEuclid.Content = $"Euclid: {gcd}";
            }
            catch (FormatException)
            {
                resultEuclid.Content = "Please enter valid integers.";
            }
        }
    }
}