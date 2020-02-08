namespace State.CarStates
{
    public class CarWaitingState : ICarState
    {
        private Car _car;
        
        public CarWaitingState(Car car)
        {
            _car = car;
        }

        public void Enter()
        {
        }

        public void LogicUpdate()
        {
            if(_car.CheckTrafficLight())
                _car.ChangeState(_car.CarDriveForwardState);
        }
    }
}