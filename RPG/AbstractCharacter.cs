

namespace RPG
{
    internal abstract class AbstractCharacter : ICharacter
    {
        //IActor
        virtual public string Name { get; private set; }

        public int Health { get; }

        public bool IsAlive { get; }
        public uint AttackPower { get; }
        abstract public void ReceiveDamage(IActor actor, uint Damage);


        //ICharacter
        public uint Experience { get; }
        public uint Level { get; }
        abstract public void ReceiveExperience(uint Experience);



        readonly static Dictionary<int, uint> levelUpDictionary = new Dictionary<int, uint>()
        {
            {1, 10},
            {2,20 },
            {3,45 },
            {4,90 },
            {5,140 }
        };

        public AbstractCharacter(string Name, Dictionary<uint, uint> attackPowerList, Dictionary<uint, int> healthList)
        {
            this.Name = Name;
            this.Health = healthList[0];
            this.IsAlive = true;
            this.AttackPower = attackPowerList[0];
            this.Experience = 0;
            this.Level = 0;

        }

    }
}
