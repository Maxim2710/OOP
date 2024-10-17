using System;

namespace MeasuringDevice
{
    public delegate void HeartBeatEventHandler(object sender, EventArgs e);

    // New interface that extends IMeasuringDevice
    public interface IEventEnabledMeasuringDevice : IMeasuringDevice
    {
        // Event for when a new measurement is taken
        event EventHandler NewMeasurementTaken;

        // Event for HeartBeat, which will fire periodically
        event HeartBeatEventHandler HeartBeat;

        // Read-only property for heartbeat interval, initialized in the constructor
        int HeartBeatInterval { get; }
    }
}
