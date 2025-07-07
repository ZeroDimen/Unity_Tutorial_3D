using System.Collections.Generic;
using UnityEngine;

// 선입선출 
public class Study_Queue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            queue.Enqueue(i); // 1 ~ 10 까지 추가
        }
        int output = queue.Dequeue(); // 값을 뽑음
        queue.Peek(); // 다음에 뽑을 값을 확인
        queue.Contains(5); // 값 5가 포함되어있는지 확인
    }


}
