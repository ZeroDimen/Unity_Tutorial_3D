using UnityEngine;

namespace Pattern.Monster
{
    public class OrcFactory : MonsterFactory
    {
        public override Monster CreatMonster(string type)
        {
            switch (type)
            {
                case "Normal":
                    return new GameObject("Orc").AddComponent<Orc>();
                    break;
                case "Warrior":
                    return new GameObject("Orc Warrior").AddComponent<OrcWarrior>();
                    break;
                case "Archer":
                    return new GameObject("Orc Archer").AddComponent<OrcArcher>();
                    break;
                default:
                    return null;
            }
        }
    }
}