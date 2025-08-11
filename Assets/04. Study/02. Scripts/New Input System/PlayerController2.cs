using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController2 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        private PlayerInput playerInput;
        private InputAction moveAction;
        private InputAction jumpAction;
        
        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            cc = GetComponent<CharacterController>();
            
            moveAction = playerInput.actions.FindAction("Move");
            jumpAction = playerInput.actions.FindAction("Jump");
            
        }

        private void OnEnable()
        {
            moveAction.Enable();
            moveAction.started += Move;
            moveAction.canceled += Move;
            
            jumpAction.Enable();
            jumpAction.performed += Jump;
        }

        private void OnDisable()
        {
            moveAction.Disable();
            moveAction.started -= Move;
            moveAction.canceled -= Move;
            
            jumpAction.Disable();
            jumpAction.performed -= Jump;
        }

        void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y);

            cc.Move(dir * (speed * Time.deltaTime));
        }

        public void Move(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void MoveCancel(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }

        public void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("Jump");
        }
    }
}
