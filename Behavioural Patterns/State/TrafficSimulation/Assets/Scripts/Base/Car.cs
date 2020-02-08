using Base;
using State.CarStates;
using State.TrafficLights;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int CarSpeed;
    
    private ICarState _currentState;
    private TrafficLight _trafficLight;
    
    public CarWaitingState CarWaitingState { get; private set; }
    public CarDriveForwardState CarDriveForwardState { get; private set; }

    public void Initialize(TrafficLight trafficLight)
    {
        CarWaitingState = new CarWaitingState(this);
        CarDriveForwardState = new CarDriveForwardState(this);

        _trafficLight = trafficLight;
        
        _currentState = CarDriveForwardState;
        _currentState.Enter();
    }

    public void ChangeState(ICarState newstate)
    {
        _currentState = newstate;
        newstate.Enter();
    }

    public bool CheckTrafficLight()
    {
        if (_trafficLight.GetCurrentState().GetType() == typeof(TrafficLightRedState))
            return false;

        return true;
    }

    public void Drive()
    {
        _currentState.LogicUpdate();
    }
}
