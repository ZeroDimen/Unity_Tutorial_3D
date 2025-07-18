using UnityEngine;

// 로컬 데이터를 저장하는 스크립트
public class LocalData : MonoBehaviour
{
    private int score;

    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            
            
            // 로컬 데이터 저장
            //PlayerPrefs.SetInt("Key", value);
            // PlayerPrefs.SetFloat("Key", value);
            // PlayerPrefs.SetString("Key", "value");
            
            PlayerPrefs.SetInt("score", score); 
            
            // 로컬 데이터 불러오기
            // PlayerPrefs.GetInt("Key", default);
            int loadScore = PlayerPrefs.GetInt("score", 0);
            
            // 로컬 데이터 지우기
            // PlayerPrefs.DeleteKey("Key");
            // PlayerPrefs.DeleteAll();
        }
    }
}