using System;
using UnityEngine;

// 정적 배열 : 메모리 공간을 미리 만들어두고 사용하는 자료구조
public class Study_StaticArray : MonoBehaviour
{
    // 자료형[] : 정적 배열 ( 속도 빠름, 데이터 추가, 삭제, 삽입이 불가능 )
    public int[] array1; // 배열 선언
    public int[] array2 = { 10, 20, 30, 40, 50 }; // 배열 선언 및 초기화
    public int[] array3 = new int[5]; // 배열 선언 및 공간 할당
    public int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; // 배열 선언 및 공간 할당 + 초기화
    
    NewData[] data = new NewData[5]; // 클래스 자료형도 가능

    void Start()
    {
        data[0].a = 10;
    }
}

public class NewData
{
    public int a;
    private int b;
}
