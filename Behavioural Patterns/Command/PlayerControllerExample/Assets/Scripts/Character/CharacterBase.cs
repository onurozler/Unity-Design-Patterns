using UnityEngine;

namespace Character
{
    public class CharacterBase : MonoBehaviour
    {
        public virtual void MoveForward()
        {
            transform.Translate(Vector3.forward * 5f);
        }
        public virtual void MoveBack()
        {
            transform.Translate(Vector3.back * 5f);
        }
        
        public virtual void MoveLeft()
        {
            transform.Translate(Vector3.left * 5f);
        }
        
        public virtual void MoveRight()
        {
            transform.Translate(Vector3.right * 5f);
        }
        
    }
}

