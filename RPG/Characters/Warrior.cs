using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPG.Characters
{
    //[Serializable]
    internal class Warrior : AbstractCharacter
    {
        readonly static Dictionary<uint, float> warriorAttackPowerTable = new Dictionary<uint, float>()
        {
            {1, 87.5f},
            {2, 100.0f },
            {3, 112.5f },
            {4, 125.0f },
            {5, 137.5f },
            {6, 150.0f }

    };
        readonly static Dictionary<uint, float> warriorHealthTable = new Dictionary<uint, float>()
        {
            {1, 108.0f},
            {2, 126.0f },
            {3, 144.0f },
            {4, 162.0f },
            {5, 180.0f },
            {6, 188.0f }

    };
        protected override string typeName => warriorTypeName;
        protected readonly string warriorTypeName = typeof(Warrior).Name;
        protected override Dictionary<uint, float> HealthTable => warriorHealthTable;
        protected override Dictionary<uint, float> PowerTable => warriorAttackPowerTable;

        public Warrior(string Name, float baseAttackPower, float baseHealth) : base(Name, baseAttackPower, baseHealth)
        {
        }
    }
}
