using System;
using UnityEngine;

// 마우스 입력을 통해 플레이어와 카메라를 회전 시키는 스크립트
public class Player_MouseLook : MonoBehaviour
{
    public Transform playerCamera;

    public float mouseSensitivity; // 마우스 민감도

    // 마우스 회전을 입력 받기위한 변수 X, Y 
    private float mouseX;
    private float mouseY;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 안보이게하는 함수
    }

    void Update()
    {
        MouseInput();
        CamRotation();
    }

    private void FixedUpdate()
    {
        
    }

    private void MouseInput() // 마우스 입력받는 함수
    {

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        // 카메라 뒤집히는것 방지 (상하 회전 각 -90도 ~ 90도 사이로 제한)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    private void CamRotation() // 마우스 입력값을 통해 카메라 및 오브젝트가 회전하는 함수
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // 마우스 회전에 따라 카메라 회전
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // 마우스 회전에 따라 캐릭터 오브젝트 회전
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    public static void ViewCursor(bool isVisible)
    {
        Cursor.lockState = isVisible ? Cursor.lockState = CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
        
    }
}