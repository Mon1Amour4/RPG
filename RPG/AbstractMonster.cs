
namespace RPG
{
    [Serializable]
    internal abstract class AbstractMonster : IMonster
    {
        public string Name { get; }

        public float Health { get; private set; }
        public bool IsAlive { get; private set; }
        public float AttackPower { get; }
        public float AttackProbability { get; protected set; }
        public float ApplyDamageProbability { get; protected set; }
        protected abstract string typeName { get; }//Чоби не юзать рефлексию по 100 раз

        public event Action<IActor, IActor> DeathAnnounce;
        public event Action<IActor, IActor> ReceiveDamageAnnounce;

        public void ReceiveDamage(IActor actor, float Damage)
        {
            try
            {
                ICharacter character = actor as ICharacter ?? throw new NullReferenceException("--ERROR-- actor cannot be null");

                if (this.IsAlive && this.Health <= Damage)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                    DeathAnnounce?.Invoke(actor, this);
                    character.ReceiveExperience(this.XpReward);
                }
                else if (this.IsAlive && this.Health > Damage)
                {
                    ReceiveDamageAnnounce?.Invoke(actor, this);
                    this.Health -= Damage;
                }
                else
                {
                    Console.WriteLine($"Character {typeName} cannot receive any damage cause he's dead");
                }
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public uint XpReward { get; }
        public AbstractMonster(string name, float health, float attackPower, uint expReward)
        {
            this.Name = name;
            this.Health = health;
            this.AttackPower = attackPower;
            this.AttackProbability = 0;
            this.ApplyDamageProbability = 0;
            this.IsAlive = true;
            this.XpReward = expReward;
            this.DeathAnnounce += GameEvents.DeathAnnouncer;
            this.ReceiveDamageAnnounce += GameEvents.ReceiveDamageAnnouncer;
        }

    }
}
