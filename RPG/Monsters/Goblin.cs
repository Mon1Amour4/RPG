using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    internal class Goblin : AbstractMonster
    {
        private static readonly string goblinTypeName = typeof(Goblin).Name;
        protected override string typeName => goblinTypeName;
        public static readonly float spawnProbability = 0.65f;
        public Goblin(string name, float health, float attackPower, uint xpReward) : base(name, health, attackPower, xpReward)
        {
            this.AttackProbability = 0.65f;
            this.ApplyDamageProbability = 0.35f;
        }
    }
}
