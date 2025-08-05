using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class StudyDecoupling : MonoBehaviour
{
    public class Player
    {
        // public Enemy enemy;
        //
        // public void AttackEnemy()
        // {
        //     enemy.TakeDamage(10);
        // 
        public void AttackEnemy(IDamageable target, float damage)
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        public float health = 10;

        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"{damage} 만큼 공격 받음.");
        }
    }
}