using MeasuringDevice;
using System;
using System.Windows;

namespace Exercise2TestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMeasuringDevice device; // Устройство измерения

        private EventHandler newMeasurementTaken; // Делегат для события нового измерения

        public MainWindow()
        {
            InitializeComponent();
            UpdateButtonStates();
        }

        // Создание экземпляра MeasureLengthDevice или MeasureMassDevice
        private void createInstance_Click(object sender, RoutedEventArgs e)
        {
            // Определяем, какие единицы измерения использовать: имперические или метрические
            Units selectedUnits = ImperialRadioButton.IsChecked == true ? Units.Imperial : Units.Metric;

            // Создаем устройство в зависимости от выбора (длина или масса)
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

        // Обновление состояния кнопок в зависимости от выбора единиц измерения
        private void UpdateButtonStates()
        {
            if (device != null)
            {
                // Если выбраны имперские единицы, активируем кнопку получения имперического значения, и наоборот
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
                // Если устройство не создано, блокируем обе кнопки
                if (GetImperialValueButton != null)
                    GetImperialValueButton.IsEnabled = false;
                if (GetMetricValueButton != null)
                    GetMetricValueButton.IsEnabled = false;
            }
        }

        private void startCollecting_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                // Инициализация делегата, который будет вызывать обработчик события при каждом новом измерении
                newMeasurementTaken = new EventHandler(device_NewMeasurementTaken);

                // Привязка делегата к событию NewMeasurementTaken устройства
                device.NewMeasurementTaken += newMeasurementTaken;

                // Привязка обработчика события HeartBeat с использованием лямбда-выражения
                device.HeartBeat += (o, args) =>
                {
                    heartBeatTimeStamp.Text = $"HeartBeat Timestamp: {args.TimeStamp}"; // Обновление метки
                };

                // Запуск процесса сбора измерений
                device.StartCollecting();
                ResultTextBlock.Text = "Started collecting data.";
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
                // Остановка процесса сбора данных
                device.StopCollecting();
                ResultTextBlock.Text = "Stopped collecting data.";

                // Отключение обработчика события
                if (newMeasurementTaken != null)
                {
                    device.NewMeasurementTaken -= newMeasurementTaken;
                }
            }
            else
            {
                ResultTextBlock.Text = "Please create a device instance first.";
            }
        }

        private void disposeButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, существует ли устройство
            if (device != null)
            {
                // Освобождаем ресурсы устройства
                device.Dispose();
                device = null; // Обнуляем ссылку на устройство

                ResultTextBlock.Text = "Device disposed.";

                // Дополнительно: сбрасываем метку времени HeartBeat
                heartBeatTimeStamp.Text = "HeartBeat stopped.";
            }
            else
            {
                ResultTextBlock.Text = "No device to dispose.";
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

        // Обработчик события нового измерения
        private void device_NewMeasurementTaken(object sender, EventArgs e)
        {
            if (device != null)
            {
                // Обновляем текстовые поля с последним измерением, метрическим и империческим значением
                mostRecentMeasureBox.Text = device.MostRecentMeasure.ToString();
                metricValueBox.Text = device.MetricValue().ToString();
                imperialValueBox.Text = device.ImperialValue().ToString();

                // Сбрасываем источник данных для обновления привязки списка
                rawDataValues.ItemsSource = null;

                // Обновляем источник данных сырыми значениями
                rawDataValues.ItemsSource = device.GetRawData();
            }
        }

        // Обработчик изменений состояния радиокнопок
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateButtonStates(); // Обновляем доступность кнопок при изменении выбора радиокнопок
        }
    }
}
