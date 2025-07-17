using UnityEngine;

// 싱글톤 예시
public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 instance
    {
        get; // 접근 가능
        private set; // 수정 불가
    }
    
    private void Awake()
    {
        if (instance == null) // instance가 비어있으면 자신을 할당
        {
            instance = this;
        }
        else // 싱글톤은 유일성을 보장해야하므로 중복일 경우 파괴
        {
            Destroy(gameObject); 
        }
    }
}