using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    
    public Queue<GameObject> objQueue = new Queue<GameObject>(); // 오브젝트들이 들어갈 큐
    
    public GameObject objPrefab; // 생성할 오브젝트
    public Transform parent; // 계층 구조상 들어갈 부모 오브젝트

    private void Start()
    {
        CreateObject();
    }

    private void CreateObject() // 오브젝트를 생성하는 기능 -> Pool을 채우는 기능
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent); // 오브젝트를 생성하고, 계층 구조를 parent의 자식으로 변경
            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject obj) // 집어넣는 함수
    {
        // 사용된 오브젝트의 물리적 변화가 유지되는 것을 방지하기 위해 초기화
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        objQueue.Enqueue(obj);
        obj.SetActive(false); // 오브젝트가 작동되지않도록 Active -> false
    }

    public GameObject DequeueObject() // 꺼내쓰는 함수
    {
        // pool의 오브젝트를 다썼을 경우 pool에 오브젝트 추가
        // n개씩 동시에 꺼내는 경우 0이 아닌 여유롭게 조건 설정
        if (objQueue.Count <= 3)  // pool 남은 오브젝트가 3개 이하일경우
        {
            CreateObject();
        }
        
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);
        
        return obj;
        
    }
}
