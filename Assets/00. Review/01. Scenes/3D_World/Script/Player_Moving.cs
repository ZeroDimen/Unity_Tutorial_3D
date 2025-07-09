using UnityEngine;

// 플레이어를 물리적으로 이동시키는 스크립트
public class Player_Moving : MonoBehaviour
{
    private float moveX; // 키보드로 가로로 이동하기 위한 변수
    private float moveY; // 키보드로 세로로 이동하기 위한 변수
    
    public float moveSpeed; // 플레이어의 이동속도
    public float jumpForce; // 플레이어의 점프힘

    private Rigidbody player_RB;
    
    private void Awake()
    {
        player_RB = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveX  = Input.GetAxisRaw("Horizontal");
        moveY  = Input.GetAxisRaw("Vertical");
        Jump();
    }
    
    private void FixedUpdate()
    {
        Vector3 movement = (transform.forward * moveY + transform.right * moveX).normalized;
        player_RB.linearVelocity = new Vector3(movement.x * moveSpeed, player_RB.linearVelocity.y, movement.z * moveSpeed);
        // player_RB.linearVelocity = movement * moveSpeed;
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_RB.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
        }
    }
}
