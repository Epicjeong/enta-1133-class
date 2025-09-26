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
        //The type of dice the player could roll
        int diceType;
        //The highest roll that can be rolled
        int maxRoll;
        //Stores the result of the dice to add to the players score
        private int diceResult;

        //Rolls various dice once by creating an instance of Random, choosing from d6, d8, d12, and d20
        internal void RollDice(int minRoll = 1)
        {
            //Creates the instance of Random for the dice
            Random random = new Random();

            //Gets the number the player chose
            int.TryParse(Console.ReadLine(), out diceType);

            //The following code rolls the dice that was chosen
            //Rolls a d6
            if (diceType == 1)
            {
                maxRoll = 6;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d6 rolled a " + diceResult);
            }
            //Rolls a d8
            else if (diceType == 2)
            {
                maxRoll = 8;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d8 rolled a " + diceResult);
            }
            //Rolls a d12
            else if (diceType == 3)
            {
                maxRoll = 12;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d12 rolled a " + diceResult);
            }
            //Rolls a d20
            else if (diceType == 4)
            {
                maxRoll = 20;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d20 rolled a " + diceResult);
            }
            //Incase the player inputs either an invalid number, letter, or a special symbol
            else
            {
                Console.WriteLine("Please input a valid number, this turn will be considered forfiet");
            }
        }

        //Rolls the computers dice from the same pool of dice the player chose
        internal void ComputerDice(int minRoll = 1)
        {
            //Creates the instance of Random for the dice
            Random random = new Random();

            int computerDiceType = random.Next(1, 4);

            //The following code rolls the dice that was chosen
            //Rolls a d6
            if (computerDiceType == 1)
            {
                maxRoll = 6;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d6 rolled a " + diceResult);
            }
            //Rolls a d8
            if (computerDiceType == 2)
            {
                maxRoll = 8;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d8 rolled a " + diceResult);
            }
            //Rolls a d12
            if (computerDiceType == 3)
            {
                maxRoll = 12;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d12 rolled a " + diceResult);
            }
            //Rolls a d20
            if (computerDiceType == 4)
            {
                maxRoll = 20;
                int Roll = random.Next(minRoll, maxRoll);
                diceResult = Roll;
                Console.WriteLine("The d20 rolled a " + diceResult);
            }
        }

        //Allows use of the dice result in other classes
        internal int GetDiceResult()
        {
            return diceResult;
        }
    }
}
