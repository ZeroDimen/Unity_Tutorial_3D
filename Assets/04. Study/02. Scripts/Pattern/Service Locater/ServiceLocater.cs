using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocater : MonoBehaviour
{
    private Dictionary<Type, object> serveices = new Dictionary<Type, object>();

    public T GetService<T>() where T : class
    {
        if (serveices.TryGetValue(typeof(T), out var service))
        {
            return service as T;
        }
        return null;
    }

    public void RegisterService<T>(T service)
    {
        serveices[typeof(T)] = service;
    }

    public void UnregisterService<T>()
    {
        serveices.Remove(typeof(T));
    }
}