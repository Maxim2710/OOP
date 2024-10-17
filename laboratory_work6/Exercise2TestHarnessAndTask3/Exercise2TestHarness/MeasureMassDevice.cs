using DeviceControl;
using System;

namespace MeasuringDevice
{
    public class MeasureMassDevice : MeasureDataDevice, IControllableDevice
    {
        private Random random = new Random();
        private bool isRunning;
        private Units selectedUnits;

        public MeasureMassDevice(Units units, int heartBeatInterval)
            : base(heartBeatInterval)
        {
            unitsToUse = units;
            dataCaptured = new int[10]; // Инициализация буфера данных
        }

        public MeasureMassDevice() : base(1000)
        {
        }

        public MeasureMassDevice(Units selectedUnits) : base(1000)
        {
            this.selectedUnits = selectedUnits;
        }

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
                throw new InvalidOperationException("Устройство не запущено.");
            }
            return random.Next(0, 1001); // Случайное значение массы от 0 до 1000
        }

        public void Dispose()
        {
            StopDevice();
            Console.WriteLine("Устройство для измерения массы отключено.");
        }

        protected override DeviceType measurementType => DeviceType.MASS;

        public override decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : mostRecentMeasure * 0.4536m; // Конвертация в килограммы
        }

        public override decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : mostRecentMeasure * 2.2046m; // Конвертация в фунты
        }
    }
}
