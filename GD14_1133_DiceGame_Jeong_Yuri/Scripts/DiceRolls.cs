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
        private bool computerHasRolled, playerHasRolled;

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
                playerHasRolled = true;
            }
            //For invaild inputs, i.e a number more than your current sides left, letters, nothing, etc
            else
            {
                Console.WriteLine("Please input a valid option");
                RollDice(player);
            }
        }

        //Rolls the computers dice from the same pool of dice the player chose
        internal void ComputerDice(Computer computer)
        {
            //Creates the instance of Random for the dice
            Random random = new Random();
            //It should MATHMATICALLY be impossible for the computer to use all sides it has available, as there are 4 rounds and 12 * 4 is 48
            maxRoll = random.Next(7, 12);
            //The following code rolls the dice with the amount of sides chosen and shows the dice result
            Console.WriteLine("Now the computer rolls");
            int Roll = random.Next(minRoll, maxRoll);
            diceResult = Roll;
            Console.WriteLine("The computers d" + maxRoll + " rolled a " + diceResult);
            computerHasRolled = true;
        }
        //Makes it so neither player has rolled this round
        internal void ResetRolls()
        {
            playerHasRolled = false;
            computerHasRolled = false;
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
        //Lets other classes to know if either the player or computer has rolled
        internal bool GetPlayerHasRolled()
        {
            return playerHasRolled;
        }
        internal bool GetComputerHasRolled()
        {
            return computerHasRolled;
        }
    }
}
