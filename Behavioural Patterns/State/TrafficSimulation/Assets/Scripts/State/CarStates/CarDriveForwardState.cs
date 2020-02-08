using UnityEngine;

namespace State.CarStates
{
    public class CarDriveForwardState : ICarState
    {
        private Car _car;
        private Vector3 _carDirection;
        
        public CarDriveForwardState(Car car)
        {
            _car = car;
        }

        public void Enter()
        {
            _carDirection = Vector3.forward;
        }

        public void LogicUpdate()
        {
            if (!_car.CheckTrafficLight())
            {
                _car.ChangeState(_car.CarWaitingState);
                return;
            }
            
            _car.transform.Translate(_car.CarSpeed * Time.deltaTime * _carDirection);
        }
    }
}
