using System;
using UnityEngine;

public class StudyStatic : MonoBehaviour
{
    private void Start()
    {
        Debug.Log($"정적 변수에 접근 : {StaticClass.number}"); // 실행순서 1  // 실행순서 5
    }
}

public class StaticClass
{
    public static StaticClass instance = new StaticClass();  // 실행순서 2
    public static int number = 10; // 실행순서 4

    public StaticClass()
    {
        Debug.Log($"생성자 실행 : {number}"); // 실행순서 5
    }
}