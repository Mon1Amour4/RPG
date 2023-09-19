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
            Rogue rogue = new Rogue("Maximus", 16.0f, 25.0f);
            Warrior warrior = new Warrior("warrior", 44, 44);
            Wizard wizard = new Wizard("Wizardiy", 44, 34);
            Dragon dragon = new Dragon("Blood Dragon", 15f, 14f, 900);

            FightResult result;
            GameInstance.Fight(warrior, dragon, out result);
        }


    }
}