

using RPG.Characters;
using System.Diagnostics;

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

        public void ReceiveDamage(ICharacter character, float Damage)
        {
            if (IsAlive && this.Health <= Damage)
            {
                this.Health -= Damage;
                this.IsAlive = false;
                Console.WriteLine($"\n --DEATH-- Character {this.GetType().Name} receives damage: {Damage} from {character.GetType().Name} and he dies");
            }
            else if (IsAlive && this.Health > Damage)
            {
                this.Health -= Damage;
                Console.WriteLine($"Character {this.GetType().Name} receives damage: {Damage}");
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
            Console.WriteLine($"Character {this.GetType().Name} receives {Experience} XP ");
            this.levelUp();
        }

        protected float IncreaseStat(Dictionary<uint, float> statList)
        {
#warning тут подумать 
            try
            {
                statList.TryGetValue(this.Level, out float tempStatIncrease);
                return tempStatIncrease;

            }
            catch (KeyNotFoundException ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void increaseStats()
        {
            float tempAttckPWR = this.AttackPower;
            float tempHEalth = this.Health;

            try
            {
                this.AttackPower = IncreaseStat(PowerTable);
                this.Health = IncreaseStat(HealthTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Character had increased he's stats:\nAttack Power: {tempAttckPWR} (+{this.AttackPower - tempAttckPWR}) --> {this.AttackPower}\nHealth: {tempHEalth} (+{this.Health - tempHEalth}) --> {this.Health}");
        }

        virtual public void levelUp()
        {
            uint tempExp = 0;
            uint maxLvl = (uint)levelUpDictionary.Count;
            try
            {
                levelUpDictionary.TryGetValue(this.Level, out tempExp);
                while (this.Experience >= tempExp && this.Level <= levelUpDictionary.Count - 1)
                {
                    {
                        if (this.Experience >= tempExp)
                        {
                            this.Level++;
                            this.Experience -= tempExp;
                            Console.WriteLine($"\n --LVLUP-- Character {this.GetType().Name} Had leveled up and now he has {this.Level} Level");
                            this.increaseStats();
                        }
                    }
                }
            }
            catch (KeyNotFoundException ex)
            {

                throw new Exception(ex.Message);
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
