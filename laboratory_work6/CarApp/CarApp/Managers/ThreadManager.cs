using System;
using System.Threading;

namespace CarSimulationApp.Managers
{
    public static class ThreadManager
    {
        private static object _lockObject = new object();

        public static void LockAction(Action action)
        {
            lock (_lockObject)
            {
                action();
            }
        }

        public static void MonitorAction(Action action)
        {
            bool lockTaken = false;
            Monitor.Enter(_lockObject, ref lockTaken);
            try
            {
                action();
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(_lockObject);
            }
        }
    }
}
