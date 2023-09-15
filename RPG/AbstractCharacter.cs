using RPG.Characters;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        protected bool IncreaseStat(Dictionary<uint, float> statList, out float tempStatIncrease)
        {

            if (statList != null)
            {
                if (statList.TryGetValue(this.Level, out float value))
                {
                    tempStatIncrease = value;
                    return true;
                }
                tempStatIncrease = 0;
                return false;
            }
            Console.WriteLine(" --ERROR-- Dictionary = null");
            tempStatIncrease = 0;
            return false;
        }

        public void increaseStats()
        {
            float tempAttckPWR = this.AttackPower;
            float tempHEalth = this.Health;
            float temp;

            if (IncreaseStat(PowerTable, out temp))
            {
                this.AttackPower = temp;
            }

            if (IncreaseStat(HealthTable, out temp))
            {
                this.Health = temp;
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
        public void Serialization()
        {
            string jsonAttackPower = JsonSerializer.Serialize(this.PowerTable);
            File.WriteAllText($"C:\\Users\\Dev\\Source\\Repos\\Mon1Amour4\\RPG\\RPG\\Characters\\Tables\\{typeName}AttackPowerTable.json", jsonAttackPower);
            string jsonAttackHealth = JsonSerializer.Serialize(this.HealthTable);
            File.WriteAllText($"C:\\Users\\Dev\\Source\\Repos\\Mon1Amour4\\RPG\\RPG\\Characters\\Tables\\{typeName}HealthTable.json", jsonAttackHealth);
        }

        public static void Deserialization(ref Dictionary<uint, float> powerAttackDictionary, ref Dictionary<uint, float> healthDictionary, string type)
        {
            string basePath = Directory.GetCurrentDirectory();
            string powerTablePath = Path.Combine(basePath, "..", "..", "..", "Characters", "Tables", $"{type}AttackPowerTable.json");
            try
            {
                if (!File.Exists(powerTablePath))
                {
                    throw new FileNotFoundException($"--ERROR-- Couldn't found powerTable file at {powerTablePath}");
                }
                if (powerAttackDictionary == null)
                {
                    throw new Exception("--ERROR-- powerAttackDictionary is Null");
                }

                string AttackPowerTableReadFromJson = File.ReadAllText(powerTablePath);
                powerAttackDictionary = JsonSerializer.Deserialize<Dictionary<uint, float>>(AttackPowerTableReadFromJson) ?? throw new Exception("--ERROR-- Can't deserialize powerTable");

                string healthTablePath = Path.Combine(basePath, "..", "..", "..", "Characters", "Tables", $"{type}HealthTable.json");
                string HealthTableReadFromJson = File.ReadAllText(healthTablePath);

                healthDictionary = JsonSerializer.Deserialize<Dictionary<uint, float>>(HealthTableReadFromJson) ?? throw new Exception("\"--ERROR-- Cant deserialize healthTable");

                if (!File.Exists(healthTablePath))
                {
                    throw new FileNotFoundException($"--ERROR-- Couldn't found healthTable file at {healthTablePath}");
                }
                if (healthDictionary == null)
                {
                    throw new Exception("--ERROR-- healthDictionary is Null");
                }
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
