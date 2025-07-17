using UnityEngine;

// 싱글톤 예시
public class SingletonEx3 : MonoBehaviour
{
    private static SingletonEx3 instance = new SingletonEx3(); // 내부 변수

    public static SingletonEx3 Instance // 외부 변수
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonEx3();
            }

            return instance;
        }
    }
}