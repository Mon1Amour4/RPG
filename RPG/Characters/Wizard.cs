using System;
using System.Text.Json;

namespace RPG.Characters
{
    internal class Wizard : AbstractCharacter
    {
        readonly static Dictionary<uint, float> wizardAttackPowerTable = new Dictionary<uint, float>()
        {
            {1, 69.0f},
            {2, 78.0f },
            {3, 87.0f },
            {4, 96.0f },
            {5, 105.0f },
            {6, 114.0f }

    };
        readonly static Dictionary<uint, float> wizardHealthTable = new Dictionary<uint, float>()
        {
            {1, 45.5f},
            {2, 54.0f },
            {3, 62.5f },
            {4, 71.0f },
            {5, 79.5f },
            {6, 88.0f }

    };

        protected override Dictionary<uint, float> HealthTable => wizardHealthTable;
        protected override Dictionary<uint, float> PowerTable => wizardAttackPowerTable;
        protected override string typeName => wizardTypeName;
        protected readonly string wizardTypeName = typeof(Wizard).Name;
        public Wizard(string Name, float baseAttackPower, float baseHealth) : base(Name, baseAttackPower, baseHealth)
        {
        }
    }
}
