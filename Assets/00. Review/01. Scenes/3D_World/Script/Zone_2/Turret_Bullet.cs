using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    [SerializeField] private float Bullet_Speed;
    private void Update()
    {
        this.gameObject.transform.localPosition += this.gameObject.transform.up * (Bullet_Speed * Time.deltaTime);
    }
}