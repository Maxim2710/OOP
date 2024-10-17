using System;

namespace MeasuringDevice
{
    public class HeartBeatEventArgs : EventArgs
    {
        public DateTime TimeStamp { get; set; }

        public HeartBeatEventArgs() : base()
        {
            TimeStamp = DateTime.Now;
        }
    }

}
