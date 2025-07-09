using UnityEngine;

public class SoundManager : MonoBehaviour
{
   private AudioSource audioSource;

   [SerializeField]
   private AudioClip[] bgm;
   [SerializeField]
   private AudioClip[] sfx;


   private void Start()
   {
      audioSource = GetComponent<AudioSource>();
      audioSource.clip = bgm[0];
      audioSource.Play();
   }


   public void SFX_Player(string tag) // 개선필요
   {
      switch (tag)
      {
         case "Coin":
            audioSource.PlayOneShot(sfx[1]);
            break;
         default:
            audioSource.PlayOneShot(sfx[0]);
            break;
      }
   }
}
