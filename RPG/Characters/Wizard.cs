using System;
using System.Text.Json;

namespace RPG.Characters
{
    internal class Wizard : AbstractCharacter
    {
        readonly static Dictionary<uint, float> wizardAttackPowerTable = new Dictionary<uint, float>();
        readonly static Dictionary<uint, float> wizardHealthTable = new Dictionary<uint, float>();


        protected override Dictionary<uint, float> HealthTable => wizardHealthTable;
        protected override Dictionary<uint, float> PowerTable => wizardAttackPowerTable;
        protected override string typeName => wizardTypeName;
        protected static readonly string wizardTypeName = typeof(Wizard).Name;
        static Wizard()
        {
            Deserialization(ref wizardAttackPowerTable, ref wizardHealthTable, wizardTypeName);
        }
        public Wizard(string Name, float baseAttackPower, float baseHealth) : base(Name, baseAttackPower, baseHealth)
        {
            this.AttackProbability = 0.5f;
            this.ApplyDamageProbability = 0.6f;
        }
    }
}
