using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.5f;
    public float currentTime = 0;

    void Update()
    {
        if (currentTime > destroyTime)
        {
            Destroy(this.gameObject);
        }
        currentTime += Time.deltaTime;
    }
}