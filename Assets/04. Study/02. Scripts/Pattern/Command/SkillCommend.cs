using UnityEngine;

namespace Pattern.Command
{
    public class SkillCommend : ICommand
    {
        
        private Player player;
        private string skillName;

        public SkillCommend(Player player, string skillName)
        {
            this.player = player;
            this.skillName = skillName;
        }
        
        public void Execute()
        {
            player.Skill(skillName);
        }

        public void Cancel()
        {
            player.SkillCancel(skillName);
        }
    }
}