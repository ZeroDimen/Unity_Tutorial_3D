using System;
using UnityEngine;

public class ObserverListner : MonoBehaviour, IObserver
{
    public Subject Subject;

    private void OnEnable()
    {
        Subject.AddObserver(this);
    }

    private void OnDisable()
    {
        Subject.RemoveObserver(this);
    }


    public void Notify()
    {
        Debug.Log("보스 몬스터 처치");
    }

    public void Notify(int score)
    {
        throw new NotImplementedException();
    }
}