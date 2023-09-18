using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    internal class Game
    {
        public const uint NumRounds = 10;
        private static Game instance;

        enum FightResult
        {
            Won,
            Lost,
            Draw
        }

        public void Fight(ICharacter charecter, IMonster monster, out Enum result)
        {
            for (int i = 0; i < NumRounds; i++)
            {
                IActor? attackingSide = null;
                attackingSide = GetWhoIsFirst(charecter, monster, out IActor defensiveSide);

                if (attackingSide != null && defensiveSide != null)
                {
                    StepWrapper(attackingSide, defensiveSide);
                }
                else
                {
                    Console.WriteLine("--ERROR-- character or monster is null");

                }
                i++;
            }


        }
        public IActor? GetWhoIsFirst(ICharacter charecter, IMonster monster, out IActor defenciveSide)
        {
            if (monster != null && charecter != null)
            {
                float attackProbability = 0.5f;
                Random rnd = new Random();
                double koef = rnd.NextDouble();

                if (attackProbability >= koef)
                {
                    Console.WriteLine($"{charecter.GetType().Name} is first");
                    defenciveSide = monster;
                    return charecter;
                }
                else
                {
                    Console.WriteLine($"{monster.GetType().Name} is first");
                    defenciveSide = charecter;
                    return monster;
                }
            }

            defenciveSide = null;
            return null;

        }
        public void StepWrapper(IActor attackingSide, IActor defensiveSide)
        {
            TryApplyDamage(attackingSide, defensiveSide);
            TryApplyDamage(defensiveSide, attackingSide);

        }
        public void TryApplyDamage(IActor attackingSide, IActor defensiveSide)
        {
            float attackApplyDamageProbability = 0.75f;
            Random rnd = new Random();
            double koef = rnd.NextDouble();

            if (attackApplyDamageProbability >= koef)
            {
                Console.WriteLine($"{attackingSide.GetType().Name} hits {defensiveSide.GetType().Name}!");
                defensiveSide.ReceiveDamage(attackingSide, attackingSide.AttackPower);

            }
            else
            {
                Console.WriteLine($"{attackingSide.GetType().Name} misses!");
            }


        }
        public static Game getInstance()
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
