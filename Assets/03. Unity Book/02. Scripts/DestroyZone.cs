using UnityEngine;

// 오브젝트에 닿는 오브젝트를 파괴하는 스크립트
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
