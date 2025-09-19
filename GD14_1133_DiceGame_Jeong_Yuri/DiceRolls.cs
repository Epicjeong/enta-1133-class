using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class DiceRolls
    {
        //Stores the total value of all rolls
        int TotalRoll;

        //Rolls various dice once by creating an instance of Random, starting from d6 and increasing to d8, d12, and d20
        internal void RollDice(int MinRoll = 1, int MaxRoll = 6)
        {
            //The starting d6 roll
            Random random = new Random();
            int Roll1 = random.Next(MinRoll, MaxRoll);
            Console.WriteLine("The d6 rolled a " + Roll1);

            //Increases to a d8 and rolls again
            MaxRoll = 8;
            int Roll2 = random.Next(MinRoll, MaxRoll);
            Console.WriteLine("The d8 rolled a " + Roll2);

            //Increases to a d12 and rolls again
            MaxRoll = 12;
            int Roll3 = random.Next(MinRoll, MaxRoll);
            Console.WriteLine("The d12 rolled a " + Roll3);

            //Increases to a d20 and rolls again
            MaxRoll = 20;
            int Roll4 = random.Next(MinRoll, MaxRoll);
            Console.WriteLine("The d20 rolled a " + Roll4);

            //Calculates and displays the total of the 4 rolls
            TotalRoll = Roll1 + Roll2 + Roll3 + Roll4;
            Console.WriteLine(TotalRoll);
        }
    }
}
