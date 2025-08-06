using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;

        private ICommand accackCommand, jumpCommand, skillcommand;
        
        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> excuteCommands = new Stack<ICommand>();

        private void Awake()
        {
            accackCommand = new AttackCommend(player);
            jumpCommand = new JumpCommend(player);
            skillcommand = new SkillCommend(player , "Fireball");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) // 공격 기능
            {
                accackCommand.Execute();
            }
            else if (Input.GetKeyDown(KeyCode.W)) // 점프 기능
            {
                jumpCommand.Execute();
            }
            else if (Input.GetKeyDown(KeyCode.E)) // 스킬 기능
            {
                skillcommand.Execute();
            }

            if (Input.GetKeyDown(KeyCode.Z)) // 취소 기능
            {
                if (excuteCommands.Count > 0)
                {
                    ICommand LastCommand = excuteCommands.Pop(); // 가장 최근에 실행한 명령
                    Debug.Log($"명령 취소 : {LastCommand.GetType().Name}");
                
                    LastCommand.Cancel(); // undo
                }
                else
                {
                    Debug.Log("되돌릴 명령이 없습니다.");
                }
            }
            
        }
    }
}