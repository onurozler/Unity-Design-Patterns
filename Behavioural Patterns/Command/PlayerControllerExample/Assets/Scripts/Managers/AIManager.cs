using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Command.ConcreteCommands;
using Command.ConcreteCommands.Helpers;
using UnityEngine.UI;

namespace Managers
{
    using UnityEngine;

    // Basic AI that also uses same commands
    public class AIManager : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Text _enemyState;

        private Stack<MoveCommand<Enemy>> _moveCommandsStack = new Stack<MoveCommand<Enemy>>();
        private Stack<MoveCommand<Enemy>> _redoCommandsStack = new Stack<MoveCommand<Enemy>>();
        
        private void Awake()
        {
            MoveCommand<Enemy> moveCommandUP = new MoveCommand<Enemy> (_enemy,MoveDirection.FORWARD);
            MoveCommand<Enemy> moveCommandDOWN = new MoveCommand<Enemy> (_enemy,MoveDirection.BACK);
            MoveCommand<Enemy> moveCommandLEFT = new MoveCommand<Enemy> (_enemy,MoveDirection.LEFT);
            MoveCommand<Enemy> moveCommandRIGHT = new MoveCommand<Enemy> (_enemy,MoveDirection.RIGHT);
            
            List<MoveCommand<Enemy>> commands = new List<MoveCommand<Enemy>>();
            commands.Add(moveCommandUP);
            commands.Add(moveCommandDOWN);
            commands.Add(moveCommandLEFT);
            commands.Add(moveCommandRIGHT);
            
            StartCoroutine(SelectRandomCommands(commands));
        }

        private IEnumerator SelectRandomCommands(List<MoveCommand<Enemy>> commandsList)
        {
            while (true)
            {
                int selectRandom = Random.Range(0, commandsList.Count);
                int selectUndo = Random.Range(0, 10);

                
                if (_moveCommandsStack.Count > 0 && selectUndo <= 1)
                {
                    while (_moveCommandsStack.Count>0)
                    {
                        MoveCommand<Enemy> enemyCommandUndo =  _moveCommandsStack.Pop();
                        enemyCommandUndo.Undo();
                        _redoCommandsStack.Push(enemyCommandUndo);
                        _enemyState.text = "Enemy Command : Undo";
                        yield return new WaitForSeconds(1f);
                    }

                    int selectRedo = Random.Range(0, 10);
                    if (_redoCommandsStack.Count > 0 && selectRedo <= 1)
                    {
                        while (_redoCommandsStack.Count>0)
                        {
                            MoveCommand<Enemy> enemyCommandRedo = _redoCommandsStack.Pop();
                            enemyCommandRedo.Execute();
                            _moveCommandsStack.Push(enemyCommandRedo);
                            _enemyState.text = "Enemy Command : Redo";
                            yield return new WaitForSeconds(1f);
                        }
                    }
                    
                    continue;
                }

                commandsList[selectRandom].Execute();
                _moveCommandsStack.Push(commandsList[selectRandom]);
                _enemyState.text = "Enemy Command : " + commandsList[selectRandom].GetMoveDirection();
                
                yield return new WaitForSeconds(1f);
            }   
        }
    }
}
