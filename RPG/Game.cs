using RPG.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using static RPG.AbstractCharacter;

namespace RPG
{
    public enum FightResult
    {
        Won,
        Lost,
        Draw,
        Default
    }
    internal class Game
    {
        public const uint NumRounds = 10;
        private static Game? instance = null;
        public void Fight(ICharacter charecter, IMonster monster, out FightResult result)
        {
            result = FightResult.Default;
            for (int i = 1; i < NumRounds + 1; i++)
            {
                Console.WriteLine($"\nRound {i} has started:");
                GetWhoIsFirst(charecter, monster);
                TryApplyDamage(charecter, monster);
                if (!charecter.IsAlive)
                {
                    result = FightResult.Lost;
                    break;
                }
                if (!monster.IsAlive)
                {
                    result = FightResult.Won;
                    break;
                }
            }
            if (charecter.IsAlive && monster.IsAlive)
            {
                result = FightResult.Draw;
            }
            Console.WriteLine($"--RESULT-- of the fight is: {result}");
        }
        public IActor GetWhoIsFirst(ICharacter character, IMonster monster)
        {
            bool characterTemp;
            bool monsterTemp;
            do
            {
                characterTemp = Randomize(character, character.AttackProbability);
                monsterTemp = Randomize(monster, monster.AttackProbability);
            } while (characterTemp != monsterTemp);
            if (characterTemp == true)
            {
                return character;
            }
            else
            {
                return monster;
            }
        }
        public void TryApplyDamage(IActor actor1, IActor actor2)
        {
            Console.WriteLine($"{actor1.Name} is first");
            if (Randomize(actor1, actor1.ApplyDamageProbability))
            {
                Console.WriteLine($"{actor1.Name} attacks successfully");
                actor2.ReceiveDamage(actor1, actor1.AttackPower);
                if (!actor2.IsAlive) { return; }

            }
            else
            { Console.WriteLine($"{actor1.Name} misses!"); }

            Console.WriteLine("--REVERSE--");
            if (Randomize(actor2, actor2.ApplyDamageProbability))
            {
                Console.WriteLine($"{actor2.Name} attacks successfully");
                actor1.ReceiveDamage(actor2, actor2.AttackPower);
                if (!actor1.IsAlive) { return; }
            }
            else { Console.WriteLine($"{actor2.Name} misses"); }
        }
        private bool Randomize(IActor actor, float probability)
        {
            Random rnd = new Random();
            double randomValue = rnd.NextDouble();
            return probability >= randomValue;
        }
        public static Game GetInstance()
        {
            if (instance == null)
            {
                return instance = new Game();
            }
            else { return instance; }
        }
        private Game()
        {

        }

    }
}