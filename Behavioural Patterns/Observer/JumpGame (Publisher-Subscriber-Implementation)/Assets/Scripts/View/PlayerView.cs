using Publisher.Subscriber;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Text _accomplishmentText;

        private void Awake()
        {
            AccomplishmentEventBroker.OnPlayerSuccessful += UpdateSuccessfulPlayer;
            AccomplishmentEventBroker.OnPlayerFail +=UpdateFailPlayer;
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

