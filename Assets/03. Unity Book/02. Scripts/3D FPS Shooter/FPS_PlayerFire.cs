using System;
using UnityEngine;

public class FPS_PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;

    public GameObject bulletEffect; // 생성하여 사용하는게 아니므로 씬상에 있어야함
    
    public float throwPower = 15f;
    private ParticleSystem ps;

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 레이를 생성한 후 발사될 위치와 진행 방향을 설정
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // 레이가 부딪힌 대상의 정보를 저장할 변수를 생성
            RaycastHit hitInfo = new RaycastHit();
            
            // 레이를 발사한 후 만일 부딪힌 물체가 있으면 피격 이펙트를 표시
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 피격 이펙트의 위치를 레이가 부딪힌 지점으로 이동
                bulletEffect.transform.position = hitInfo.point;
                
                // 피격 이펙트의 forward 방향을 레이가 부딪힌 지점의 법선 벡터와 일치
                bulletEffect.transform.forward = hitInfo.normal;
                
                // 피격 이펙트를 플레이
                ps.Play();
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}