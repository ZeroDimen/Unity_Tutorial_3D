using System;
using UnityEngine;

public class FPS_PlayerMove : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 7f;
    
    private float gravity = -20f;
    private float yVelocity = 0;
    
    public float jumpPower = 10f;
    public bool isJumping = false;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 안보이게하는 함수
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        
        // 메인 카메라 기준으로 방향을 변환
        dir = Camera.main.transform.TransformDirection(dir);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0;
        }
        
        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }
        
        
        // 캐릭터 수직 속도에 중력 값을 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        
        cc.Move(dir * (moveSpeed * Time.deltaTime));
    }
}