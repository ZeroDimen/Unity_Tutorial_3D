using System;
using UnityEngine;

// 다차원 배열
public class Study_MultiDimensionArray : MonoBehaviour
{
    public int[,] array1 = new int [3, 3]; // 2차원 배열
    public int[,,] array2 = new int [3, 3, 3]; // 3차원 배열

    private void Start()
    {
        int num1 = array1[0, 0];
    }
}
