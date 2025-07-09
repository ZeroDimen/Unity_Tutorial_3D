using UnityEngine;

public class Door_Slide : MonoBehaviour
{
    private Animator door_Anim;
    private void Awake()
    {
        door_Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door_Anim.SetTrigger("IsOpen");
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door_Anim.SetTrigger("IsClose");
        }
    }
}
