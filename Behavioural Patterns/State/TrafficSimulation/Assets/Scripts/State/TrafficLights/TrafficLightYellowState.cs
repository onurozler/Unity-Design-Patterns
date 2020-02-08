using Base;
using UnityEngine;
using Utils;

namespace State.TrafficLights
{
    public class TrafficLightYellowState: ITrafficLightState
    {
        private TrafficLight _trafficLight;
        private Light _yellowLight;
        private ITrafficLightState _previousLight;

        public TrafficLightYellowState(TrafficLight trafficLight, Light yellowLight)
        {
            _trafficLight = trafficLight;
            _yellowLight = yellowLight;
            
            _trafficLight.OnLightStateChanged += (previousLight) => _previousLight = previousLight;
        }

        public void Enter()
        {
            _yellowLight.enabled = true;
            Light();

        }

        public void Light()
        {
            Timer.Instance.TimerWait(0.5f, () =>
            {
                if (_previousLight.GetType() == typeof(TrafficLightGreenState))
                    _trafficLight.ChangeState(_trafficLight.RedState);
                else if (_previousLight.GetType() == typeof(TrafficLightRedState))
                    _trafficLight.ChangeState(_trafficLight.GreenState);
            });
        }

        public void Exit()
        {
            _yellowLight.enabled = false;
        }
    }
}
