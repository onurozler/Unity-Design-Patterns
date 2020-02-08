
using Base;
using UnityEngine;
using Utils;

namespace State.TrafficLights
{
    public class TrafficLightRedState: ITrafficLightState
    {
        private TrafficLight _trafficLight;
        private Light _redLight;

        public TrafficLightRedState(TrafficLight trafficLight, Light redLight)
        {
            _trafficLight = trafficLight;
            _redLight = redLight;
        }

        public void Enter()
        {
            _redLight.enabled = true;
            Light();
        }

        public void Light()
        {
            Timer.Instance.TimerWait(Random.Range(3, 10),
                () =>
                {
                    _trafficLight.ChangeState(_trafficLight.YellowState); 
                    
                });
        }

        public void Exit()
        {
            _redLight.enabled = false;
        }
    }
}
