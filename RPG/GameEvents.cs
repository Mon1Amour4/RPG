using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{

    internal static class GameEvents
    {

        public static void DeathAnnouncer(IActor attackingActor, IActor deadActor)
        {
            Console.WriteLine($"--DEAD-- {deadActor.Name} has died");
        }

        public static void ReceiveDamageAnnouncer(IActor attackingActor, IActor affectedActor)
        {
            Console.WriteLine($"{affectedActor.Name} receives damage: {affectedActor.Health} - {attackingActor.AttackPower} --> {affectedActor.Health - attackingActor.AttackPower}");
        }
        public static void LevelUpAnnouncer(ICharacter character)
        {
            Console.WriteLine($"--LVL UP-- Character {character.Name} has Leveled up and now he's {character.Level} LVL\n");
        }

    }
}
