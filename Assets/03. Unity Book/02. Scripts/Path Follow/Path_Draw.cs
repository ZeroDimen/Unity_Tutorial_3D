using System;
using UnityEngine;

public class Path_Draw : MonoBehaviour
{
    public float radius = 2f;
    
    public Vector3[] points;

    public Vector3 GetPoint(int index)
    {
        return points[index];
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (i + 1 < points.Length)
            {
                // 점들을 이어 파란선으로 그림
                Debug.DrawLine(points[i], points[i + 1], Color.blue);
            }
        }
    }
}
