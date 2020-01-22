using DG.Tweening;
using UnityEngine;

namespace Duck_Behaviors
{
    public class FlyZigzag : IFlyBehaviour
    {
        public void Fly(Transform position)
        {
            position.DOJump(position.forward*5f, 5f, 3, 4f);
        }
    }
}
