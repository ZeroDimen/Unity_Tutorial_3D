using UnityEngine;

// Player의 이동을 관리하는 스크립트
public class PlayerMove : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);

        transform.position += dir * (speed * Time.deltaTime);
    }

    // private void Update()
    // {
    //     // 월드 방향 이동
    //     transform.position += Vector3.forward * (Time.deltaTime * 5);
    //     
    //     // 로컬 방향 이동
    //     transform.Translate(Vector3.forward * (Time.deltaTime * 5));
    //     
    //     // 월드 방향 이동
    //     transform.Translate(Vector3.forward * (Time.deltaTime * 5) , Space.World);
    //     
    //     transform.rotation = Quaternion.identity; // (0, 0, 0)
    //     transform.rotation = Quaternion.Euler(new Vector3(30, 60, 120)); // 오일러 -> 쿼터니언
    //
    //     Debug.Log(transform.rotation.eulerAngles); // 쿼터니언 -> 오일러
    //     
    //     var newRotation = transform.rotation.eulerAngles + Vector3.up * (5 * Time.deltaTime);
    //     transform.rotation = Quaternion.Euler(newRotation);
    //
    //     transform.Rotate(Vector3.up * (5 * Time.deltaTime)); // Space.Self
    //     
    //     transform.Rotate(Vector3.up * (5 * Time.deltaTime), Space.World);
    //
    //     transform.RotateAround(Vector3.zero, Vector3.up, 5 * Time.deltaTime);
    //     
    //     transform.LookAt(Vector3.zero);
    //
    // }
   
}
