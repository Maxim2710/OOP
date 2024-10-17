using DeviceControl;
using System;

namespace MeasuringDevice
{
    public class MeasureLengthDevice : MeasureDataDevice, IControllableDevice
    {
        private Random random = new Random();
        private bool isRunning;
        private Units selectedUnits;

        public MeasureLengthDevice(Units units, int heartBeatInterval)
            : base(heartBeatInterval)
        {
            unitsToUse = units;
            dataCaptured = new int[10]; // Инициализация буфера данных
        }

        // Пустой конструктор
        public MeasureLengthDevice() : base(1000) // Установим значение по умолчанию для heartbeat
        {
        }

        // Конструктор с указанием единиц измерения
        public MeasureLengthDevice(Units selectedUnits) : base(1000) // Установим значение по умолчанию для heartbeat
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
            return random.Next(0, 101); // Случайное значение длины от 0 до 100
        }

        public void Dispose()
        {
            StopDevice();
            Console.WriteLine("Устройство для измерения длины отключено.");
        }

        protected override DeviceType measurementType => DeviceType.LENGTH;

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
