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
            int i = 1;
            result = FightResult.Default;
            IActor attackingSide = null;
            IActor defensiveSide = null;
            for (; i < NumRounds+1; i++)
            {
                Console.WriteLine($"\nRound {i} has started:");
                
                GetWhoIsFirst(charecter, monster, out attackingSide, out defensiveSide);

                TryApplyDamage(attackingSide, defensiveSide, out result);
                if (attackingSide.IsAlive == false || defensiveSide.IsAlive == false)
                {
                    break;
                }
            }
            if (attackingSide.IsAlive || defensiveSide.IsAlive && i> NumRounds)
            {
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
            result = FightResult.Default;

            if (Rand(attackApplyDamageProbability))
            {
                defensiveSide.ReceiveDamage(attackingSide, attackingSide.AttackPower);
                Console.WriteLine($"{attackingSide.GetType().Name} is attacking successfully!");
                if (!IsAlive(defensiveSide))
                {
                    defensiveSide.OnDie?.Invoke();
                    Console.WriteLine($"{attackingSide.GetType().Name} won by attacking first!");
                    result = FightResult.Won;
                    Console.WriteLine(result);
                    return;
                }
                if (Rand(attackApplyDamageProbability))
                {
                    Console.WriteLine($"--REVERSE--");
                    attackingSide.ReceiveDamage(defensiveSide, defensiveSide.AttackPower);
                    if (!IsAlive(attackingSide))
                    {
                        attackingSide.OnDie?.Invoke();
                        Console.WriteLine($"{defensiveSide.GetType().Name} won by attacking second!");
                        result = FightResult.Lost;
                        Console.WriteLine(result);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"{defensiveSide.GetType().Name} misses!\n");
                }
            }
            else
            {
                Console.WriteLine($"{attackingSide.GetType().Name} misses!\n --REVERSE--");

                if (Rand(attackApplyDamageProbability))
                {
                    Console.WriteLine($"{defensiveSide.GetType().Name} is attacking successfully!");
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