using System;
using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    public static StudySingleton instance;
    public int number;
    
    private void Start()
    {
        instance = this;
    }
}