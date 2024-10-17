namespace DeviceControl
{
    public interface IControllableDevice : IDisposable
    {
        /// <summary>
        /// Запускает устройство для выполнения измерений.
        /// </summary>
        void StartDevice();

        /// <summary>
        /// Останавливает устройство.
        /// </summary>
        void StopDevice();

        /// <summary>
        /// Получает последнее измерение, выполненное устройством.
        /// </summary>
        /// <returns>Последнее измерение в виде целого числа.</returns>
        int GetLatestMeasure();
    }
}