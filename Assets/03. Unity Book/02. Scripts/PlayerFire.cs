using UnityEngine;

// 생성할 오브젝트와 위치를 관리하는 스크립트
public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    // private void Start()
    // {
    //     bulletFactory = Resources.Load<GameObject>("Bullet"); // 리소스 폴더에서 총알 프리펩 로드
    // }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; // 위치 초기화
            // bullet.transform.rotation = firePosition.transform.rotation; // 회전 초기화
        
            // bullet.transform.SetPositionAndRotation(위치, 회전); // 위치와 회전을 한번에 적용하는 기능
        }
    }
}