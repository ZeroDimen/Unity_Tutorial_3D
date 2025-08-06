using UnityEngine;

namespace Pattern.Command
{
    public class Player : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }

        public void AttackCancel()
        {
            Debug.Log("AttackCancel");
        }
        public void Jump()
        {
            Debug.Log("Jump");
        }
        public void JumpCancel()
        {
            Debug.Log("JumpCancel");
        }
        public void Skill(string skillName)
        {
            Debug.Log($"Skill : {skillName}");
        }
        public void SkillCancel(string skillName)
        {
            Debug.Log($"SkillCancel : {skillName}");
        }
    }
}