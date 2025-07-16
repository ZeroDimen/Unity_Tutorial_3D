using UnityEngine;

// Enemy를 관리하는 스크립트
public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;
    
    void Start()
    {
        GameObject target = GameObject.Find("Player");
        int ranValue = Random.Range(0, 10);

        if (ranValue < 3 && target) // 30% 이며 Player가 존재 할때
        {
            dir = target.transform.position - transform.position;
            dir.Normalize();
            
        }
        else // 70%
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * (speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // 점수 증가
        GameObject smObj = GameObject.Find("ScoreManager"); // 비효율적 (싱글톤으로 해결가능)
        ScoreManager sm = smObj.GetComponent<ScoreManager>();

        var score = sm.GetScore() + 1;
        sm.SetScore(score);
        
        // 보안성 낮음 (ScoreManager score 관련 변수가 public 일때만 가능)
        // sm.currentScoreUI.text = " 현재 점수 : " + sm.currentScore;
        //
        // if (sm.currentScore > sm.bestScore)
        // {
        //     sm.bestScore = sm.currentScore;
        //     sm.bestScoreUI.text = " 최고 점수 : " + sm.bestScore;
        //     
        //     // 최고 점수를 기록하기 위한 로컬 데이터 저장
        //     PlayerPrefs.SetInt("BestScore", sm.bestScore);
        // }
        
        // 파티클 생성
        GameObject expolosion = Instantiate(explosionFactory);
        expolosion.transform.position = transform.position;
        
        // 파괴 기능
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
