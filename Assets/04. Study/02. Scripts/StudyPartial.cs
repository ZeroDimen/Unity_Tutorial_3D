using System;
using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    private void Start()
    {
        MethodA();
        MethodB();
    }

    private void MethodA()
    {
        Debug.Log("MethodA");
    }
    
    
}

public partial class StudyPartial : MonoBehaviour
{
    private void MethodB()
    {
        Debug.Log("MethodB");
    }
}
