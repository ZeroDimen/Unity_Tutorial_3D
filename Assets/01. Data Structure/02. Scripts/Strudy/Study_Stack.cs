using System;
using System.Collections.Generic;
using UnityEngine;

// 후입선출 구조
public class Study_Stack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i); // 추가 : 스택의 맨위에 데이터를 추가하는 함수
        }

        stack.Pop(); // 스택의 맨 위에 있는 데이터를 뽑는 함수
        stack.Peek(); // 스택의 맨 위에 있는 데이터를 출력하는 함수
        
        
    }
}
