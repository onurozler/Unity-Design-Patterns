using AccomplishmentSystem;
using ObserverSystem;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View
{
    public class PlayerView : MonoBehaviour, IObserver
    {
        [SerializeField] private Text _accomplishmentText;
        
        public void UpdateObserver(Accomplishment accomplishment)
        {
            _accomplishmentText.gameObject.SetActive(true);
            if (accomplishment == Accomplishment.SUCCESFULL)
                _accomplishmentText.color = Color.green;
            else
            {
                _accomplishmentText.color = Color.red;
                Timer.Instance.TimerWait(1f, () => _accomplishmentText.gameObject.SetActive(false));
            }
            _accomplishmentText.text = accomplishment.ToString();
        }
    }
}

