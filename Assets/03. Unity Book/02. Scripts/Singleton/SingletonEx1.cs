using UnityEngine;

// 싱글톤 예시
public class SingletonEx1 : MonoBehaviour
{
    public static SingletonEx1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}