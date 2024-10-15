using MeasuringDevice;
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

namespace Exercise2TestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMeasuringDevice device;

        public MainWindow()
        {
            InitializeComponent();
            UpdateButtonStates();
        }

        // Создание экземпляра MeasureLengthDevice
        private void createInstance_Click(object sender, RoutedEventArgs e)
        {
            Units selectedUnits = ImperialRadioButton.IsChecked == true ? Units.Imperial : Units.Metric;
            if (MassRadioButton.IsChecked == true)
            {
                device = new MeasureMassDevice(selectedUnits);
            }
            else
            {
                device = new MeasureLengthDevice(selectedUnits);
            }

            ResultTextBlock.Text = $"Device created with {selectedUnits} units.";
            UpdateButtonStates(); // Обновляем доступность кнопок
        }

        // Обновление состояния кнопок в зависимости от выбранных единиц
        private void UpdateButtonStates()
        {
            if (device != null)
            {
                if (ImperialRadioButton.IsChecked == true)
                {
                    if (GetImperialValueButton != null)
                        GetImperialValueButton.IsEnabled = true; // Разрешаем получение имперического значения
                    if (GetMetricValueButton != null)
                        GetMetricValueButton.IsEnabled = false;  // Запрещаем получение метрического значения
                }
                else
                {
                    if (GetImperialValueButton != null)
                        GetImperialValueButton.IsEnabled = false; // Запрещаем получение имперического значения
                    if (GetMetricValueButton != null)
                        GetMetricValueButton.IsEnabled = true;    // Разрешаем получение метрического значения
                }
            }
            else
            {
                if (GetImperialValueButton != null)
                    GetImperialValueButton.IsEnabled = false; // Запрещаем получение значений, если устройство не создано
                if (GetMetricValueButton != null)
                    GetMetricValueButton.IsEnabled = false;
            }
        }


        // Запуск сбора данных
        private void StartCollecting_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                device.StartCollecting();
                ResultTextBlock.Text = "Started collecting data...";
            }
            else
            {
                ResultTextBlock.Text = "Please create a device instance first.";
            }
        }

        // Остановка сбора данных
        private void StopCollecting_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                device.StopCollecting();
                ResultTextBlock.Text = "Stopped collecting data.";
            }
            else
            {
                ResultTextBlock.Text = "Please create a device instance first.";
            }
        }

        // Получение сырых данных
        private void GetRawData_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                int[] rawData = device.GetRawData();
                ResultTextBlock.Text = "Raw Data: " + string.Join(", ", rawData);
            }
            else
            {
                ResultTextBlock.Text = "Please create a device instance first.";
            }
        }

        // Получение значения в метрических единицах
        private void GetMetricValue_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                decimal metricValue = device.MetricValue();
                ResultTextBlock.Text = $"Metric Value: {metricValue}";
            }
            else
            {
                ResultTextBlock.Text = "Please create a device instance first.";
            }
        }

        // Получение значения в имперских единицах
        private void GetImperialValue_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                decimal imperialValue = device.ImperialValue();
                ResultTextBlock.Text = $"Imperial Value: {imperialValue}";
            }
            else
            {
                ResultTextBlock.Text = "Please create a device instance first.";
            }
        }

        // Обработчик изменений состояния радиокнопок
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateButtonStates(); // Обновляем доступность кнопок при изменении выбора радиокнопок
        }
    }
}