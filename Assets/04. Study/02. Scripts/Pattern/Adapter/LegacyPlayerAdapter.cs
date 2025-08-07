using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class LegacyPlayerAdapter : MonoBehaviour, ICharacter
{
    private LegacyPlayer legacyPlayer;

    private void Awake()
    {
        legacyPlayer = new LegacyPlayer();
    }

    public void Move(Vector3 dir)
    {
        legacyPlayer.LegacyMove(dir.x,dir.y,dir.z);
    }
    
    // public void Move2(Vector3 dir)
    // {
    //     legacyPlayer.transform.positon += dir * Time.deltaTime * speed;
    // }
    

    public void Attack()
    {
        legacyPlayer.LegacyAttack();
    }
}