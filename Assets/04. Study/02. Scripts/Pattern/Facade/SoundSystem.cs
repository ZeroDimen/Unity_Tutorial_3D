using UnityEngine;

namespace _04._Study._02._Scripts.Pattern.Facade
{
    public class SoundSystem : MonoBehaviour
    {
        public void AddSound(string soundName)
        {
            Debug.Log($"{soundName} 획득");
        }
        
        public void HasSound(string soundName)
        {
            Debug.Log($"{soundName} 유무");
        }
        
        public void RemoveSound(string soundName)
        {
            Debug.Log($"{soundName} 버림");
        }
    }
}