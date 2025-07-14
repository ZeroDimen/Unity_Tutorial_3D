using UnityEngine;

// 이진탐색의 예시 (배열이 크기 기준으로 정렬되어 있어야 가능)
public class BinarySearch : MonoBehaviour
{
    private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // 정렬된 데이터만 탐색 가능
    public int target = 7;

    private void Start()
    {
        int result = BSearch(); // target의 index 값
        Debug.Log($"{target}는 {result}번째에 있습니다.");
    }

    private int BSearch()
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right) // 끝나는 횟수를 모르기때문에 for 반복문 보다는 while 반복문
        {
            int mid = (left + right) / 2;
            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
               right = mid - 1;
            }
        }

        return 0;
    }
}