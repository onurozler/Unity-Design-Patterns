using System;
using AccomplishmentSystem;
using ObserverSystem;
using Player;
using UnityEngine;

namespace Managers
{
    public class AccomplishmentManager : MonoBehaviour, IObserver
    {
        [SerializeField] private PlayerBase _player;
        private Vector3 _firstPositionPlayer;
        
        private void Awake()
        {
            _firstPositionPlayer = _player.transform.position;
        }
        
        public void UpdateObserver(Accomplishment accomplishment)
        {
            if (accomplishment == Accomplishment.FAIL)
            {
                _player.transform.position =
                    new Vector3(_firstPositionPlayer.x, _firstPositionPlayer.y, _firstPositionPlayer.z);
            }
            else
                _player.enabled = false;
        }
    }
}
