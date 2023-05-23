﻿using Gift.SignalHandler;

namespace Gift.src.Services.SignalHandler.Bus
{
    public interface ISignalBus
    {
        void PushSignal(ISignal signal);
        void Subscribe(ISignalHandler signalmanager);
    }
}