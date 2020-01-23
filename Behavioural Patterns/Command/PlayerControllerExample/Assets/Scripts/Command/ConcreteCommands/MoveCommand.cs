using Command.ConcreteCommands.Helpers;
using Player;
using UnityEngine;

namespace Command.ConcreteCommands
{
    // Generic Move Command for every class that derived PlayerBase
    public class MoveCommand<T> : ICommand where T:PlayerBase
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
                    _playerBase.transform.Translate(Vector3.forward * 5f);
                    break;
                case MoveDirection.BACK:
                    _playerBase.transform.Translate(Vector3.back * 5f);
                    break;
                case MoveDirection.LEFT:
                    _playerBase.transform.Translate(Vector3.left * 5f);
                    break;
                case MoveDirection.RIGHT:
                    _playerBase.transform.Translate(Vector3.right * 5f);
                    break;
            }
        }

        public void Undo()
        {
            switch (_moveDirection)
            {
                case MoveDirection.FORWARD:
                    _playerBase.transform.Translate(Vector3.back * 5f);
                    break;
                case MoveDirection.BACK:
                    _playerBase.transform.Translate(Vector3.forward * 5f);
                    break;
                case MoveDirection.LEFT:
                    _playerBase.transform.Translate(Vector3.right * 5f);
                    break;
                case MoveDirection.RIGHT:
                    _playerBase.transform.Translate(Vector3.left * 5f);
                    break;
            }
        }
    }
}


