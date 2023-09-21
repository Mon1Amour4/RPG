
using RPG.Characters;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Subscribr
            //Game GameInstance = Game.GetInstance();
            //Rogue rogue = new Rogue("Maximus", 16.0f, 1.0f);
            Warrior warrior = new Warrior("warrior", 30, 220);
            Wizard wizard = new Wizard("Wizardiy", 3, 44);
            //Dragon dragon = new Dragon("Blood Dragon", 55f, 50f, 120);

            //GameInstance.Fight(warrior, dragon);

            Visualization.Print();
        }
    }
}
