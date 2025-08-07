using UnityEngine;

namespace Pattern.Monster
{
    public class GoblinFactory : MonsterFactory
    {
        public override Monster CreatMonster(string type)
        {
            switch (type)
            {
                case "Normal":
                    return new GameObject("Goblin").AddComponent<Goblin>();
                    break;
                case "Warrior":
                    return new GameObject("Goblin Warrior").AddComponent<GoblinWarrior>();
                    break;
                case "Archer":
                    return new GameObject("Goblin Archer").AddComponent<GoblinArcher>();
                    break;
                default:
                    return null;
            }
        }
    }
}