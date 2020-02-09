using Player;
using Publisher.Subscriber;
using UnityEngine;

namespace AccomplishmentSystem
{
    public class PlayerSuccessfulEvent : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerBase>())
            {
                AccomplishmentEventBroker.CallOnPlayerSuccessful();
            }
        }
    }
}