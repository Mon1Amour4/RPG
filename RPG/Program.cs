using RPG.Characters;
using RPG.Monsters;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Subscribr
            Game GameInstance = Game.GetInstance();
            Rogue rogue = new Rogue("Maximus", 16.0f, 1.0f);
            Warrior warrior = new Warrior("warrior", 30, 220);
            Wizard wizard = new Wizard("Wizardiy", 3, 44);
            Dragon dragon = new Dragon("Blood Dragon", 55f, 1f, 120);

            FightResult result;
            GameInstance.Fight(warrior, dragon, out result);
        }


    }
}