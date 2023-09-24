using System;
using System.Collections.Generic;


namespace RPG
{
    internal interface IMonster : IActor
    {
        uint XpReward { get; }

    }
}
