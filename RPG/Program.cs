﻿using RPG.Characters;
using RPG.Monsters;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rogue rogue = new Rogue("Maximus", 75.0f, 25.0f);
            Warrior warrior = new Warrior("Adonis", 75.0f, 90.0f);
            Console.WriteLine($"Rogue's Health: {rogue.Health}");
            rogue.ReceiveDamage(warrior, (uint)warrior.AttackPower);
            Console.WriteLine($"Rogue's Health: {rogue.Health}");
            Console.WriteLine($"Is Rogue Alive?: {rogue.IsAlive}");
            rogue.ReceiveDamage(warrior, (uint)warrior.AttackPower);
            Console.WriteLine($"Rogue's Health: {rogue.Health}");
            Console.WriteLine($"Is Rogue Alive?: {rogue.IsAlive}");
            Dragon dragon = new Dragon("Blood Dragon", 250f, 14f, 15);
            dragon.ReceiveDamage(warrior, warrior.AttackPower);

        }
    }
}