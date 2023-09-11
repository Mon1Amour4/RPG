using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Characters
{
    internal class Warrior : AbstractCharacter
    {
        readonly static Dictionary<uint, float> warriorAttackPowerList = new Dictionary<uint, float>()
        {
            {1, 87.5f},
            {2, 100.0f },
            {3, 112.5f },
            {4, 125.0f },
            {5, 137.5f }

    };
        readonly static Dictionary<uint, float> warriorHealthList = new Dictionary<uint, float>()
        {
            {1,108.0f},
            {2,126.0f },
            {3,144.0f },
            {4,162.0f },
            {5,180.0f }

    };
        public Warrior(string Name, float baseAttackPower, float baseHealth) : base(Name, baseAttackPower, baseHealth)
        {
        }
        public override void increaseStats()
        {
            Console.WriteLine($"Character {this.GetType} had {this.AttackPower} attack power and {this.Health} Health");
            float tempAttackPower = 0f;
            float tempHealth = 0f;
            warriorAttackPowerList.TryGetValue(this.Level, out tempAttackPower);
            warriorHealthList.TryGetValue(this.Level, out tempHealth);
            this.AttackPower = tempAttackPower;
            this.Health = tempHealth;
            Console.WriteLine($"Now he has {this.AttackPower} Attack Power and {this.Health} health");

        }
    }
}
