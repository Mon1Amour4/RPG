using RPG.Characters;
using RPG.Monsters;
using System.Text.Json;
using System.Threading;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rogue rogue = new Rogue("Maximus", 11.0f, 25.0f);
            Warrior warrior = new Warrior("warrior", 44, 44);
            Wizard wizard = new Wizard("Wizardiy", 44, 34);
            Dragon dragon = new Dragon("Blood Dragon", 15f, 14f, 900);
            dragon.ReceiveDamage(rogue, rogue.AttackPower);

        }
    }
}