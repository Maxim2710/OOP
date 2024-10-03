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
                int gcd = GCDAlgorithms.FindGCDEuclid(num1, num2);
                resultEuclid.Content = $"Euclid: {gcd}";
            }
            catch (FormatException)
            {
                resultEuclid.Content = "Please enter valid integers.";
            }
        }
    }

    public static class GCDAlgorithms
    {
        public static int FindGCDEuclid(int a, int b)
        {
            if (a == 0) return b;
            while (b != 0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
    }
}