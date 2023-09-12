

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

        public void ReceiveDamage(IActor actor, float Damage)
        {
            if (IsAlive && this.Health <= Damage)
            {
                this.Health -= Damage;
                this.IsAlive = false;
                ;
                Console.WriteLine($"Character {this.GetType().Name} receives damage: {Damage} from {actor.GetType().Name} and he dies");
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

        protected float increaseStat(Dictionary<uint, float> statList)
        {
            if (statList.TryGetValue(this.Level, out float tempStatIncrease))
            {
                return tempStatIncrease;
            }
            else
            {
                throw new Exception("Все плохо"); // нормально сделать
            }
        }

        public void increaseStats()
        {
            Console.WriteLine($"Character had {this.AttackPower} attack power and {this.Health} Health");
            try
            {
                this.AttackPower = increaseStat(PowerTable);
                this.Health = increaseStat(HealthTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Now he has {this.AttackPower} Attack Power and {this.Health} health");
        }

        virtual public void levelUp()
        {
            uint tempExp = 0;
            for (int i = 0; i < levelUpDictionary.Count; i++) // переписать на while
            {
                levelUpDictionary.TryGetValue(this.Level, out tempExp);
                {
                    if (this.Experience >= tempExp)
                    {
                        this.Level++;
                        this.Experience -= tempExp;
                        Console.WriteLine($"Character {this.GetType().Name} Had leveled up and now he has {this.Level} Level");
                        this.increaseStats();
                    }
                }
            }

            Console.WriteLine($"He need {tempExp - this.Experience} more for Level upping");
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
