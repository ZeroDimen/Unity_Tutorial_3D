using System;
using UnityEngine;

// 선형탐색의 예시 (중간값 기준으로 반씩 줄어들면서 탐색 -> O(log n)
public class LinearSearch : MonoBehaviour
{
    private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int target = 7;

    private void Start()
    {
        LSearch(array, target);
    }

    private void LSearch(int[] arr, int t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == t)
            {
                Debug.Log($"{t}는 {i}번째에 있습니다.");
            }
        }
    }
}
