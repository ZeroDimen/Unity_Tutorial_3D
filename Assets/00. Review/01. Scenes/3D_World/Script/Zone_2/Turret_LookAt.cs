using UnityEngine;

public class Turret_LookAt : MonoBehaviour
{
    // 무분별한 [SerializeField] 사용은 'IsInSyncWithParentSerializedObject()' 오류 발생 가능성  
    private Transform Target;
    public Transform Turret_Head;
    public GameObject Turret_Bullet;       
    public Transform[] Turret_FirePos;
    public int T_P_Distance = 15;
    public float timer = 0;
    public float cooldownTime = 1f;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform; // player 태그를 가진 오브젝트를 찾아 Target 오브젝트에 대입
    }

    private void Update()
    {
        if (Vector3.Distance(Turret_Head.position, Target.position) >= T_P_Distance) //Target과 Turret_Head의 거리가 T_P_Distance 보다 멀 경우
        {
            Turret_Head.Rotate(Vector3.up, 80f * Time.deltaTime, Space.World); // Turret_Head가 회전함
            timer = cooldownTime / 2; // 첫 조우시 Shooting() 함수 호출을 보다 빠르게 하기위해
        }
        else // 플레이어태그 오브젝트가 T_P_Distance 보다 가까울 경우
        {
            Turret_Head.LookAt(Target); // 플레이어를 바라보게 하는 함수
            timer += Time.deltaTime;
            
            if (timer >= cooldownTime) // cooldownTime 마다 Shooting() 함수 호출
            {
                Shooting();
                timer = 0f; // 발사 간격 초기화
            }
        }
        
        
    }

    private void Shooting() // bullet 프리펩을 사용하여 bullet을 생성하는 함수
    {
        for (int i = 0; i < Turret_FirePos.Length; i++)
        {
            // bullet 프리펩을 urret_FirePos[i] 위치에 생성하는 함수
            GameObject bullet = Instantiate(Turret_Bullet, Turret_FirePos[i].position, Turret_FirePos[i].rotation); 
            Destroy(bullet, 2f); // bullet 프리펩을 2초뒤 제거 하는 함수 
        }
    }
    
}