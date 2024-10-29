using System;
using System.Windows;

namespace FailsafeSystem
{
    public partial class MainWindow : Window
    {
        private Switch _switch;

        public MainWindow()
        {
            InitializeComponent();
            _switch = new Switch();
        }

        private void ShutdownSystem(object sender, RoutedEventArgs e)
        {
            try
            {
                // Шаг 1: Отключение от генератора
                _switch.DisconnectPowerGenerator();
            }
            catch (PowerGeneratorCommsException ex)
            {
                LogMessage($"Ошибка связи с генератором: {ex.Message}");
            }

            try
            {
                // Шаг 2: Проверка основной системы охлаждения
                _switch.VerifyPrimaryCoolantSystem();
            }
            catch (CoolantTemperatureReadException ex)
            {
                LogMessage($"Ошибка чтения температуры в основной системе охлаждения: {ex.Message}");
            }
            catch (CoolantPressureReadException ex)
            {
                LogMessage($"Ошибка чтения давления в основной системе охлаждения: {ex.Message}");
            }

            try
            {
                // Шаг 3: Проверка резервной системы охлаждения
                _switch.VerifyBackupCoolantSystem();
            }
            catch (CoolantTemperatureReadException ex)
            {
                LogMessage($"Ошибка чтения температуры в резервной системе охлаждения: {ex.Message}");
            }
            catch (CoolantPressureReadException ex)
            {
                LogMessage($"Ошибка чтения давления в резервной системе охлаждения: {ex.Message}");
            }

            try
            {
                // Шаг 4: Чтение температуры ядра
                _switch.GetCoreTemperature();
            }
            catch (CoreTemperatureReadException ex)
            {
                LogMessage($"Ошибка чтения температуры ядра: {ex.Message}");
            }

            try
            {
                // Шаг 5: Вставка управляющих стержней
                _switch.InsertRodCluster();
            }
            catch (RodClusterReleaseException ex)
            {
                LogMessage($"Ошибка освобождения управляющих стержней: {ex.Message}");
            }

            try
            {
                // Шаг 6: Чтение температуры ядра после отключения
                _switch.GetCoreTemperature();
            }
            catch (CoreTemperatureReadException ex)
            {
                LogMessage($"Ошибка чтения температуры ядра после отключения: {ex.Message}");
            }

            try
            {
                // Шаг 7: Чтение уровня радиации после отключения
                _switch.GetRadiationLevel();
            }
            catch (CoreRadiationLevelReadException ex)
            {
                LogMessage($"Ошибка чтения уровня радиации: {ex.Message}");
            }

            try
            {
                // Шаг 8: Завершение отключения
                _switch.SignalShutdownComplete();
            }
            catch (SignallingException ex)
            {
                LogMessage($"Ошибка сигнала завершения отключения: {ex.Message}");
            }
        }



        private void LogMessage(string message)
        {
            Dispatcher.Invoke(() =>
            {
                logTextBox.Text += $"{DateTime.Now}: {message}\n";
            });
        }
    }
}
