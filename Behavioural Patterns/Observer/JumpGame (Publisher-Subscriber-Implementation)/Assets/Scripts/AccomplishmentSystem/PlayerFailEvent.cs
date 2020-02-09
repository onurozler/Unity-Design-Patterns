using Player;
using Publisher.Subscriber;
using UnityEngine;

namespace AccomplishmentSystem
{
    public class PlayerFailEvent : MonoBehaviour
    {       
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerBase>())
            {
                AccomplishmentEventBroker.CallOnPlayerFail();
            }
        }
    }
}
