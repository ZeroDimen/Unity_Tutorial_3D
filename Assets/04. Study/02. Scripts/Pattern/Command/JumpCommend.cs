using UnityEngine;

namespace Pattern.Command
{
    public class JumpCommend : ICommand
    {
        private Player player;

        public JumpCommend(Player player)
        {
            this.player = player;
        }
        
        public void Execute()
        {
            player.Jump();
        }

        public void Cancel()
        {
            player.JumpCancel();
        }
    }
}