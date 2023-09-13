using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    internal class Dragon : AbstractMonster
    {
        private static readonly string dragonTypeName = typeof(Dragon).Name;
        protected override string typeName => dragonTypeName;
        public Dragon(string name, float health, float attackPower, uint xpReward) : base(name, health, attackPower, xpReward)
        {

        }


    }
}
