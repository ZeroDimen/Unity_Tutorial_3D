using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    // 접근제한자 Func <매개변수, 매개변수, 반환타입> 변수명
    public Func<int, int, int> myFunc;

    public Func<int, int> myFunc2;

    private void Start()
    {
        myFunc += AddMethod;
        myFunc += MinusMethod;
        int result = myFunc(10, 20);
        Debug.Log(result);
    }

    private int AddMethod(int num1, int num2)
    {
        return num1 + num2;
    }

    private int MinusMethod(int num1, int num2)
    {
        return num1 - num2;
    }
}