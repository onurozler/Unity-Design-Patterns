using UnityEngine;

namespace State.TrafficLights
{
    public interface ITrafficLightState
    {
        void Enter();
        void Light();
        void Exit();
    }
}

