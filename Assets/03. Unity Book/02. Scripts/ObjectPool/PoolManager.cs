using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    private void Awake()
    {
        // 생성 -> 꺼내쓰고 -> 집어넣는 기능 가능
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject, OnDestroyObject, maxSize: 100);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        
        return obj;
    }
    
    private void OnGetObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
        Debug.Log("오브젝트 생성");
    }
    
    private void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    
    private void OnDestroyObject (GameObject obj)
    {
        Destroy(obj);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.Get();
            Debug.Log("생성");
            
            obj.SetActive(true);
        }
    }
}