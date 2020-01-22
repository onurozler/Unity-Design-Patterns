using System;
using Duck;
using UnityEngine;
using View;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        public Camera Camera;

        private void Awake()
        {
            Camera = Camera == null ? Camera.main : Camera;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.GetComponent<DuckBase>())
                    {
                        DuckBase duck = hit.collider.GetComponent<DuckBase>();
                        DuckInfoView.Instance.Open(duck);
                    }
                }
            }
        }
    }
}

