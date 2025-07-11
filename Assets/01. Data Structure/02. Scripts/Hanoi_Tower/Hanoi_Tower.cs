using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    
    public TextMeshProUGUI countTextUI;
    public Button answerButton;
    
    public static GameObject selectedDonut;
    public static bool isSelected;
    public static Board_Bar currentBar;
    public static int moveCount;

    private void Awake()
    {
        answerButton.onClick.AddListener(HanoiAnswer);
    }

    private IEnumerator Start()
    {
        for (int i = (int)hanoiLevel; i > 0; i--) // 반복문으로 Level 만큼 도넛 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i - 1]); // 도넛 생성

            donut.transform.position = new Vector3(-5f, 5f, 0);
            
            bars[0].PushDonut(donut); // 방금 생성한 도넛을 해당 Bar의 Stack Push
            moveCount = 0;
            
            yield return new WaitForSeconds(1f); // 순차적으로 생성
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentBar.barStack.Push(selectedDonut);
            
            isSelected = false;
            selectedDonut = null;
        }
        countTextUI.text = moveCount.ToString();
    }

    private void HanoiAnswer()
    {
        HanoiRutine((int)hanoiLevel,0,1,2);
    }
    private void HanoiRutine(int n, int from, int temp, int to)
    {
        if (n == 0) // 도넛을 다 옮긴 상태
        {
            return;
        }

        if (n == 1)
        {
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
        }
        else
        {
            HanoiRutine(n - 1, from, to, temp);
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
            HanoiRutine(n - 1, temp, from, to);
        }
    }
}
