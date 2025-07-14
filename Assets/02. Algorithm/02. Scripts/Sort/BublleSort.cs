using UnityEngine;

// 버블 정렬의 예시 (배열의 처음부터 끝까지 큰 값을 뒤로 밀어내는 정렬)
public class BublleSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", array)}");
        
        Bubble(array);
        Debug.Log($"정렬 후 : {string.Join(", ", array)}");
    }

    private void Bubble(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}