using Duck_Behaviors;

namespace Duck
{
    public class RubberDuck : DuckBase
    {
        private const string _type = "Rubber Duck";
        
        private void Awake()
        {
            DuckType = _type;
            FlyBehaviour = new FlyZigzag();
        }
    }
}

