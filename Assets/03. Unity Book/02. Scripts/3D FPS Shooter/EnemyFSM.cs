using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnermyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    private EnermyState m_State; // 에너미 상태 변수

    public float findDistance = 8.0f; // 플레이어 발견 범위
    public float attackDistance = 3.0f; // 공격 가능 범위
    public float moveSpeed = 5.0f; // 이동 속도
    private float currentTime = 0; // 누적 시간
    private float attackDelay = 2.0f; // 공격 딜레이 시간

    private Vector3 originPos; // 초기 위치 저장용 변수
    public float moveDistance = 20f; // 이동 가능 범위
    
    private Transform player; // 플레이어 트랜스 폼
    private CharacterController cc; // 캐릭터 콘트롤러 컴포넌트

    public int attackPower = 3; // 에너미의 공격력
    public int hp = 15; // 에너미의 채력
    int hpMax = 15;
    public Slider hpSlider;

    private Animator anim;

    private void Start()
    {
        m_State = EnermyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        anim = transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        switch (m_State)
        {
            case EnermyState.Idle:
                Idle();
                break;
            case EnermyState.Move:
                Move();
                break;
            case EnermyState.Attack:
                Attack();
                break;
            case EnermyState.Return:
                Return();
                break;
            case EnermyState.Damaged:
                //Damaged();
                break;
            case EnermyState.Die:
                //Die();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Idle()
    {
        // 플레이어와의 거리가 FindDistance 범위 이내라면 Move로 전환
        if (Vector3.Distance(transform.position,player.position) < findDistance)
        {
            m_State = EnermyState.Move;
            Debug.Log("상태 전환: Idle -> Move");
            anim.SetTrigger("IdleToMove");
        }
    }
    private void Move()
    {
        // 현재 위치가 초기 위치에서 이동 가능 범위를 넘어가면
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnermyState.Return;
            Debug.Log("상태 전환: Move -> Return");
        }
        // 플레이어와의 거리가 공격 범위 밖이라면 플레이어를 향해 이동
        else if (Vector3.Distance(transform.position,player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;

            cc.Move(dir * (moveSpeed * Time.deltaTime));
            
            // 방향을 복귀 지점으로 전환
            transform.forward = dir;
        }
        else
        {
            m_State = EnermyState.Attack;
            Debug.Log("상태 전환: Move -> Attack");
        }
    }
    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                player.GetComponent<FPS_PlayerMove>().DamageAction(attackPower); // 디버깅에 불리함
                currentTime = 0;
                print("공격");
            }
        }
        else
        {
            m_State = EnermyState.Move;
            currentTime = 0;
            Debug.Log("상태 전환: Attack -> Move");
        }
    }
    private void Return()
    {
        // 초기 위치에서의 거리가 0.1f 이상이라면 초기 위치 쪽으로 이동한다.
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * (moveSpeed * Time.deltaTime));
            
            // 방향을 복귀 지점으로 전환
            transform.forward = dir;
        }
        else
        {
            transform.position = originPos;
            hp = hpMax; // 채력 초기화
            hpSlider.value = (float) hp / (float)hpMax;
            m_State = EnermyState.Idle;
            Debug.Log("상태 전환: Return -> Idle");
            anim.SetTrigger("MoveToIdle");
        }
    }
    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }
    private void Die()
    {
        StopAllCoroutines();
        StartCoroutine(DieProcess());
    }

    // 데미지 처리용 코루틴 함수
    IEnumerator DamageProcess()
    {
        // 피격 모션 시간 만큼 기다림
        yield return new WaitForSeconds(0.5f);
        m_State = EnermyState.Move;
        Debug.Log("상태 전환: Damaged -> Move");
    }

    // 데미지 실행 함수
    public void HitEnemy(int hitPower)
    {
        // 이미 피격 상태이거나 사망 상태, 복귀 상태일때는 데미지를 입지 않고 함수 종료
        if (m_State == EnermyState.Damaged || m_State == EnermyState.Die || m_State == EnermyState.Return)
        {
            return;
        }
        
        hp -= hitPower;
        if (hp > 0)
        {
            m_State = EnermyState.Damaged;
            Debug.Log("상태 전환: Ani state -> Damaged");
            Damaged();
        }
        else
        {
            m_State = EnermyState.Die;
            Debug.Log("상태 전환: Ani state -> Die");
            Die();
        }
        hpSlider.value = (float) hp / (float)hpMax;
    }

    IEnumerator DieProcess()
    {
        // 캐릭터 콘트롤러 컴포넌트를 비활성
        cc.enabled = false;
        
        // 2초 뒤 자기자신 제거
        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }
}
