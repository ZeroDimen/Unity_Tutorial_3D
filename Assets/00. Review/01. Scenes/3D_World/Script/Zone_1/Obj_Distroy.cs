using UnityEngine;

public class Obj_Distroy : MonoBehaviour
{
    [SerializeField] private SoundManager soundManaer;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(tag);
            soundManaer.SFX_Player(this.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
