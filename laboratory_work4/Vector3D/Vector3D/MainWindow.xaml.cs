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

namespace Vector3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double EarthAngularVelocity = 7.2921e-5; // Угловая скорость Земли в рад/с

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateCoriolisForce_Click(object sender, RoutedEventArgs e)
        {
            // Переменные для хранения данных
            double weight, velocityX, velocityY, velocityZ;

            // Парсинг значений с использованием TryParse
            bool isWeightValid = double.TryParse(WeightTextBox.Text, out weight);
            bool isVelocityXValid = double.TryParse(VelocityXTextBox.Text, out velocityX);
            bool isVelocityYValid = double.TryParse(VelocityYTextBox.Text, out velocityY);
            bool isVelocityZValid = double.TryParse(VelocityZTextBox.Text, out velocityZ);

            if (isWeightValid && isVelocityXValid && isVelocityYValid && isVelocityZValid)
            {
                // Вектор скорости студента
                Vector3DClass velocity = new Vector3DClass(velocityX, velocityY, velocityZ);
                // Вектор угловой скорости Земли (по оси Z)
                Vector3DClass angularVelocity = new Vector3DClass(0, 0, EarthAngularVelocity);

                // Вычисление векторного произведения
                Vector3DClass coriolisVector = Vector3DClass.CrossProduct(velocity, angularVelocity);
                // Расчет силы Кориолиса
                Vector3DClass coriolisForce = 2 * weight * coriolisVector;

                // Формируем вывод
                string output = $"Вводимые данные:\n";
                output += $"Вес студента: {weight} кг\n";
                output += $"Вектор скорости: {velocity}\n";
                output += $"Вектор угловой скорости: {angularVelocity}\n\n";

                // Вычисление векторного произведения
                output += $"Шаг 1: Вычисляем векторное произведение:\n";
                output += $"v × Ω = ({velocity.X}, {velocity.Y}, {velocity.Z}) × (0, 0, {EarthAngularVelocity})\n";
                output += $"= (-{velocity.Y} * {EarthAngularVelocity}, 0, 0)\n";
                output += $"= {coriolisVector}\n\n";

                // Расчет силы Кориолиса
                output += $"Шаг 2: Вычисляем силу Кориолиса:\n";
                output += $"F_c = 2 * {weight} * {coriolisVector}\n";
                output += $"= 2 * {weight} * {coriolisVector.X} i\n";
                output += $"= {coriolisForce} Н\n";

                // Выводим результат
                ResultTextBlock.Text = output;
            }
            else
            {
                // Ошибка ввода
                ResultTextBlock.Text = "Ошибка ввода! Проверьте, что все значения корректны.";
            }
        }
    }
}