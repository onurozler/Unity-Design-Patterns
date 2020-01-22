using System;
using System.Collections;
using Duck_Behaviors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Duck
{
    public class DuckBase : MonoBehaviour
    {
        public string Name;
        public string DuckType;
        
        protected IFlyBehaviour FlyBehaviour;

        private void Awake()
        {
            // Default Fly Behavior, If derived classes don't assign
            FlyBehaviour = new FlyNormal();
        }
        
        public void Fly()
        {
            StartCoroutine(StartMoving());
        }
        
        public void SetFlyBehavior(IFlyBehaviour flyBehaviour)
        {
            FlyBehaviour = flyBehaviour;
        }

        public IFlyBehaviour GetFlyBehavior()
        {
            return FlyBehaviour;
        }
        
        private IEnumerator StartMoving()
        {
            while (true)
            {
                transform.LookAt(SelectRandomDirection());
                FlyBehaviour.Fly(this.transform);
                yield return new WaitForSeconds(5f);
            }
        }


        private Vector3 SelectRandomDirection()
        {
            var right = transform.right;
            var up = transform.forward;
            Vector3[] directions = {right, -right, up, -up};
            int rnd = Random.Range(0, 4);

            return directions[rnd];
        }
    }
}

