using System;
using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler(string msg);

    public event InputKeyHandler onInputKey; // 외부에서 델리게이트 실행 방지
    // public InputKeyHandler onInputKey;
    
    private void Start()
    {
        // onInputKey += InputKeyEvent;
        onInputKey += delegate
        {
            InputKeyEvent("Hello");
            InputKeyEvent("World");
        };
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onInputKey?.Invoke("Hello Unity");
        }
    }

    private void InputKeyEvent(string msg)
    {
        Debug.Log(msg);
    }
}
