using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    internal class GameController
    {
        internal void PlayGame()
        {
            //Welcomes the player and creates the dice roller
            Console.WriteLine("Welcome, I am Yuri Jeong writing this at September 17, 2025");
            DiceRolls diceroller = new DiceRolls();
            diceroller.RollDice();
            //Explains what various arithmetic operators do and says goodbye
            Console.WriteLine("+ adds the right number to the left number, so in 3 + 2 the 2 would be added into the 3 and output 5");
            Console.WriteLine("- subtracts the right number from the left number, so in 3 - 2 the 2 would be removed from the 3 and output 1");
            Console.WriteLine("/ divides the left number by the right number roudning down towards 0, so in 3 / 2 the 3 would be divided by 2, so rounding down would output 1");
            Console.WriteLine("* multiplies the right number by the left number, so 3 * 2 would multiply the 3 by 2 and output 6");
            Console.WriteLine("++ increases the operand by 1, before or after the operation depends on placement so i++ would output i at first but next time i would be i +1, but ++i would immediatly output i +1");
            Console.WriteLine("-- decreases the operand by 1, before or after the operation depends on placement so i-- would output i at first but next time i would be i -1, but --i would immediatly output i -1");
            Console.WriteLine("% gets the remainder after dividing the left number from the right number, so ");
            Console.WriteLine("Goodbye");
        }
    }
}
