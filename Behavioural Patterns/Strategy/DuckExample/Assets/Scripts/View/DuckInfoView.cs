using System;
using System.Collections.Generic;
using System.Linq;
using Duck;
using Duck_Behaviors;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace View
{
    public class DuckInfoView : MonoBehaviour
    {
        [SerializeField] private Text _duckName;
        [SerializeField] private Text _duckType;
        [SerializeField] private Text _flyType;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _changeButton;

        private List<IFlyBehaviour> _flyBehaviours = new List<IFlyBehaviour>()
        {
            new FlyNormal(),
            new FlyZigzag(),
            new FlyNoWay()
        };
        
        public static DuckInfoView Instance;
        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);

            if (Instance == null)
                Instance = this;
            
            gameObject.SetActive(false);
        }
        
        public void Open(DuckBase duck)
        {
            gameObject.SetActive(true);
            
            _changeButton.onClick.RemoveAllListeners();

            _duckName.text = "Duck Name : " + duck.Name;
            _duckType.text = "Duck Type : " + duck.DuckType;
            _flyType.text = "Fly Type : " + duck.GetFlyBehavior().GetType().Name;
            
            _changeButton.onClick.AddListener(() =>
            {
                var newFlyBehavior = _flyBehaviours.Skip(Random.Range(0,2))
                    .FirstOrDefault(s => s.GetType() != duck.GetFlyBehavior().GetType());
                
                duck.SetFlyBehavior(newFlyBehavior);
                _flyType.text = "Fly Type : " + duck.GetFlyBehavior().GetType().Name;
            });

        }
        
        
        private void Close()
        {
            gameObject.SetActive(false);
        }
    }
}

