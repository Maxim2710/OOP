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

namespace Task2._3
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
            int u = int.Parse(firstNumber.Text);
            int v = int.Parse(secondNumber.Text);

            long timeEuclid, timeStein;

            int gcdEuclid = GCDAlgorithms.FindGCDEuclid(u, v, out timeEuclid);
            int gcdStein = GCDAlgorithms.FindGCDStein(u, v, out timeStein);

            resultEuclid.Content = $"[Euclid] GCD: {gcdEuclid}, Time (ticks): {timeEuclid}";
            resultStein.Content = $"[Stein] GCD: {gcdStein}, Time (ticks): {timeStein}";
        }

        private void FindLargestPrime_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(numberInput.Text, out int n) && n > 2)
            {
                int largestPrime = MathUtilities.FindLargestPrimeLessThan(n);
                resultLabel.Content = $"Largest Prime < {n}: {largestPrime} (2^{(int)Math.Log2(largestPrime)})";
            }
            else
            {
                MessageBox.Show("Please enter a valid integer greater than 2.");
            }
        }
    }
}