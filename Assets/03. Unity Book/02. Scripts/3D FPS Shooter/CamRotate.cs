using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    public float mx;
    public float my;
    void Update()
    {
        // 게임 상태가 'Run' 상태일 때만 조작할 수 있게함.
        if (FPS_GameManager.instance.gState != FPS_GameManager.GameState.Run)
        {
            return;
        }
        
        // 마우스 입력
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // 회전 값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;
        
        // 마우스 상하 이동 회전 값을 -90~90도 사이로 제한
        my = Mathf.Clamp(my, -90f, 90f);
        // 회전 방향으로 물체를 회전
        transform.eulerAngles = new Vector3(- my, mx, 0);
    }
}
