
namespace _04._Study._02._Scripts.Pattern.Facade
{
    public class GameFacade : Singleton<GameFacade>
    {
        private InventorySystem inventorySystem;
        private QuestSystem questSystem;
        private SoundSystem soundSystem;

        
        void Awake()
        {
            inventorySystem = GetComponent<InventorySystem>();
            questSystem = GetComponent<QuestSystem>();
            soundSystem = GetComponent<SoundSystem>();

            if (inventorySystem == null)
                inventorySystem = gameObject.AddComponent<InventorySystem>();

            if (questSystem == null)
                questSystem = gameObject.AddComponent<QuestSystem>();

            if (soundSystem == null)
                soundSystem = gameObject.AddComponent<SoundSystem>();
        }

        public void ItemEvent(int index, string itemName)
        {
            if (index == 0)
            {
                inventorySystem.AddItem(itemName);
            }
            else if (index == 1)
            {
                inventorySystem.HasItem(itemName);
            }
            else if (index == 2)
            {
                inventorySystem.RemoveItem(itemName);
            }
        }
        
        public void QuestEvent(int index, string questName)
        {
            if (index == 0)
            {
                questSystem.AddQuest(questName);
            }
            else if (index == 1)
            {
                questSystem.HasQuest(questName);
            }
            else if (index == 2)
            {
                questSystem.RemoveQuest(questName);
            }
        }
        
        public void SoundEvent(int index, string questName)
        {
            if (index == 0)
            {
                soundSystem.AddSound(questName);
            }
            else if (index == 1)
            {
                soundSystem.HasSound(questName);
            }
            else if (index == 2)
            {
                soundSystem.RemoveSound(questName);
            }
        }
    }
}