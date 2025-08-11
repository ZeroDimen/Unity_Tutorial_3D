using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;

    private Vector2 moveInput;
    public float speed = 5f;

    public InputActionAsset inputActionAsset;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction interactionAction;
    private InputAction attackAction;

    private void awake()
    {
        cc = GetComponent<CharacterController>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactionAction = inputActionAsset.FindAction("Interaction");
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            Debug.Log("Move : " + moveAction.ReadValue<Vector2>());
            var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

            cc.Move(dir * (speed * Time.deltaTime));
        }

        // jumpAction.IsPressed(); // 여러번 실행
        if (jumpAction.WasPressedThisFrame()) // 한번 실행
        {
            Debug.Log("Jump");
        }

        if (interactionAction.WasPressedThisFrame())
        {
            Debug.Log("Interaction");
        }

        if (attackAction.WasPressedThisFrame())
        {
            Debug.Log("Attack");
        }

    }
}
