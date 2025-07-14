using UnityEngine;

// 삽입 정렬의 예시 (이미 정렬된 부분에 새로운 값을 삽입하는 정렬)
public class InsertionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", array)}");
        
        Insertion(array);
        Debug.Log($"정렬 후 : {string.Join(", ", array)}");
    }

    private void Insertion(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
    
}