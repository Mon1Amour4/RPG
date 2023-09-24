using RPG.Characters;
using RPG.Difficulties;
using RPG.Interfaces;
using System;

using static RPG.AbstractCharacter;

namespace RPG
{
    public enum FightResult
    {
        Won,
        Lost,
        Draw
    }
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    internal class Game
    {
        public const uint NumRounds = 10;
        private static Game? instance = null;
        //Spawner, Difficulties
        ISpawner MonsterSpawner { get; set; }
        public GameDifficulty Difficulty { get; private set; }
        //Methods
        public void ChooseDifficulty(string diff)
        {
            switch (diff)
            {
                case "easy":
                    this.SetDifficulty(GameDifficulty.Easy);
                    break;
                case "medium":
                    this.SetDifficulty(GameDifficulty.Medium);
                    break;
                case "hard":
                    this.SetDifficulty(GameDifficulty.Hard);
                    break;
                default:
                    this.SetDifficulty(GameDifficulty.Medium);
                    break;
            }
        }

        public FightResult Fight(ICharacter charecter)
        {
            IMonster monster = InitializeMonster();

            var result = FightResult.Draw;
            for (int i = 1; i < NumRounds + 1; i++)
            {
                Console.WriteLine($"\nRound {i} has started:");
                GetWhoIsFirst(charecter, monster);
                TryApplyDamage(charecter, monster);
                if (!charecter.IsAlive)
                {
                    result = FightResult.Lost;
                    return FightResult.Lost;
                }
                if (!monster.IsAlive)
                {
                    result = FightResult.Won;
                    return FightResult.Won;
                }
            }
            Console.WriteLine($"--RESULT-- of the fight is: {result}");
            return result;
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

            return characterTemp ? character : monster;

        }
        public void TryApplyDamage(IActor actor1, IActor actor2)
        {
            Console.WriteLine($"{actor1.Name} is first");
            if (Randomize(actor1, actor1.ApplyDamageProbability))
            {
                Console.WriteLine($"{actor1.Name} attacks successfully");
                actor2.ReceiveDamage(actor1, actor1.AttackPower);
                if (!actor2.IsAlive)
                {
                    return;
                }
            }
            else
            { Console.WriteLine($"{actor1.Name} misses!"); }

            Console.WriteLine("--REVERSE--");
            if (Randomize(actor2, actor2.ApplyDamageProbability))
            {
                Console.WriteLine($"{actor2.Name} attacks successfully");
                actor1.ReceiveDamage(actor2, actor2.AttackPower);
                if (!actor1.IsAlive)
                {
                    return;
                }
            }
            else { Console.WriteLine($"{actor2.Name} misses"); }
        }
        public bool Randomize(IActor actor, float probability)
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
        public void SetDifficulty(GameDifficulty difficulty)
        {
            this.Difficulty = difficulty;
        }
        private IMonster InitializeMonster()
        {
            switch (this.Difficulty)
            {
                case GameDifficulty.Easy:
                    EasyDifficulty EasyInstance = new EasyDifficulty();
                    return EasyInstance.Spawn();

                case GameDifficulty.Medium:
                    MediumDifficulty MediumInstance = new MediumDifficulty();
                    return MediumInstance.Spawn();

                case GameDifficulty.Hard:
                    HardDifficulty HardInstance = new HardDifficulty();
                    return HardInstance.Spawn();
                default:
                    MediumDifficulty DefaultInstance = new MediumDifficulty();
                    return DefaultInstance.Spawn();
            }
        }

        //Ctor
        private Game()
        {
        }

    }
}