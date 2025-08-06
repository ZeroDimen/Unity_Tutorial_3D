using System;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state = new IdleState();
    
    private IState idleState = new IdleState();
    private IState moveState = new MoveState();
    private IState attackState = new AttackState();

    private void Start()
    {
        state.StateEnter();
    }

    private void OnDestroy()
    {
        state.StateExit();
    }

    void Update()
    {
        state?.StateUpdate(); // null인지 확인

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(idleState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(moveState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(attackState);
        }
    }

    public void SetState(IState newState)
    {
        if (state != newState)
        {
            state.StateExit();
            
            state = newState;
            
            state.StateEnter();
        }
        
    }
}