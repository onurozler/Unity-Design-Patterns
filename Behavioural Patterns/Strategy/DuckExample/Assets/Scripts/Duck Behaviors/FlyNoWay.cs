using DG.Tweening;
using UnityEngine;

namespace Duck_Behaviors
{
    public class FlyNoWay : IFlyBehaviour
    {
        public void Fly(Transform position)
        {
            position.DOMove(position.forward*5f, 2f);
        }
    }
}
