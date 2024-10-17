using MeasuringDevice;

namespace DeviceControl
{
    public enum DeviceType
    {
        LENGTH,
        MASS
    }

    public class DeviceController : IDisposable
    {
        private IControllableDevice device;

        public static DeviceController StartDevice(DeviceType MeasurementType)
        {
            DeviceController controller = new DeviceController();
            switch (MeasurementType)
            {
                case DeviceType.LENGTH:
                    controller.device = new MeasureLengthDevice();
                    break;
                case DeviceType.MASS:
                    controller.device = new MeasureMassDevice();
                    break;
            }
            if (controller.device != null)
            {
                controller.device.StartDevice();
            }
            return controller;
        }
        /// <summary>
        /// Stops the controlled device.
        /// </summary>
        public void StopDevice()
        {
            device.StopDevice();
        }
        /// <summary>
        /// Forces the controlled device to record a measurement.
        /// </summary>
        /// <returns>The measurement taken by the device.</returns>
        public int TakeMeasurement()
        {
            return device.GetLatestMeasure();
        }
        /// <summary>
        /// Disposes the device.
        /// </summary>
        public void Dispose()
        {
        }
    }
}