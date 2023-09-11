using System;

namespace RPG.Characters
{
    internal class Wizard : AbstractCharacter
    {
        readonly static Dictionary<uint, float> wizardAttackPowerList = new Dictionary<uint, float>()
        {
            {1, 69.0f},
            {2, 78.0f },
            {3, 87.0f },
            {4, 96.0f },
            {5, 105.0f }

    };
        readonly static Dictionary<uint, float> wizardHealthList = new Dictionary<uint, float>()
        {
            {1,45.5f},
            {2,54.0f },
            {3,62.5f },
            {4,71.0f },
            {5,79.5f }

    };
        public Wizard(string Name, float baseAttackPower, float baseHealth) : base(Name, baseAttackPower, baseHealth)
        {
        }
        public override void increaseStats()
        {
            Console.WriteLine($"Character {this.GetType} had {this.AttackPower} attack power and {this.Health} Health");
            float tempAttackPower = 0f;
            float tempHealth = 0f;
            wizardAttackPowerList.TryGetValue(this.Level, out tempAttackPower);
            wizardHealthList.TryGetValue(this.Level, out tempHealth);
            this.AttackPower = tempAttackPower;
            this.Health = tempHealth;
            Console.WriteLine($"Now he has {this.AttackPower} Attack Power and {this.Health} health");

        }
    }
}
