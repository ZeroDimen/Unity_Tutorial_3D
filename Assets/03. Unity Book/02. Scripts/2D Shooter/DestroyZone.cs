using UnityEngine;

// 오브젝트에 닿는 오브젝트를 파괴하는 스크립트
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        if (other.gameObject.name.Contains("Bullet"))
        {
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else
        {
            // EnemyManager.Instance.enemyObjectPool.Add(other.gameObject);
            EnemyManager.Instance.enemyObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        
    }
}
