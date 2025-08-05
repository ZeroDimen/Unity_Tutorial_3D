using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    // public delegate void MyDelegate();
    // public MyDelegate myDelegate;
    
    public event Action action; 

    // public delegate void MyDelegate2(string s);
    // public MyDelegate2 myDelegate2;
    
    public Action<string> action2;
    
    public Action <string,int,float, bool> action3;

    private void Start()
    {
        action += () =>
        {
            Debug.Log("Action");
        };
        action?.Invoke();
        
        action2 += msg => Debug.Log(msg);
        action2?.Invoke("Hello World");
    }
}