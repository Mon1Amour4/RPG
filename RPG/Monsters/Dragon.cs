using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    internal class Dragon : AbstractMonster
    {

        public Dragon(string name, float health, float attackPower, uint xpReward) : base(name, health, attackPower, xpReward)
        {

        }


    }
}
