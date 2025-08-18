using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class Farm_PlayerController : MonoBehaviour
    {
        private Animator anim;
        
        private CharacterController cc;
        private Vector3 moveInput;
        private bool isRun;

        private float currentSpeed;
        private float velocityY; 
        
        private float walkSpeed = 5f;
        private float runSpeed = 10f;
        private float turnSpeed = 10f;
        public float jumpSpeed = 10f;
        private int jumpCountcurr = 0;
        private int jumpCountMax = 1;
        
        public float GRAVITY = -9.8f; // 가상 중력을 구현하기 위한 변수


        private void Awake()
        {
            int characterIndex = LoadSceneManager.Instance.characterIndex;
            transform.GetChild(characterIndex).gameObject.SetActive(true);
            anim = transform.GetChild(characterIndex).GetComponentInChildren<Animator>();
            cc = GetComponent<CharacterController>();
        }
        
        void Update()
        {
            Vector3 move2Dir = moveInput * currentSpeed;
            
            if (cc.isGrounded)
            {
                velocityY = 0f;
                jumpCountcurr = 0;
            }
            else
            {
                velocityY += GRAVITY * Time.deltaTime;
            }
            
            Vector3 move3Dir = new Vector3(move2Dir.x, velocityY, move2Dir.z);

            cc.Move(move3Dir * Time.deltaTime);
            Turn();
            SetAnimation();
        }

        private void OnMove(InputValue value)
        {
            var move = value.Get<Vector2>();
            moveInput = new Vector3(move.x, 0, move.y);
        }

        private void Turn()
        {
            if (moveInput != Vector3.zero) 
            {
                Quaternion targetRot = Quaternion.LookRotation(moveInput);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
            }
        }

        private void OnJump(InputValue value)
        {
            if (jumpCountMax > jumpCountcurr) // cc.isGrounded 사용시 키 씹힘현상 발생
            {
                velocityY = Mathf.Sqrt(jumpSpeed * -2.0f * GRAVITY);
                jumpCountcurr++;
            }
        }

        private void OnRun(InputValue value)
        {
            isRun = value.isPressed;
        }

        private void SetAnimation()
        {
            float targetValue = 0f;
            if (moveInput != Vector3.zero) // 이동 중일 경우
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = isRun ? runSpeed : walkSpeed;
            }

            float animValue = anim.GetFloat("Move");
            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);
            
            anim.SetFloat("Move", animValue);
        }
    }
}

