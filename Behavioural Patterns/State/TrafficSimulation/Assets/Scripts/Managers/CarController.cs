using System;
using Base;
using UnityEngine;

namespace Managers
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Car _car;
        [SerializeField] private TrafficLight _trafficLight;
        
        private void Awake()
        {
            _car.Initialize(_trafficLight);
        }

        private void Update()
        {
            _car.Drive();
        }
    }
}

