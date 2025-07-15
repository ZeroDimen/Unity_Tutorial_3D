using UnityEngine;

// 퀵 정렬의 예시 (기준점을 잡아서 정렬하고 다시 기준점을 잡는 정렬)
public class QuickSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", array)}");
        
        Quick(array, 0 , array.Length - 1);
        Debug.Log($"정렬 후 : {string.Join(", ", array)}");
    }

    private void Quick(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Pentition(arr, left, right);
        
            Quick(arr, left, pivot - 1);
            Quick(arr, pivot + 1, right);
        }
    }

    private int Pentition(int[] arr, int left, int right) // 피봇을 활용하여 분할
    {
        int pivot = arr[right];
        int index = left - 1;

        for (int i = left; i < right; i++)
        {
            if (arr[i] < pivot)
            {
                index++;
                
                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }

        int temp2 = arr[index + 1];
        arr[index + 1] = arr[right];
        arr[right] = temp2;

        return index + 1;
    }
}