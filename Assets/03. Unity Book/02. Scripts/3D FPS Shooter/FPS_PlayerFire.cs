using System.Collections;
using TMPro;
using UnityEngine;

public class FPS_PlayerFire : MonoBehaviour
{
    private enum WeaponMode {Normal, Sniper}

    private WeaponMode wMode;
    
    public GameObject firePosition;
    public GameObject bombFactory;

    public GameObject bulletEffect; // 생성하여 사용하는게 아니므로 씬상에 있어야함
    
    public float throwPower = 15f;
    private ParticleSystem ps;
    public TextMeshProUGUI wModeText;

    public int weaponPower = 5;
    
    private Animator anim;
    
    private bool zoomMode = false;

    public GameObject[] eff_Flash;
    
    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }

    private void Update()
    {
        // 게임 상태가 'Run' 상태일 때만 조작할 수 있게함.
        if (FPS_GameManager.instance.gState != FPS_GameManager.GameState.Run)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootEffectOn(0.05f));
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }
            // 레이를 생성한 후 발사될 위치와 진행 방향을 설정
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // 레이가 부딪힌 대상의 정보를 저장할 변수를 생성
            RaycastHit hitInfo = new RaycastHit();
            
            // 레이에 부딪힌 대상의 레이어가 "Enemy" 라면 데미지 함수 실행
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // 레이를 발사한 후 만일 부딪힌 물체가 있으면 피격 이펙트를 표시
                {
                    // 피격 이펙트의 위치를 레이가 부딪힌 지점으로 이동
                    bulletEffect.transform.position = hitInfo.point;
                
                    // 피격 이펙트의 forward 방향을 레이가 부딪힌 지점의 법선 벡터와 일치
                    bulletEffect.transform.forward = hitInfo.normal;
                
                    // 피격 이펙트를 플레이
                    ps.Play();
                }
                
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {

            switch (wMode)
            {
                case WeaponMode.Normal: // 일반 모드일 때 마우스 오른쪽 -> 폭탄 투척
                    
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                    
                    
                    break;
                case WeaponMode.Sniper: // 저격 모드일 때 마우스 오른쪽 -> 확대 / 축소 조준경
                    // if (!zoomMode)
                    // {
                    //     Camera.main.fieldOfView = 15f;
                    //     zoomMode = true;
                    // }
                    // else
                    // {
                    //     Camera.main.fieldOfView = 60f;
                    //     zoomMode = false;
                    // }

                    float fov = zoomMode ? 60f : 15f;
                    Camera.main.fieldOfView = fov;
                    zoomMode = !zoomMode;
                    
                    break;
                default:
                    break;
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "Normal Mode";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;
            wModeText.text = "Sniper Mode";
        }
    }

    IEnumerator ShootEffectOn(float duration) // 총구 이펙트 코루틴 함수
    {
        
        int num = Random.Range(0, eff_Flash.Length -1);
        eff_Flash[num].SetActive(true);
        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}