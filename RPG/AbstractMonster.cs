using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    [Serializable]
    internal abstract class AbstractMonster : IMonster
    {
        public string Name { get; }
        public float Health { get; private set; }
        public bool IsAlive { get; private set; }
        public float AttackPower { get; }
        protected abstract string typeName { get; }//Чоби не юзать рефлексию по 100 раз
        public void ReceiveDamage(IActor actor, float Damage)
        {
            try
            {
                ICharacter character = actor as ICharacter ?? throw new NullReferenceException("--ERROR-- actor cannot be null");

                if (this.IsAlive && this.Health <= Damage)
                {
                    this.Health = 0;
                    this.IsAlive = false;

                    Console.WriteLine($"\n --DEATH -- Monster {typeName} receives damage from {character.GetType().Name} and it dies");
                    character.ReceiveExperience(this.XpReward);
                }
                else if (this.IsAlive && this.Health > Damage)
                {
                    this.Health -= Damage;
                    Console.WriteLine($"Monster {typeName} receives {Damage} damage from {character.GetType().Name} and has {this.Health} HP");
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
            this.IsAlive = true;
            this.XpReward = expReward;
        }

    }
}
