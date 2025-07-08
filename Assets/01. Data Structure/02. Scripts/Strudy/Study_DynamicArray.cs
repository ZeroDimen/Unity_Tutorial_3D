using System;
using System.Collections.Generic;
using UnityEngine;

// 동적 배열
public class Study_DynamicArray : MonoBehaviour
{
    // private object[] array = new object[3];
    //
    // void Add(object o)
    // {
    //     var temp = new object[array.Length];
    //     for (int i = 0; i < array.Length; i++)
    //     {
    //         temp[i] = array[i];
    //     }
    //     array = temp;
    //     array[array.Length-1] = o;
    // }
    ////////////////////////////////////////////////////////////////////////////////////
    // public List<int> list1 = new List<int>();
    // public List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };
    // public List<int> list3;
    //
    // private void Start()
    // {
    //     list1.Add(10);
    //     list2.Add(10);
    //     list3.Add(10);
    // }
    
    ////////////////////////////////////////////////////////////////////////////////////
    public List<int> list1 = new List<int>() {1,2,3};

    private void Start()
    {
        // 데이터 추가
        list1.Add(10); // 마지막에 10을 list1에 추가
        for (int i = 0; i < 10; i++) // 0 ~ 9 까지 값을 list1에 추가
        {
            list1.Add(i);
        }
        
        // list1.Insert(5,100); // 5번째 순서에 100을 list1에 추가
        // list1.Remove(5); // 값 5를 제거
        // list1.RemoveAt(5); // 인덱스 5번에 있는 값을 제거
        // list1.RemoveRange(1,3); // 인덱스 1번부터 3개 제거
        // list1.Clear(); // 데이터 모두 제거
        list1.RemoveAll(x => x > 10); // list안에서 x > 5 인 값은 모두 제거
        list1.Sort(); // 오름차순 정령

        if (list1.Contains(10)) // 리스트에 10 이라는 값이 있으면 true
        {
            
        }
    }
}
