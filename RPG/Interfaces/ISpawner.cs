using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Interfaces
{
    internal interface ISpawner
    {
        IMonster Spawn();
    }
}
