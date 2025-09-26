using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class Player
    {
        //Keeps track of the player's name, dice rolls and the total of all dice rolls
        private string playerName;
        private int playerRoll;
        private int playerScore;

        internal void PlayerTurn()
        {
            //Asks the players name
            playerName = Console.ReadLine();
            Console.WriteLine("Hello " + playerName + ", and Prepare to Die");

            //The player goes first so they get the instructions before the computer does anything
            Console.WriteLine("As you are the person entering the game, you will choose which dice to roll first; Enter 1 for a d6, 2 for a d8, 3 for a d12, and 4 for a d20");
            //Creates the instance of DiceRolls so the player can choose and roll their dice
            DiceRolls diceroller = new DiceRolls();
            diceroller.RollDice();

            //Adds the dice result to the players total rolls
            int diceresult = diceroller.GetDiceResult();
            playerRoll = diceresult;
            playerScore = playerScore + diceresult;
            Console.WriteLine("Your total score is now " + playerScore);
        }

        //Allows other classes to get the players roll
        internal int GetPlayerRoll()
        {
            return playerRoll;
        }
        //Allows other classes to access the player's name
        internal string GetPlayerName()
        {
            return playerName;
        }
    }
}
