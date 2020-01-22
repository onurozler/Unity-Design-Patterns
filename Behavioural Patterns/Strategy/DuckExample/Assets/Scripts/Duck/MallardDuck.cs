using Duck_Behaviors;

namespace Duck
{
    public class MallardDuck : DuckBase
    {
        private const string _type = "Mallard Duck";
        private void Awake()
        {
            DuckType = _type;
            FlyBehaviour = new FlyNormal();
        }
    }
}