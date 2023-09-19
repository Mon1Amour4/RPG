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

        private readonly float attackProbability = 0.5f;
        private readonly float attackApplyDamageProbability = 0.75f;

        public const uint NumRounds = 10;
        private static Game instance = null;



        public void Fight(ICharacter charecter, IMonster monster, out FightResult result)
        {
            result = FightResult.Default;
            IActor attackingSide = null;
            IActor defensiveSide = null;
            for (int i = 0; i < NumRounds; i++)
            {
                result = FightResult.Lost;
                GetWhoIsFirst(charecter, monster, out attackingSide, out defensiveSide);
                TryApplyDamage(attackingSide, defensiveSide, out result);
                i++;
                if (!charecter.IsAlive)
                {
                    charecter.OnDie?.Invoke();
                }
                else if (!monster.IsAlive)
                {
                    monster.OnDie?.Invoke();
                }
            }
            if (attackingSide.IsAlive || defensiveSide.IsAlive)
            {
                Console.WriteLine("Draw");
                result = FightResult.Draw;
                Console.WriteLine(result);
            }

        }
        public void GetWhoIsFirst(ICharacter charecter, IMonster monster, out IActor attackingSide, out IActor defensiveSide)
        {
            defensiveSide = null;
            attackingSide = null;

            if (monster != null && charecter != null)
            {
                if (Rand(attackProbability))
                {
                    Console.WriteLine($"{charecter.GetType().Name} is first");
                    defensiveSide = monster;
                    attackingSide = charecter;
                }
                else
                {
                    Console.WriteLine($"{monster.GetType().Name} is first");
                    defensiveSide = charecter;
                    attackingSide = monster;
                }
            }

        }
        public void TryApplyDamage(IActor attackingSide, IActor defensiveSide, out FightResult result)
        {
            result = FightResult.Draw;

            if (Rand(attackApplyDamageProbability))
            {
                defensiveSide.ReceiveDamage(attackingSide, attackingSide.AttackPower);
                if (!IsAlive(defensiveSide))
                {
                    Console.WriteLine($"{attackingSide.GetType().Name} is Win!");
                    result = FightResult.Won;
                    Console.WriteLine(result);
                    return;
                }
                if (Rand(attackApplyDamageProbability))
                {
                    attackingSide.ReceiveDamage(defensiveSide, defensiveSide.AttackPower);
                    if (!IsAlive(attackingSide))
                    {
                        Console.WriteLine($"{defensiveSide.GetType().Name} is Win!");
                        result = FightResult.Lost;
                        Console.WriteLine(result);
                        return;
                    }
                }
            }
            else
            {
                if (Rand(attackApplyDamageProbability))
                {
                    attackingSide.ReceiveDamage(defensiveSide, defensiveSide.AttackPower);
                    if (!IsAlive(attackingSide))
                    {
                        Console.WriteLine($"{defensiveSide.GetType().Name} is Win!");
                        result = FightResult.Lost;
                        Console.WriteLine(result);
                        return;
                    }
                }


            }
        }

        private bool Rand(float probability)
        {
            Random rnd = new Random();
            double koef = rnd.NextDouble();
            if (probability >= koef) { return true; } else { return false; }
        }
        private bool IsAlive(IActor actor)
        {
            if (actor.IsAlive == false)
            {

                return false;
            }
            return true;
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