using Duck_Behaviors;

namespace Duck
{
    public class RedHeadDuck : DuckBase
    {
        private const string _type = "Red Head Duck";
        private void Awake()
        {
            DuckType = _type;
            FlyBehaviour = new FlyNoWay();
        }
    }
}