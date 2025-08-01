using System;
using UnityEngine;

public class Set_Time : MonoBehaviour
{
    public Light light_Dir;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            light_Dir.transform.Rotate(0,20f,0);
        }
    }

    private void FixedUpdate()
    {
        light_Dir.transform.Rotate(0,0.1f,0);
    }
}
