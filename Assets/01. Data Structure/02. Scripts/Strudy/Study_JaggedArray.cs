using UnityEngine;

// 가변 배열
public class Study_JaggedArray : MonoBehaviour
{
    public int[] array1 = new int[3];
    public int [][] jaggedArray = new int[3][]; // int 타입 배열 3개

    void Start()
    {
        array1[0] = 1;

        jaggedArray[0] = new int [3] { 1, 2, 3 };
        jaggedArray[1] = new int [2] { 1, 2};
        jaggedArray[2] = new int [5] { 1, 2, 3, 4, 5 };
    }
}
