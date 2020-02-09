
using System;
using Player;
using UnityEngine;

namespace AccomplishmentSystem
{
    public class PlayerFailEvent : MonoBehaviour
    {       
        public event Action OnPlayerFail;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerBase>())
            {
                if (OnPlayerFail != null) 
                    OnPlayerFail();
            }
        }
    }
}
