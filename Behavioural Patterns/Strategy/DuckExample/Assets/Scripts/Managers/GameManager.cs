using System;
using Duck;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private DuckBase _mallardDuck;
        [SerializeField] private DuckBase _rubberDuck;
        [SerializeField] private DuckBase _redHeadDuck;
        
        private void Awake()
        {
            _mallardDuck = Instantiate(_mallardDuck);
            _rubberDuck = Instantiate(_rubberDuck);
            _redHeadDuck = Instantiate(_redHeadDuck);
        }

        private void Start()
        {
            _mallardDuck.Fly();
            _rubberDuck.Fly();
            _redHeadDuck.Fly();
        }
    } 
}

