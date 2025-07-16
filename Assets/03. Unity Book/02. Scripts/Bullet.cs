using UnityEngine;

// Bullet의 이동을 관리하는 스크립트
public class Bullet : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * (speed * Time.deltaTime);
    }
}