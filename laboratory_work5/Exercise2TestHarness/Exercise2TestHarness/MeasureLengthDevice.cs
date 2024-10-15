using System;
using System.Threading;
using DeviceControl;  

namespace MeasuringDevice
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceController controller;
        private const DeviceType measurementType = DeviceType.LENGTH;

        public MeasureLengthDevice(Units units)
        {
            unitsToUse = units;
            dataCaptured = new int[10]; // Буфер данных фиксированного размера
        }

        public decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : mostRecentMeasure * 25.4m;
        }

        public decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : mostRecentMeasure * 0.03937m;
        }

        public void StartCollecting()
        {
            if (controller == null)
            {
                controller = DeviceController.StartDevice(measurementType);
                GetMeasurements();
            }
        }

        public void StopCollecting()
        {
            if (controller != null)
            {
                DeviceController.StopDevice();
                controller = null;
            }
        }

        public int[] GetRawData()
        {
            return dataCaptured;
        }

        private void GetMeasurements()
        {
            ThreadPool.QueueUserWorkItem((_) =>
            {
                int x = 0;
                Random timer = new Random();
                while (controller != null)
                {
                    Thread.Sleep(timer.Next(1000, 5000));
                    if (controller != null)
                    {
                        dataCaptured[x] = DeviceController.TakeMeasurement();
                        mostRecentMeasure = dataCaptured[x];
                        x = (x + 1) % dataCaptured.Length;
                    }
                }
            });
        }
    }
}
