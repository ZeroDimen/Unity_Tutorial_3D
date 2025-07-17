using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private PoolObject poolManager;
    
    private void Start()
    {
        Invoke("ReturnObject", 3f);
    }

    private void ReturnObject()
    {
        PoolManager.Instance.pool.Release(gameObject);
        gameObject.SetActive(false);
    }
}