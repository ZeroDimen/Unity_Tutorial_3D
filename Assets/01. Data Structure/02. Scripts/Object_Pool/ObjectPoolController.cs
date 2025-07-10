using System;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    public ObjectPoolQueue pool;
    public Transform objInstPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           GameObject obj =  pool.DequeueObject();
           obj.transform.position = objInstPos.position;
        }
    }
}
