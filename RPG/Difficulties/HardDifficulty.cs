using RPG.Interfaces;
using RPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Difficulties
{
    internal class HardDifficulty : ISpawner
    {
        public IMonster Spawn()
        {
            float SpawnOrkProbabily = 0.1f;
            float SpawnDragonProbabily = 0.80f;

            Random random = new Random();
            float rnd = random.Next(0,1);
            if (rnd < SpawnDragonProbabily)
            {
                return new Dragon("Azuremaw", 250f, 75, 150);
            }
            else if (rnd < SpawnDragonProbabily + SpawnOrkProbabily)
            {
                return new Ork("Torbag", 100f, 50f, 50);
            }
            else
            {
                return new Dragon("Azuremaw", 250f, 75, 150);
            }
        }
    }
}
