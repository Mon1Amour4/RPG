

namespace RPG
{
    internal abstract class AbstractCharacter : ICharacter
    {
        //IActor
        public string Name { get; }

        public float Health { get; private set; }

        public bool IsAlive { get; private set; }
        public float AttackPower { get; private set; }
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
        public uint Level { get; }
        public void ReceiveExperience(uint Experience)
        {
            this.Experience += Experience;
            Console.WriteLine($"Character {this.GetType()} receives {Experience} XP ");
        }



        readonly static Dictionary<int, uint> levelUpDictionary = new Dictionary<int, uint>()
        {
            {1, 10},
            {2,20 },
            {3,45 },
            {4,90 },
            {5,140 }
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
