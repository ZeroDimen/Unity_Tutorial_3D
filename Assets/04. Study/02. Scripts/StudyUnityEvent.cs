using System;
using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onUnityEvent;

    private void Start()
    {
        onUnityEvent.AddListener(delegate
        {
            Debug.Log("Hello");
            Debug.Log("Unity");
            Debug.Log("World");
            MethodA();
            printLog("Hello");
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onUnityEvent?.Invoke();
        }
    }

    private void MethodA()
    {
        Debug.Log("MethodA");
    }
    private void printLog(string log)
    {
        Debug.Log(log);
    }
}
