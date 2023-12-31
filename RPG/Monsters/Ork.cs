﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    internal class Ork : AbstractMonster
    {
        private static readonly string orkTypeName = typeof(Ork).Name;
        protected override string typeName => orkTypeName;
        public static readonly float spawnProbability = 0.5f;
        public Ork(string name, float health, float attackPower, uint xpReward) : base(name, health, attackPower, xpReward)
        {
            this.AttackProbability = 0.45f;
            this.ApplyDamageProbability = 0.45f;
        }
    }
}
