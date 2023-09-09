using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Characters
{
    internal class Rogue : AbstractCharacter
    {
        //IActor
        public string Name { get; private set; }
        public override uint Health
        {
            get { return this.Health; }
            set
            {

                if (IsAlive)
                {
                    this.Health = value;

                }
                else
                {
                    Console.WriteLine("IsAlive = false");

                }
            }
        }


        private bool IsAlive
        {
            get
            {
                return Health > 0;
            }

        }
        public override uint AttackPower
        {
            get { return AttackPower; }
        }
        public override void ReceiveDamage(IActor actor, uint Damage)
        {
            if (IsAlive)
            {
                actor.Health -= Damage;
            }
            else
            {
                Console.WriteLine("Char is dead, he doesn't receive any damage");
            }
        }

        //ICharacter
        public override uint Experience
        {
            get
            {
                return this.Experience;
            }
        }

        public override uint Level
        {
            get
            {
                return this.Level;
            }
        }

        public override void ReceiveExperience(uint Experience)
        {
            Rogue.Experience += Experience;
        }

        readonly static Dictionary<uint, uint> rogueAttackPower = new Dictionary<uint, uint>()
        {
            {1,25},
            {2,35 },
            {3,54 },
            {4,65 },
            {5,88 }

    };
        readonly static Dictionary<uint, uint> rogueHealth = new Dictionary<uint, uint>()
        {
            {1,100},
            {2,125 },
            {3,150 },
            {4,175 },
            {5,200 }

    };

        public Rogue(string name, Dictionary<uint, uint> rogAttList, Dictionary<uint, uint> rogHelthList)
            : base(name, rogAttList, rogHelthList)
        {



        }
    }
}