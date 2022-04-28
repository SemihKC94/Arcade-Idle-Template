﻿namespace HeathenEngineering.Events
{
    public interface IChangeEventListener<T> : IGameEventListener<T>
    {
        void OnEventRaised(ChangeEventData<T> data);
    }
}
