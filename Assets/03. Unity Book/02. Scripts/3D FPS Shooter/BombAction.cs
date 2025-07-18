using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect);
        
        eff.transform.position = transform.position;
        
        // 자기 자신 제거
        Destroy(this.gameObject);
    }
}