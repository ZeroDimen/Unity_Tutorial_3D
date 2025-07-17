using System.Collections.Generic;
using UnityEngine;

// 생성할 오브젝트와 위치를 관리하는 스크립트
public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    //public GameObject[] bulletObjectPool;
    //public List<GameObject> bulletObjectPool; // 배열 -> 리스트
    public Queue<GameObject> bulletObjectPool; // 리스트 -> 큐

    private void Start()
    {
        // bulletFactory = Resources.Load<GameObject>("Bullet"); // 리소스 폴더에서 총알 프리펩 로드

        // bulletObjectPool = new GameObject[poolSize];
        // bulletObjectPool = new List<GameObject>();
        bulletObjectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            // bulletObjectPool[i] = bullet; // 배열
            // bulletObjectPool.Add(bullet); // 리스트
            bulletObjectPool.Enqueue(bullet); // 큐
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR // 전처리문
        if (Input.GetButtonDown("Fire1")) // 마우스 왼쪽 클릭
        {
            // 큐 방식
            if (bulletObjectPool.Count > 0)
            {
                Debug.Log(bulletObjectPool.Count);
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                
                bullet.transform.position = firePosition.transform.position;
            }

            // 리스트 방식
            // if (bulletObjectPool.Count > 0)
            // {
            //     GameObject bullet = bulletObjectPool[0]; // 가져올 오브젝트 선택
            //     bullet.SetActive(true); // 오브젝트 사용
            //     
            //     bulletObjectPool.Remove(bullet); // Pool에서 오브젝트 제거
            //     
            //     bullet.transform.position = firePosition.transform.position;
            // }

            // 배열 방식
            // GameObject bullet = Instantiate(bulletFactory);
            // bullet.transform.position = firePosition.transform.position; // 위치 초기화
            // bullet.transform.rotation = firePosition.transform.rotation; // 회전 초기화
            // bullet.transform.SetPositionAndRotation(위치, 회전); // 위치와 회전을 한번에 적용하는 기능

            // for (int i = 0; i < poolSize; i++)
            // {
            //     GameObject bullet = bulletObjectPool[i];
            //     if (!bullet.activeSelf) // 선택한 총알 오브젝트가 비활성화 상태인지 확인
            //     {
            //         bullet.SetActive(true); // 총알을 사용하기 위해 활성화
            //         bullet.transform.position = firePosition.transform.position; // 발사 위치 조정
            //         
            //         break; // 반복문 종료
            //     }
            // }
        }
        #elif UNITY_ANDROID || UNITY_IOS
#endif
    }
}