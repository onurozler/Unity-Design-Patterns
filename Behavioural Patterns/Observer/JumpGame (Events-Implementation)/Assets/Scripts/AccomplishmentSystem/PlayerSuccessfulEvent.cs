using System;
using Player;
using UnityEngine;

namespace AccomplishmentSystem
{
    public class PlayerSuccessfulEvent : MonoBehaviour
    {
        public event Action OnPlayerSuccessful;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerBase>())
            {
                if (OnPlayerSuccessful != null)
                    OnPlayerSuccessful();
            }
        }
    }
}