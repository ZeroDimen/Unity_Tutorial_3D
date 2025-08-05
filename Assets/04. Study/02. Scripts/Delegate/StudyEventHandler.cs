using UnityEngine;
using System;

public class StudyEventHandler : MonoBehaviour
{
    public event EventHandler handler; // 매개변수가 있는 델리게이터 타입
    public event EventHandler Handler
    {
        add
        {
            Debug.Log($"{value.Method} 추가됨");
            handler += value;
        }
        remove
        {
            Debug.Log($"{value.Method} 삭제됨");
            handler -= value;
        }
    }

    void OnEnable()
    {
        Handler += MethodA;
    }

    void OnDisable()
    {
        Handler -= MethodA;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handler?.Invoke(this, EventArgs.Empty);
        }
    }

    private void MethodA(object o, EventArgs e)
    {
        Debug.Log("MethodA");
    }
}