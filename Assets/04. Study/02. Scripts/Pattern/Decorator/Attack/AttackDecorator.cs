using UnityEngine;

namespace Pattern.Decorator
{
    public class AttackDecorator : IAttack
    {
        protected IAttack attack;

        public AttackDecorator(IAttack attack)
        {
            this.attack = attack;
        }
        public virtual void Execute()
        {
            attack.Execute();
        }
    }
}