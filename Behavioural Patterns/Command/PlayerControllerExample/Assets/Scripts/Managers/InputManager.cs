using System;
using System.Collections.Generic;
using Command;
using Command.ConcreteCommands;
using Command.ConcreteCommands.Helpers;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    // Invoker
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerBase _player;
        [SerializeField] private Button _buttonUP;
        [SerializeField] private Button _buttonDOWN;
        [SerializeField] private Button _buttonRIGHT;
        [SerializeField] private Button _buttonLEFT;
        [SerializeField] private Button _buttonUNDO;
        [SerializeField] private Button _buttonREDO;

        private Stack<MoveCommand<PlayerBase>> _moveCommandsStack = new Stack<MoveCommand<PlayerBase>>();
        private Stack<MoveCommand<PlayerBase>> _redoCommandsStack = new Stack<MoveCommand<PlayerBase>>();

        private void Awake()
        {
            MoveCommand<PlayerBase> moveCommandUP = new MoveCommand<PlayerBase> (_player,MoveDirection.FORWARD);
            MoveCommand<PlayerBase> moveCommandDOWN = new MoveCommand<PlayerBase> (_player,MoveDirection.BACK);
            MoveCommand<PlayerBase> moveCommandLEFT = new MoveCommand<PlayerBase> (_player,MoveDirection.LEFT);
            MoveCommand<PlayerBase> moveCommandRIGHT = new MoveCommand<PlayerBase> (_player,MoveDirection.RIGHT);
            
            _buttonREDO.interactable = false;

            _buttonUP.onClick.AddListener(() =>
            {
                _moveCommandsStack.Push(moveCommandUP);
                moveCommandUP.Execute();
            });
            _buttonDOWN.onClick.AddListener( () =>
            {
                _moveCommandsStack.Push(moveCommandDOWN);
                moveCommandDOWN.Execute();
            });
            
            _buttonRIGHT.onClick.AddListener(()=>
            {
                _moveCommandsStack.Push(moveCommandRIGHT);
                moveCommandRIGHT.Execute();
            });
            
            _buttonLEFT.onClick.AddListener(()=>
            {
                _moveCommandsStack.Push(moveCommandLEFT);
                moveCommandLEFT.Execute();
            });
            
            _buttonUNDO.onClick.AddListener(()=>
            {
                if (_moveCommandsStack.Count > 0)
                {
                    _buttonREDO.interactable = true;
                    
                    MoveCommand<PlayerBase> command = _moveCommandsStack.Pop();
                    _redoCommandsStack.Push(command);
                    command.Undo();
                }
            });
            
            _buttonREDO.onClick.AddListener(() =>
            {
                if (_redoCommandsStack.Count > 0)
                {
                    MoveCommand<PlayerBase> command = _redoCommandsStack.Pop();
                    _moveCommandsStack.Push(command);
                    command.Execute();
                }
                else 
                    _buttonREDO.interactable = false;

            });
        }
        
        private void Update()
        {
            
        }
    }
}

