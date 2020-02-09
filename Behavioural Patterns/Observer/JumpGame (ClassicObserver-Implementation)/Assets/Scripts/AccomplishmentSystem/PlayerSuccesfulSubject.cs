using System.Collections.Generic;
using ObserverSystem;
using Player;
using UnityEngine;

namespace AccomplishmentSystem
{
    public class PlayerSuccesfulSubject : MonoBehaviour, ISubject
    {
        private List<IObserver>  _observers;

        public void Initialize()
        {
            _observers = new List<IObserver>();
        }
        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateObserver(Accomplishment.SUCCESFULL);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerBase>())
            {
                NotifyObservers();
            }
        }
    }
}