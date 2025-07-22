using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPS_PlayerMove : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 7f;
    
    private float gravity = -20f;
    private float yVelocity = 0;
    
    public float jumpPower = 10f;
    public bool isJumping = false;

    public int hp = 20;

    int maxHp = 20;
    public Slider hpSlider;

    public GameObject hitEffect;

    private Animator anim;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 안보이게하는 함수
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // 게임 상태가 'Run' 상태일 때만 조작할 수 있게함.
        if (FPS_GameManager.instance.gState != FPS_GameManager.GameState.Run)
        {
            return;
        }
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        anim.SetFloat("MoveMotion",dir.magnitude);
        
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

    public void DamageAction(int damage)
    {
        // 에너마의 공격력 만큼 플레이어의 체력을 깎는다.
        hp -= damage;
        
        hpSlider.value = (float)hp / (float)maxHp;

        if (hp > 0)
        {
            // 피격 이펙트 코루틴 시작
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}