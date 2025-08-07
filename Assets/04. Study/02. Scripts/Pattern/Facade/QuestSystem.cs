using UnityEngine;

namespace _04._Study._02._Scripts.Pattern.Facade
{
    public class QuestSystem : MonoBehaviour
    {
        public void AddQuest(string questName)
        {
            Debug.Log($"{questName} 획득");
        }
        
        public void HasQuest(string questName)
        {
            Debug.Log($"{questName} 유무");
        }
        
        public void RemoveQuest(string questName)
        {
            Debug.Log($"{questName} 버림");
        }
    }
}