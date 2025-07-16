using UnityEngine;

// Enemy 프리팹을 생성하는 스크립트
public class EnemyManager : MonoBehaviour
{
    private float currentTime;
    
    private float maxTime = 1;
    private float minTime = 5;
    
    public float createTime = 1f;

    public GameObject enemyFactory;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            // 생성
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            
            // 타이머 초기화
            currentTime = 0;
        }
    }
}