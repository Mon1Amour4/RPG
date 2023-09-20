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
        private static Game? instance = null;
        public void Fight(ICharacter charecter, IMonster monster, out FightResult result)
        {
            result = FightResult.Default;
            for (int i = 1; i < NumRounds + 1; i++)
            {
                Console.WriteLine($"\nRound {i} has started:");
                GetWhoIsFirst(charecter, monster);
                TryApplyDamage(charecter, monster);
                if (!charecter.IsAlive || !monster.IsAlive)
                {
                    break;
                }
            }
            if (charecter.IsAlive && monster.IsAlive)
            {
                result = FightResult.Draw;
                Console.WriteLine(result);
            }
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
        public void TryApplyDamage(ICharacter character, IMonster monster)
        {
            IActor tempActor = GetWhoIsFirst(character, monster);
            if (tempActor is ICharacter && character.IsAlive == true)
            {
                Console.WriteLine($"{tempActor.Name} is first!");
                if (Randomize(character, character.ApplyDamageProbability))
                {
                    Console.WriteLine($"{character.Name} attacks successfully");
                    monster.ReceiveDamage(character, character.AttackPower);
                    if (!monster.IsAlive) { return; } 
                    Console.WriteLine("--REVERSE--");
                    if (Randomize(monster, monster.ApplyDamageProbability))
                    {
                        Console.WriteLine($"{monster.Name} attacks successfully");
                        character.ReceiveDamage(monster, monster.ApplyDamageProbability);
                        if (!character.IsAlive) { return; }
                    }
                    else
                    {
                        Console.WriteLine($"{monster.Name} misses!");
                    }
                }
                else
                {
                    Console.WriteLine($"{character.Name} misses!");
                    if (Randomize(monster, monster.ApplyDamageProbability))
                    {
                        Console.WriteLine($"{monster.Name} attacks successfully");
                        character.ReceiveDamage(monster, monster.ApplyDamageProbability);
                        if (!character.IsAlive) { return; }
                    }
                    else
                    {
                        Console.WriteLine($"{monster.Name} misses!");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{tempActor.Name} is first!");
                if (Randomize(monster, monster.ApplyDamageProbability))
                {
                    Console.WriteLine($"{monster.Name} attacks successfully");
                    character.ReceiveDamage(monster, monster.AttackPower);
                    Console.WriteLine("--REVERSE--");
                    if (Randomize(character, character.ApplyDamageProbability))
                    {
                        Console.WriteLine($"{character.Name} attacks successfully");
                        monster.ReceiveDamage(character, character.ApplyDamageProbability);
                        if (!monster.IsAlive) { return; }
                    }
                    else
                    {
                        Console.WriteLine($"{character.Name} misses!");
                    }
                }
                else
                {
                    Console.WriteLine($"{monster.Name} misses!");
                    if (Randomize(character, character.ApplyDamageProbability))
                    {
                        Console.WriteLine($"{character.Name} attacks successfully");
                        monster.ReceiveDamage(character, character.ApplyDamageProbability);
                        if (!monster.IsAlive) { return; }
                    }
                    else
                    {
                        Console.WriteLine($"{character.Name} misses!");
                    }
                }
            }
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