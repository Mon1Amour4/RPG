using RPG.Characters;
using RPG.Monsters;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Subscribr
            Game GameInstance = Game.GetInstance();
            Console.WriteLine($"Welcome!\n Choose Difficulty:\n - Easy\n - Medium\n - Hard");
            string stringDifficulty;
            stringDifficulty = Console.ReadLine().ToLower();
            GameInstance.ChooseDifficulty(stringDifficulty);


            Warrior warrior = new Warrior("warrior", 30, 220);
            GameInstance.Fight(warrior);
            //Rogue rogue = new Rogue("Maximus", 16.0f, 1.0f);
            //Wizard wizard = new Wizard("Wizardiy", 3, 44);
            //Visualization.Print();
        }
    }
}
