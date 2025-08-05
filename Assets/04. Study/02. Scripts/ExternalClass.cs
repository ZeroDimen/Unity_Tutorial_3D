using System;
using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    // private StudyUnityEvent studyUnityEvent;
    //
    // private void Awake()
    // {
    //     studyUnityEvent = FindFirstObjectByType<StudyUnityEvent>();
    // }
    //
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         // studyUnityEvent.onUnityEvent?.Invoke();
    //     }
    // }

    private void Start()
    {
        StudySingleton.instance.number = 10;
    }
}
