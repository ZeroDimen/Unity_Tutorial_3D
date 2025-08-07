using UnityEngine;

namespace Pattern.Monster
{
    public abstract class MonsterFactory : MonoBehaviour
    {
        public Monster SpawnMonster(string type)
        {
            Monster monster = CreatMonster(type);
            return monster;
        }

        public abstract Monster CreatMonster(string type);
    }
}