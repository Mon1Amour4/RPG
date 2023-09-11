

using RPG.Characters;

namespace RPG
{
    internal abstract class AbstractCharacter : ICharacter
    {
        //IActor
        public string Name { get; }

        public float Health { get; protected set; }

        public bool IsAlive { get; private set; }
        public float AttackPower { get; protected set; }
        public void ReceiveDamage(IActor actor, float Damage)
        {
            if (IsAlive && this.Health <= Damage)
            {
                this.Health -= Damage;
                this.IsAlive = false;
                ;
                Console.WriteLine($"Character {this.GetType()} receives damage: {Damage} from {actor.GetType()} and he dies");
            }
            else if (IsAlive && this.Health > Damage)
            {
                this.Health -= Damage;
                Console.WriteLine($"Character {this.GetType()} receives damage: {Damage}");
            }
            else
            {
                Console.WriteLine("The Character cannot receive any damage, cause he's dead");
            }
        }


        //ICharacter
        public uint Experience { get; set; }
        public uint Level { get; private set; }
        public void ReceiveExperience(uint Experience)
        {
            this.Experience += Experience;
            Console.WriteLine($"Character {this.GetType()} receives {Experience} XP ");
            this.levelUp();
        }
        abstract public void increaseStats();

        virtual public void levelUp()
        {
            uint tempExp = 0;
            for (int i = 0; i < AbstractCharacter.levelUpDictionary.Count; i++)
            {

                AbstractCharacter.levelUpDictionary.TryGetValue(this.Level, out tempExp);
                {
                    if (this.Experience >= tempExp)
                    {
                        this.Level += 1;
                        this.Experience -= tempExp;
                        Console.WriteLine($"Character {this.GetType()} Had leveled up and now he has {this.Level} Level");
                        this.increaseStats();
                    }
                }
            }

            Console.WriteLine($"He need {tempExp - this.Experience} more for Level upping");



        }

        readonly static Dictionary<uint, uint> levelUpDictionary = new Dictionary<uint, uint>()
        {
            {0,10 },
            {1, 20},
            {2,30 },
            { 3,45 },
            { 4,90 },
            { 5,140 }
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
