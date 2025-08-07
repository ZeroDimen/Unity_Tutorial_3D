using UnityEngine;

namespace Pattern.Decorator
{
    public class FireAttack : AttackDecorator
    {
        public FireAttack(IAttack attack) : base(attack)
        {
            
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("불 속성 추가 피해");
        }
    }
}