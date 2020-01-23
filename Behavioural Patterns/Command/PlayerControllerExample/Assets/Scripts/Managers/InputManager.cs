using System.Collections.Generic;
using Command.ConcreteCommands;
using Command.ConcreteCommands.Helpers;
using Character;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    // Invoker
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Player character;
        
        
        [SerializeField] private Button _buttonUP;
        [SerializeField] private Button _buttonDOWN;
        [SerializeField] private Button _buttonRIGHT;
        [SerializeField] private Button _buttonLEFT;
        [SerializeField] private Button _buttonUNDO;
        [SerializeField] private Button _buttonREDO;

        private Stack<MoveCommand<Player>> _moveCommandsStack = new Stack<MoveCommand<Player>>();
        private Stack<MoveCommand<Player>> _redoCommandsStack = new Stack<MoveCommand<Player>>();

        private void Awake()
        {
            MoveCommand<Player> moveCommandUP = new MoveCommand<Player> (character,MoveDirection.FORWARD);
            MoveCommand<Player> moveCommandDOWN = new MoveCommand<Player> (character,MoveDirection.BACK);
            MoveCommand<Player> moveCommandLEFT = new MoveCommand<Player> (character,MoveDirection.LEFT);
            MoveCommand<Player> moveCommandRIGHT = new MoveCommand<Player> (character,MoveDirection.RIGHT);
            
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
                    
                    MoveCommand<Player> command = _moveCommandsStack.Pop();
                    _redoCommandsStack.Push(command);
                    command.Undo();
                }
            });
            
            _buttonREDO.onClick.AddListener(() =>
            {
                if (_redoCommandsStack.Count > 0)
                {
                    MoveCommand<Player> command = _redoCommandsStack.Pop();
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

