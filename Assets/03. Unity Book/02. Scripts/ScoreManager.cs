using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;

    private void Start()
    {

        bestScore = PlayerPrefs.GetInt("BestScore", 0); // 불러올 값이 없다면 0
        bestScoreUI.text = " 최고 점수 : " + bestScore;
    }

    public void SetScore(int value)
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

    public int GetScore()
    {
        return currentScore;
    }
}
