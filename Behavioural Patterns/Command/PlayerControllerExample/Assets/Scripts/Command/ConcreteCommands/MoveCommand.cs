using Command.ConcreteCommands.Helpers;
using Character;
using UnityEngine;

namespace Command.ConcreteCommands
{
    // Generic Move Command for every class that derived CharacterBase
    public class MoveCommand<T> : ICommand where T:CharacterBase
    {
        private MoveDirection _moveDirection;
        private T _playerBase;
        
        public MoveCommand(T playerBase,MoveDirection moveDirection)
        {
            _playerBase = playerBase;
            _moveDirection = moveDirection;
        }
        
        public void Execute()
        {
            switch (_moveDirection)
            {
                case MoveDirection.FORWARD:
                    _playerBase.MoveForward();
                    break;
                case MoveDirection.BACK:
                    _playerBase.MoveBack();
                    break;
                case MoveDirection.LEFT:
                    _playerBase.MoveLeft();
                    break;
                case MoveDirection.RIGHT:
                    _playerBase.MoveRight();
                    break;
            }
        }

        public void Undo()
        {
            switch (_moveDirection)
            {
                case MoveDirection.FORWARD:
                    _playerBase.MoveBack();
                    break;
                case MoveDirection.BACK:
                    _playerBase.MoveForward();
                    break;
                case MoveDirection.LEFT:
                    _playerBase.MoveRight();
                    break;
                case MoveDirection.RIGHT:
                    _playerBase.MoveLeft();
                    break;
            }
        }

        public MoveDirection GetMoveDirection()
        {
            return _moveDirection;
        }
    }
}


