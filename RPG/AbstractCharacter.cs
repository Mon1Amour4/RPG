

using RPG.Characters;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPG
{

    internal abstract class AbstractCharacter : ICharacter
    {
        //IActor
        public string Name { get; }

        public float Health { get; protected set; }

        public bool IsAlive { get; private set; }
        public float AttackPower { get; protected set; }

        protected abstract Dictionary<uint, float> HealthTable { get; }
        protected abstract Dictionary<uint, float> PowerTable { get; }

        protected abstract string typeName { get; } //Чоби не юзать рефлексию по 100 раз

        public void ReceiveDamage(ICharacter character, float Damage)
        {
            if (IsAlive && this.Health <= Damage)
            {
                this.Health = 0;
                this.IsAlive = false;
                Console.WriteLine($"\n --DEATH-- Character {typeName} receives damage: {Damage} from {character.GetType().Name} and he dies");
            }
            else if (IsAlive && this.Health > Damage)
            {
                this.Health -= Damage;
                Console.WriteLine($"Character {typeName} receives damage: {Damage}");
            }
            else
            {
                Console.WriteLine("The Character cannot receive any damage, cause he's dead");
            }
        }


        //ICharacter
        public uint Experience { get; private set; }
        public uint Level { get; private set; }
        public void ReceiveExperience(uint Experience)
        {
            this.Experience += Experience;
            Console.WriteLine($"Character {typeName} receives {Experience} XP ");
            this.levelUp();
        }

        protected float IncreaseStat(Dictionary<uint, float> statList)
        {
            if (statList.TryGetValue(this.Level, out float tempStatIncrease))
            {
                return tempStatIncrease;
            }
            return 0;
        }

        public void increaseStats()
        {
            float tempAttckPWR = this.AttackPower;
            float tempHEalth = this.Health;

            if (IncreaseStat(PowerTable) != 0)
            {
                this.AttackPower = IncreaseStat(PowerTable);
            }
            if (IncreaseStat(HealthTable) != 0)
            {
                this.Health = IncreaseStat(HealthTable);
            }

            Console.WriteLine($"Character had increased he's stats:\nAttack Power: {tempAttckPWR} (+{this.AttackPower - tempAttckPWR}) --> {this.AttackPower}\nHealth: {tempHEalth} (+{this.Health - tempHEalth}) --> {this.Health}");
        }



        virtual public void levelUp()
        {
            uint tempExp = 0;
            uint maxLvl = (uint)levelUpDictionary.Count;

            while (levelUpDictionary.TryGetValue(this.Level, out tempExp))
            {
                if (this.Experience >= tempExp)
                {
                    this.Level++;
                    this.Experience -= tempExp;
                    Console.WriteLine($"\n --LVLUP-- Character {typeName} Had leveled up and now he has {this.Level} Level");
                    this.increaseStats();
                }
                else
                {
                    break;
                }

            }

            if (this.Level >= maxLvl)
            {
                Console.WriteLine($"\nCharacter {this.GetType().Name} has Max Lvl ");
            }
            else
            {
                Console.WriteLine($"He need {tempExp - this.Experience} more for Level upping");
            }

        }

        //Serialization
        public virtual void Serialization()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonAttackPower = JsonSerializer.Serialize(this.PowerTable, options);
            string jsonHealth = JsonSerializer.Serialize(this.HealthTable, options);
            File.WriteAllText($"C:\\Users\\Dev\\source\\repos\\Mon1Amour4\\RPG\\RPG\\Characters\\Tables\\{typeName}AttackPowerTable.json", jsonAttackPower);
            File.WriteAllText($"C:\\Users\\Dev\\source\\repos\\Mon1Amour4\\RPG\\RPG\\Characters\\Tables\\{typeName}HealthTable.json", jsonHealth);
        }

        //Deserialization
        public virtual void Deserialization()
        {
            string jsonAttackPowerTablePath = File.ReadAllText($"C:\\Users\\Dev\\source\\repos\\Mon1Amour4\\RPG\\RPG\\Characters\\Tables\\{typeName}AttackPowerTable.json");
            protected static readonly Dictionary<uint, float>  = new Dictionary<uint, float>;

        string jsonHealthTablePath = File.ReadAllText($"C:\\Users\\Dev\\source\\repos\\Mon1Amour4\\RPG\\RPG\\Characters\\Tables\\{typeName}HealthTable.json");
    }


    readonly static Dictionary<uint, uint> levelUpDictionary = new Dictionary<uint, uint>()
        {
            { 0, 10 },
            { 1, 20 },
            { 2, 30 },
            { 3, 45 },
            { 4, 90 },
            { 5, 140 }
        };
    public AbstractCharacter(string Name, float baseAttackPower, float baseHealth)
    {
        this.Name = Name;
        this.Health = baseHealth;
        this.IsAlive = true;
        this.AttackPower = baseAttackPower;
        this.Experience = 0;
        this.Level = 0;

    }


}
}
