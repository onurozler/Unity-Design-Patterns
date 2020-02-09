using System;
using System.Collections.Generic;
using AccomplishmentSystem;
using Managers;
using ObserverSystem;
using UnityEngine;
using View;

public class GameManager : MonoBehaviour
{
    public AccomplishmentManager AccomplishmentManager;
    public PlayerView PlayerView;

    public PlayerSuccesfulSubject PlayerSuccesful;
    public PlayerFailSubject PlayerFail;

    private void Awake()
    {
        PlayerSuccesful.Initialize();
        PlayerFail.Initialize();
        
        PlayerSuccesful.RegisterObserver(PlayerView);
        PlayerSuccesful.RegisterObserver(AccomplishmentManager);
        
        PlayerFail.RegisterObserver(PlayerView);
        PlayerFail.RegisterObserver(AccomplishmentManager);
    }
}
