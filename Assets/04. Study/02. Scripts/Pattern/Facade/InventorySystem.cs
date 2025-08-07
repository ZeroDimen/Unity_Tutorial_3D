using UnityEngine;

namespace _04._Study._02._Scripts.Pattern.Facade
{
    public class InventorySystem : MonoBehaviour
    {
        public void AddItem(string itemName)
        {
            Debug.Log($"{itemName} 획득");
        }
        
        public void HasItem(string itemName)
        {
            Debug.Log($"{itemName} 유무");
        }
        
        public void RemoveItem(string itemName)
        {
            Debug.Log($"{itemName} 버림");
        }
    }
}