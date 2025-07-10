using System;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;
    public float objSpeed;

    void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    private void OnEnable()
    {
        Invoke("ReturnPool", 3f);
    }
    
    void Update()
    {
        transform.position += Vector3.forward * (Time.deltaTime * objSpeed);
    }
    private void ReturnPool()
    {
        pool.EnqueueObject(gameObject);
    }
}