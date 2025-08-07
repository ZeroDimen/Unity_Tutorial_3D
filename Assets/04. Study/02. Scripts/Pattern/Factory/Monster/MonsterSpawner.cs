using System;
using UnityEngine;

namespace Pattern.Monster
{
    public class MonsterSpawner : MonoBehaviour
    {
        private MonsterFactory currentFactory = null;
        private Monster currentMonster = null;
            
        private GoblinFactory goblinFactory = null;
        private OrcFactory orcFactory = null;

        private void Awake()
        {
            goblinFactory = new GameObject("Goblin Factory").AddComponent<GoblinFactory>();
            orcFactory = new GameObject("Orc Factory").AddComponent<OrcFactory>();
        }


        private void Start()
        {
            currentFactory = goblinFactory;
            currentMonster = currentFactory.SpawnMonster("Normal");
            currentMonster = currentFactory.SpawnMonster("Warrior");
            currentMonster = currentFactory.SpawnMonster("Archer");
            
            currentFactory = orcFactory;
            currentMonster = currentFactory.SpawnMonster("Normal");
            currentMonster = currentFactory.SpawnMonster("Warrior");
            currentMonster = currentFactory.SpawnMonster("Archer");
            
        }
    }
}