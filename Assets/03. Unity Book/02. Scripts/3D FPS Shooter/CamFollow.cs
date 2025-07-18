using System;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        // 카메라 위치를 목표 트랜스폼의 위치에 일치
        transform.position = target.position;
    }
}