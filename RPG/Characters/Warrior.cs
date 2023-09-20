using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPG.Characters
{
    internal class Warrior : AbstractCharacter
    {
        readonly static Dictionary<uint, float> warriorAttackPowerTable = new Dictionary<uint, float>();
        readonly static Dictionary<uint, float> warriorHealthTable = new Dictionary<uint, float>();

        protected override string typeName => warriorTypeName;
        protected static readonly string warriorTypeName = typeof(Warrior).Name;
        protected override Dictionary<uint, float> HealthTable => warriorHealthTable;
        protected override Dictionary<uint, float> PowerTable => warriorAttackPowerTable;

        static Warrior()
        {
            Deserialization(ref warriorAttackPowerTable, ref warriorHealthTable, warriorTypeName);
        }
        public Warrior(string Name, float baseAttackPower, float baseHealth) : base(Name, baseAttackPower, baseHealth)
        {
            this.AttackProbability = 0.4f;
            this.ApplyDamageProbability = 0.55f;
        }
    }
}
