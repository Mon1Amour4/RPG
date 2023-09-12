using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal abstract class AbstractMonster : IMonster
    {
        public string Name { get; }
        public float Health { get; private set; }
        public bool IsAlive { get; private set; }
        public float AttackPower { get; }
        public void ReceiveDamage(ICharacter character, float Damage)
        {
            if (this.IsAlive && this.Health <= Damage)
            {
                this.Health -= Damage;
                this.IsAlive = false;

                Console.WriteLine($"Monster {this.GetType().Name} receives damage from {character.GetType().Name} and it dies");
                character.ReceiveExperience(this.XpReward);
            }
            else if (this.IsAlive && this.Health > Damage)
            {
                this.Health -= Damage;
                Console.WriteLine($"Monster {this.GetType().Name} receives {Damage} damage from {character.GetType().Name} and has {this.Health} HP");
            }
            else
            {
                Console.WriteLine($"Character {this.GetType().Name} cannot receive any damage cause he's dead");
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
