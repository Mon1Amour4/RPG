using RPG.Interfaces;
using RPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Difficulties
{
    internal class MediumDifficulty : ISpawner
    {
        public IMonster Spawn()
        {

            float SpawnGoblinProbabily = 0.2f;
            float SpawnOrkProbabily = 0.60f;
            Random random = new Random();
            double rnd = random.NextDouble();

            if (rnd < SpawnOrkProbabily)
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
