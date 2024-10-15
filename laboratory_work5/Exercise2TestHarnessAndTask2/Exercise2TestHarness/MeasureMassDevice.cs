using System;
using DeviceControl;

namespace MeasuringDevice
{
    public class MeasureMassDevice : MeasureDataDevice, IControllableDevice
    {
        private Random random = new Random();
        private bool isRunning;

        public void StartDevice()
        {
            isRunning = true;
        }

        public void StopDevice()
        {
            isRunning = false;
        }

        public int GetLatestMeasure()
        {
            if (!isRunning)
            {
                throw new InvalidOperationException("Device is not running.");
            }
            // Генерируем случайное значение измерения массы от 0 до 1000
            return random.Next(0, 1001);
        }

        public void Dispose()
        {
            StopDevice();
            Console.WriteLine("Mass measurement device disposed.");
        }

        protected override DeviceType measurementType => DeviceType.MASS;

        public MeasureMassDevice(Units units)
        {
            unitsToUse = units;
            dataCaptured = new int[10];  // Инициализация массива для хранения данных
        }

        public MeasureMassDevice()
        {
            // Вызываем конструктор по умолчанию
        }

        public override decimal MetricValue()
        {
            return unitsToUse == Units.Metric ? mostRecentMeasure : mostRecentMeasure * 0.4536m; // Конвертация в килограммы
        }

        public override decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial ? mostRecentMeasure : mostRecentMeasure * 2.2046m; // Конвертация в фунты
        }
    }
}
