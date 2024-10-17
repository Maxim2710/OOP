using DeviceControl;
using System;
using System.ComponentModel; // Для BackgroundWorker
using System.IO; // Для StreamWriter
using System.Timers;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IEventEnabledMeasuringDevice, IDisposable
    {
        protected Units unitsToUse;
        protected int[] dataCaptured;
        protected int mostRecentMeasure;
        protected DeviceController controller;
        private System.Timers.Timer heartBeatTimer;

        // Добавляем BackgroundWorker
        private BackgroundWorker dataCollector;
        private StreamWriter loggingFileWriter;
        private bool disposed = false;

        // Реализуем интерфейс IEventEnabledMeasuringDevice
        public event EventHandler NewMeasurementTaken;
        public event HeartBeatEventHandler HeartBeat;

        // Интервал для HeartBeat
        public int HeartBeatInterval { get; private set; }

        protected abstract DeviceType measurementType { get; }

        // Конструктор для инициализации интервала heartbeat и таймера
        public MeasureDataDevice(int heartBeatInterval)
        {
            HeartBeatInterval = heartBeatInterval;
            heartBeatTimer = new System.Timers.Timer(HeartBeatInterval);
            heartBeatTimer.Elapsed += OnHeartBeat;
        }

        public void StartCollecting()
        {
            // Инициализация контроллера
            if (controller != null)
            {
                controller.StopDevice(); // Останавливаем устройство, если оно уже работает
            }

            controller = DeviceController.StartDevice(measurementType);
            loggingFileWriter = new StreamWriter("measurements.log", true); // Инициализация логирования

            // Запуск сбора измерений
            GetMeasurements();

            heartBeatTimer.Start(); // Запуск heartbeat
        }

        // Измените метод StopCollecting
        public void StopCollecting()
        {
            if (controller != null)
            {
                // Остановка устройства
                controller.StopDevice();
                controller = null; // Освобождаем ресурс

                // Остановка BackgroundWorker
                if (dataCollector != null && dataCollector.IsBusy)
                {
                    dataCollector.CancelAsync(); // Запрос на отмену
                }

                // Закрываем файл лога
                CloseLoggingFile();

                // Остановка heartbeat
                if (heartBeatTimer != null)
                {
                    heartBeatTimer.Stop();
                }
            }
        }

        // Закрытие файла логов
        private void CloseLoggingFile()
        {
            if (loggingFileWriter != null)
            {
                loggingFileWriter.Close();
                loggingFileWriter = null; // Обнуляем, чтобы избежать двойного закрытия
            }
        }

        public void Dispose()
        {
            // Проверяем, что BackgroundWorker не null
            if (dataCollector != null)
            {
                dataCollector.Dispose(); // Освобождаем ресурсы BackgroundWorker
            }

            // Устанавливаем флаг, что объект уничтожен
            disposed = true;

            // Останавливаем и освобождаем таймер heartbeat
            if (heartBeatTimer != null)
            {
                heartBeatTimer.Stop();
                heartBeatTimer.Dispose();
            }

            // Закрываем файл логов, если он открыт
            CloseLoggingFile();
        }

        public int[] GetRawData()
        {
            return dataCaptured;
        }

        public string GetLoggingFile()
        {
            // Возвращаем путь к лог-файлу
            return "measurements.log";
        }

        public Units UnitsToUse => unitsToUse;

        public int[] DataCaptured => dataCaptured;

        public int MostRecentMeasure => mostRecentMeasure;

        public string LoggingFileName { get; set; }

        // Метод для асинхронного сбора данных
        private void GetMeasurements()
        {
            // Инициализируем BackgroundWorker
            dataCollector = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            // Привязываем обработчики событий
            dataCollector.DoWork += dataCollector_DoWork;
            dataCollector.ProgressChanged += dataCollector_ProgressChanged;

            // Запускаем асинхронный сбор данных
            dataCollector.RunWorkerAsync();
        }

        // Метод для фоновой работы (сбор данных)
        private void dataCollector_DoWork(object sender, DoWorkEventArgs e)
        {
            // Инициализируем массив на 10 элементов
            dataCaptured = new int[10];

            // Переменная для отслеживания позиции в массиве
            int i = 0;

            // Цикл будет выполняться, пока не будет запрошена отмена
            while (!dataCollector.CancellationPending)
            {
                if (disposed) break; // Прерываем цикл, если объект уничтожен

                try
                {
                    // Получаем новое измерение от контроллера и сохраняем его в массив
                    dataCaptured[i] = controller.TakeMeasurement();

                    // Обновляем последнее измерение
                    mostRecentMeasure = dataCaptured[i];

                    // Логирование данных, если writer не null
                    loggingFileWriter?.WriteLine($"Measurement - {mostRecentMeasure}");

                    // Сообщаем о прогрессе
                    dataCollector.ReportProgress(0);
                }
                catch (Exception ex)
                {
                    // Обработка исключений и прерывание цикла при ошибках
                    Console.WriteLine($"Error while taking measurement: {ex.Message}");
                    break;
                }

                // Увеличиваем индекс
                i++;

                // Если i превышает 9, сбрасываем его в 0
                if (i > 9)
                {
                    i = 0;
                }

                System.Threading.Thread.Sleep(100); // Задержка для симуляции времени сбора данных
            }
        }

        // Обработчик события ProgressChanged
        private void dataCollector_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Вызываем метод для генерации события о новом измерении
            OnNewMeasurementTaken();
        }

        // Метод для обработки события HeartBeat
        private void OnHeartBeat(object sender, ElapsedEventArgs e)
        {
            HeartBeat?.Invoke(this, EventArgs.Empty); // Вызов события HeartBeat
        }

        // Метод для вызова события NewMeasurementTaken
        protected virtual void OnNewMeasurementTaken()
        {
            NewMeasurementTaken?.Invoke(this, EventArgs.Empty);
        }

        // Абстрактные методы для конвертации значений
        public abstract decimal MetricValue();
        public abstract decimal ImperialValue();
    }
}
