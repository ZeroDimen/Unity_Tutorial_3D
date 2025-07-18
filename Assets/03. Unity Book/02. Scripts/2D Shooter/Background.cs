using UnityEngine;

// 배경을 오프셋 효과를 통해 반복효과를 주는 스크립트
public class Background : MonoBehaviour
{
    public Material bgMaterial;

    public float scrollSpeed = 0.2f;

    void Update()
    {
        Vector2 direction = Vector2.up;

        bgMaterial.mainTextureOffset += direction * (scrollSpeed * Time.deltaTime);
    }
}