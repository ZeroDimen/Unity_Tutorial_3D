using UnityEngine;

namespace Pattern.Command
{
    public class AttackCommend : ICommand
    {
        private Player player;

        public AttackCommend(Player player)
        {
            this.player = player;
        }
        
        public void Execute()
        {
            player.Attack();
        }

        public void Cancel()
        {
            player.AttackCancel();
        }
    }
}