using System;
using UnityEngine;

// 싱글톤 예시
public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance;

    public static SingletonEx5 Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindFirstObjectByType<SingletonEx5>();
                if (obj != null) // 찾은 경우
                {
                    instance = obj;
                }
                else // 못 찾은 경우
                {
                    var newObj = new GameObject("SingletonEx5"); // SingletonEx5 라는 이름의 오브젝트 생성
                    newObj.AddComponent<SingletonEx5>();
                    
                    instance = newObj.GetComponent<SingletonEx5>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null) // 할당 해서 싱글톤화
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // 중복 제거
        {
            Destroy(gameObject);
        }
            
    }
}