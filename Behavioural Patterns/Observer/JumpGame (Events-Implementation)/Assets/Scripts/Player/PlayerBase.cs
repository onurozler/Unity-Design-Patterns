using UnityEngine;

namespace Player
{
    public class PlayerBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Move()
        {
            _rigidbody.AddForce(transform.forward * 5);
        }
        
        private void Jump()
        {
            _rigidbody.AddForce(transform.up * 350f);
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Move();
            }
        }
    }
}

