using UnityEngine;

namespace Character
{
    public class Enemy : CharacterBase
    {
        public override void MoveForward()
        {
            base.MoveForward();
            //transform.Translate(Vector3.up * 3f);
        }

        public override void MoveBack()
        {
            base.MoveBack();
            //transform.Translate(Vector3.up * 3f);
        }

        public override void MoveLeft()
        {
            base.MoveLeft();
            //transform.Translate(Vector3.up * 3f);
        }

        public override void MoveRight()
        {
            base.MoveRight();
            //transform.Translate(Vector3.up * 3f);
        }
    }
}

