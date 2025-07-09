using System.Collections;
using UnityEngine;

public class Hanoi_Tower : MonoBehaviour
{
    public enum HanoiLevel
    {
        Level1 = 3,
        Level2,
        Level3
    }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public Board_Bar[] bars; // Left, Center, Right 순서

    public static GameObject selectedDonut;
    public static bool isSelected;
    
    private IEnumerator Start()
    {
        for (int i = (int)hanoiLevel; i > 0; i--) // 반복문으로 Level 만큼 도넛 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i - 1]); // 도넛 생성

            donut.transform.position = new Vector3(-5f, 5f, 0);
            
            bars[0].PushDonut(donut); // 방금 생성한 도넛을 해당 Bar의 Stack Push
            
            yield return new WaitForSeconds(1f); // 순차적으로 생성
        }
    }
}
