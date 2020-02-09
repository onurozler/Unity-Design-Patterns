using AccomplishmentSystem;
using Player;
using UnityEngine;

namespace Managers
{
    public class AccomplishmentManager : MonoBehaviour
    {
        [SerializeField] private PlayerSuccessfulEvent _playerSuccessfulEvent;
        [SerializeField] private PlayerFailEvent _playerFailEvent;
        [SerializeField] private PlayerBase _player;
        
        
        private Vector3 _firstPositionPlayer;
        
        private void Awake()
        {
            _playerSuccessfulEvent.OnPlayerSuccessful += PlayerSuccessful;
            _playerFailEvent.OnPlayerFail += PlayerFail; 
            
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
