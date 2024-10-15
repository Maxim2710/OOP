using System;
using DeviceControl;

namespace MeasuringDevice
{
    public class MeasureLengthDevice : MeasureDataDevice, IControllableDevice
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
            // Генерируем случайное значение измерения длины от 0 до 100
            return random.Next(0, 101);
        }

        public void Dispose()
        {
            StopDevice();
            Console.WriteLine("Length measurement device disposed.");
        }

        protected override DeviceType measurementType => DeviceType.LENGTH;

        public MeasureLengthDevice(Units units)
        {
            unitsToUse = units;
            dataCaptured = new int[10]; // Буфер данных фиксированного размера
        }

        public MeasureLengthDevice()
        {
            // Вызываем конструктор по умолчанию
        }

        public override decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : mostRecentMeasure * 25.4m; // Конвертация в миллиметры
        }

        public override decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : mostRecentMeasure * 0.03937m; // Конвертация в дюймы
        }
    }
}
