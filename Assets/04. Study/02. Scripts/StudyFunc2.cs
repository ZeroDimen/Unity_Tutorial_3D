using UnityEngine;
using System;
using System.Collections.Generic;

public class StudyFunc2 : MonoBehaviour
{
    public Func<int, int, int> myFunc;
    public List<Func<int,int,int>> funcList = new List<Func<int,int,int>>();

    private void Start()
    {
        // myFunc = (a, b) => a + b;
        //
        // int result = myFunc(10,20);
        // Debug.Log(result);
        
        funcList.Add(AddMethod);
        funcList.Add(MinusMethod);
        funcList.Add(MultiplyMethod);
        
        foreach (var func in funcList)
        {
            int result = func(10,20);
            Debug.Log(result);
        }
        
        funcList.Add((a, b) => a + b);
        funcList.Add((a, b) => a - b);
        funcList.Add((a, b) => a * b);
        
        foreach (var func in funcList)
        {
            int result = func(10,20);
            Debug.Log(result);
        }
    }

    private int AddMethod(int a, int b)
    {
        return a + b;
    }

    private int MinusMethod(int a, int b)
    {
        return a - b;
    }

    private int MultiplyMethod(int a, int b)
    {
        return a * b;
    }
}