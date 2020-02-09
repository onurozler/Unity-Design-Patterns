using System;
using AccomplishmentSystem;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerSuccessfulEvent _playerSuccessfulEvent;
        [SerializeField] private PlayerFailEvent _playerFailEvent;
        [SerializeField] private Text _accomplishmentText;

        private void Awake()
        {
            _playerSuccessfulEvent.OnPlayerSuccessful += UpdateSuccessfulPlayer;
            _playerFailEvent.OnPlayerFail += UpdateFailPlayer;
        }

        private void UpdateSuccessfulPlayer()
        {
            _accomplishmentText.gameObject.SetActive(true);
            _accomplishmentText.color = Color.green;
            _accomplishmentText.text = "Successful";
        }

        private void UpdateFailPlayer()
        {
            _accomplishmentText.gameObject.SetActive(true);
            _accomplishmentText.color = Color.red;
            _accomplishmentText.text = "Fail";
            Timer.Instance.TimerWait(1f, () => _accomplishmentText.gameObject.SetActive(false));
        }
    }
}

