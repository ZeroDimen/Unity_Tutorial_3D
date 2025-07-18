using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    public float mx;
    void Update()
    {
        // 마우스 입력
        float mouse_X = Input.GetAxis("Mouse X");

        // 회전 값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;
        
        // 회전 방향으로 물체를 회전
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}