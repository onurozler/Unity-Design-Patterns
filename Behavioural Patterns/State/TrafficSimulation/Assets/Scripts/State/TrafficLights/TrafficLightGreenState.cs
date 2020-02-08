using Base;
using UnityEngine;
using Utils;


namespace State.TrafficLights
{
    public class TrafficLightGreenState : ITrafficLightState
    {
        private TrafficLight _trafficLight;
        private Light _greenLight;

        public TrafficLightGreenState(TrafficLight trafficLight, Light greenLight)
        {
            _trafficLight = trafficLight;
            _greenLight = greenLight;
        }

        public void Enter()
        {
            _greenLight.enabled = true;
            Light();
        }

        public void Light()
        {
            Timer.Instance.TimerWait(5, () =>
            {
                _trafficLight.ChangeState(_trafficLight.YellowState);
            });
        }

        public void Exit()
        {
            _greenLight.enabled = false;
        }
    } 
}

