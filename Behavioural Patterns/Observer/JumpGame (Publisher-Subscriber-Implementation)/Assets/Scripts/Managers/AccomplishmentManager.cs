using Player;
using Publisher.Subscriber;
using UnityEngine;

namespace Managers
{
    public class AccomplishmentManager : MonoBehaviour
    {
        [SerializeField] private PlayerBase _player;
        
        private Vector3 _firstPositionPlayer;
        
        private void Awake()
        {
            AccomplishmentEventBroker.OnPlayerSuccessful += PlayerSuccessful;
            AccomplishmentEventBroker.OnPlayerFail += PlayerFail; 
            
            _firstPositionPlayer = _player.transform.position;
        }

        private void PlayerSuccessful()
        {
            _player.enabled = false;
        }

        private void PlayerFail()
        {
            _player.transform.position =
                new Vector3(_firstPositionPlayer.x, _firstPositionPlayer.y, _firstPositionPlayer.z);
        }
    }
}
