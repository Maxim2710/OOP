using System.Diagnostics;

namespace MyCustomCollections.Helpers
{
    public static class TimerHelper
    {
        public static long MeasureExecutionTime(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
