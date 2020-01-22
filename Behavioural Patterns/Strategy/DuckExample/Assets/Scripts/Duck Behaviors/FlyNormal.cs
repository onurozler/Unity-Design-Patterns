
using DG.Tweening;
using UnityEngine;

namespace Duck_Behaviors
{
    public class FlyNormal : IFlyBehaviour
    {
        public void Fly(Transform position)
        {
            position.DOJump(position.forward*5f, 5f, 1, 2f);
        }
    }
}
