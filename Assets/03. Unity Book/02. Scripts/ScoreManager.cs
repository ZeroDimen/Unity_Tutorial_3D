using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    // 싱글톤 패턴
    public static ScoreManager instance; 
    
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = " 현재 점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = " 최고 점수 : " + bestScore;
            
                // 최고 점수를 기록하기 위한 로컬 데이터 저장
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // 자기 자신으로 초기화
        }
    }
    
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0); // 불러올 값이 없다면 0
        bestScoreUI.text = " 최고 점수 : " + bestScore;
    }
    
}
