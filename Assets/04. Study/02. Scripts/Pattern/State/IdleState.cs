using UnityEngine;

public class IdleState : IState
{
    public void StateEnter()
    {
        Debug.Log("Enter Idle");
    }
    public void StateUpdate()
    {
        Debug.Log("Update Idle");
    }

    public void StateExit()
    {
        Debug.Log("Exit Idle");
    }
}