using System;
using System.Collections;
using State.TrafficLights;
using UnityEngine;

namespace Base
{
    public class TrafficLight : MonoBehaviour
    {
        [SerializeField] private Light _greenLight;
        [SerializeField] private Light _yellowLight;
        [SerializeField] private Light _redLight;

        public Action<ITrafficLightState> OnLightStateChanged;
        
        public ITrafficLightState GreenState{ get; private set; }
        public ITrafficLightState RedState{ get; private set; }
        public ITrafficLightState YellowState { get; private set; }

        private ITrafficLightState _currentState; 
        
        void Start()
        {
            YellowState = new TrafficLightYellowState(this,_yellowLight);
            RedState = new TrafficLightRedState(this,_redLight);
            GreenState = new TrafficLightGreenState(this,_greenLight);
            
            _currentState = GreenState;
            _currentState.Enter();
        }

        public void ChangeState(ITrafficLightState state)
        {
            if(OnLightStateChanged != null)
                OnLightStateChanged.Invoke(_currentState);
            
            _currentState.Exit();
            _currentState = state;
            state.Enter();
        }

        public ITrafficLightState GetCurrentState()
        {
            return _currentState;
        }
    }
}

