using MeasuringDevice;
using System.Windows;

namespace Exercise2TestHarness
{
    public partial class MainWindow : Window
    {
        private IMeasuringDevice device;

        public MainWindow()
        {
            InitializeComponent();

            // По умолчанию империческая система, поэтому кнопка для получения метрических данных отключена
            GetMetricValueButton.IsEnabled = false;
            GetImperialValueButton.IsEnabled = true;
        }


        // Создание экземпляра MeasureLengthDevice
        private void createInstance_Click(object sender, RoutedEventArgs e)
        {
            // Определение, какие единицы измерения выбраны
            Units selectedUnits = ImperialRadioButton.IsChecked == true ? Units.Imperial : Units.Metric;

            // Создание экземпляра устройства измерения длины
            device = new MeasureLengthDevice(selectedUnits);

            // Вывод информации об успешном создании экземпляра
            ResultTextBlock.Text = $"Device created with {selectedUnits} units.";
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

        // Обработчики радиокнопок для управления доступностью кнопок
        private void ImperialRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Проверяем, что кнопки инициализированы
            if (GetMetricValueButton != null && GetImperialValueButton != null)
            {
                GetMetricValueButton.IsEnabled = false;
                GetImperialValueButton.IsEnabled = true;
            }
        }

        private void MetricRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Проверяем, что кнопки инициализированы
            if (GetMetricValueButton != null && GetImperialValueButton != null)
            {
                GetMetricValueButton.IsEnabled = true;
                GetImperialValueButton.IsEnabled = false;
            }
        }


    }
}
