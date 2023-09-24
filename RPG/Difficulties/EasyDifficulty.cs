using RPG.Interfaces;
using RPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Difficulties
{
    internal class EasyDifficulty : ISpawner
    {
        public IMonster Spawn()
        {
            float SpawnGoblinProbabily = 0.75f;
            float SpawnOrkProbabily = 0.2f;
            Random random = new Random();
            float rnd = random.Next(0, 1);
            if (rnd < SpawnGoblinProbabily)
            {
                return new Goblin("Gnevok", 50f, 25f, 15);
            }
            else if (rnd < SpawnGoblinProbabily + SpawnOrkProbabily)
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
