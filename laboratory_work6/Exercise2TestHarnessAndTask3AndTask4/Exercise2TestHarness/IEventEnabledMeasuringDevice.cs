using System;

namespace MeasuringDevice
{
    public delegate void HeartBeatEventHandler(object sender, EventArgs e);

    // New interface that extends IMeasuringDevice
    public interface IEventEnabledMeasuringDevice : IMeasuringDevice
    {
        // Event for when a new measurement is taken
        event EventHandler NewMeasurementTaken;

        // Read-only property for heartbeat interval, initialized in the constructor
        int HeartBeatInterval { get; }
    }
}
