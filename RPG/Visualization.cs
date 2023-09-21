using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Visualization
    {

        public static string[] wLetter = {
            "W       W",
            "W       W",
            "W   W   W",
            "W  W  W W",
            "W W   W W",
            "W       W" };

        public static string[] dLetter = {
            "DDDDD    ",
            "D    D   ",
            "D     D  ",
            "D     D   ",
            "D    D   ",
            "DDDDD    " };



        public static void Print()
        {
            SetConsoleSize(100, 100);

            int maxLength = Math.Max(wLetter.Length, dLetter.Length);
            for (int i = 0; i < maxLength; i++)
            {

                string wLine = (i < wLetter.Length) ? wLetter[i] : new string(' ', wLetter[0].Length);
                string dLine = (i < dLetter.Length) ? dLetter[i] : new string(' ', dLetter[0].Length);

                Console.WriteLine(wLine + " \t\t\t" + dLine);
            }
        }


        public static void RenderActors(ICharacter character, IMonster monster)
        {
            char characterLetter = GetCharacterLetter(character);
            char monsterLetter = GetCharacterLetter(monster);
        }
        public static char GetCharacterLetter(IActor actor)
        {
            char temp;
            return temp = actor.Name[0];
        }
        public static void SetConsoleSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }
    }
}
