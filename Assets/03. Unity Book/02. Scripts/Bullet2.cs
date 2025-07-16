using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // 오브젝트 파괴
            
            Destroy(other.gameObject, 10f); // 오브젝트 지연 파괴
        }
    }
}