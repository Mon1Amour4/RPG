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
        readonly static Dictionary<uint, float> rogueAttackPowerList = new Dictionary<uint, float>()
        {
            {1, 32.5f},
            {2, 40.0f },
            {3, 47.5f },
            {4, 55.0f },
            {5, 62.5f }

    };
        readonly static Dictionary<uint, float> rogueHealthList = new Dictionary<uint, float>()
        {
            {1,87.0f},
            {2,99.0f },
            {3,111.0f },
            {4,123.0f },
            {5,135.0f }

    };

        public Rogue(string name, float baseHealth, float baseAttackPower)
            : base(name, baseHealth, baseAttackPower) { }


    }
}