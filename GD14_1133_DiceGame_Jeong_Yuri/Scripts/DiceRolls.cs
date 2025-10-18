using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// What actually rolls the dice
    /// Lets the player choose how large their dice are and controls the computers logic
    /// </summary>
    internal class DiceRolls
    {
        //The highest and lowest number that can be rolled
        int maxRoll;
        int minRoll = 1;
        //Stores the result of the dice to add to the players or computers score
        private int diceResult;

        //Rolls various dice once by creating an instance of Random, choosing from d6, d8, d12, and d20
        internal void RollDice(Player player)
        {
            //Creates the instance of Random for the dice
            Random random = new Random();

            //Gets the number the player chose
            Console.WriteLine("Now choose the amount of sides your dice will have");
            int.TryParse(Console.ReadLine(), out maxRoll);
            if (maxRoll <= player.GetPlayerSidesLeft() && maxRoll != 0)
            {
                //The following code rolls the dice with the amount of sides chosen and shows the dice result
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d" + maxRoll + " rolled a " + diceResult);
            }
            //For invaild inputs, i.e a number more than your current sides left, letters, nothing, etc
            else
            {
                Console.WriteLine("Please input a valid option");
                RollDice(player);
            }
        }

        //Rolls to decide how durable the rock is
        internal void ComputerDice(Rock rock)
        {
            //Creates the instance of Random for the dice
            Random random = new Random();
            //Makes the rocks health a random value
            int Roll = random.Next(7, 12);
            diceResult = Roll;
        }
        //Lets other classes get the dice result
        internal int GetDiceResult()
        {
            return diceResult;
        }
        //Lets other classes get the maxRoll, which is the amount of sides that are used up
        internal int GetSidesUsed()
        {
            return maxRoll;
        }
    }
}
