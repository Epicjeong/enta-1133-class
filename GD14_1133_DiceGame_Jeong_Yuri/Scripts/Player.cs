using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The players class
    /// Proceeds through the players turn
    /// Stores some player specific values
    /// </summary>
    internal class Player
    {
        //Keeps track of the player's dice rolls, the amount of sides they have left, and the total of all dice rolls
        private int playerRoll;
        private int playerScore;
        private int playerSidesLeft;
        int playerDiceResult;

        internal void SetPlayerSides()
        {
            //Sets the amount of sides the player starts with
            int.TryParse(Console.ReadLine(), out int startingSides);
            if (startingSides >= 10)
            {
                playerSidesLeft = startingSides;
            }
            //The reason the minimum is 10 is because I feel any below that would be unfun, at 10 there is at least some sembalence of chance
            else
            {
                Console.WriteLine("Please input a valid number");
                SetPlayerSides();
            }
        }

        //The players turn
        internal void PlayerTurn(Player player, Computer computer, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Creates the instance of DiceRolls so the player can choose and roll their dice
            Console.WriteLine("You have " + playerSidesLeft + " more sides left");
            if ( playerSidesLeft == 0)
            {
                Console.WriteLine("As you have 0 sides left your turn will be forfiet");
                playerDiceResult = 0;
            }
            else
            {
                diceroller.RollDice(player);
                playerDiceResult = diceroller.GetDiceResult();
            }

            //Adds the dice result to the players total points and removes the sides they declared
            playerRoll = playerDiceResult;
            playerScore = playerScore + playerDiceResult;
            int sidesUsed = diceroller.GetSidesUsed();
            playerSidesLeft = playerSidesLeft - sidesUsed;
            Console.WriteLine("Your total score is now " + playerScore);
            //Puts breaks every now and again so the player has time to read
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            //Continues to either the computers turn or to compare the rolls if thats already happened
            if (diceroller.GetComputerHasRolled() == false)
            {
                computer.ComputerTurn(player, computer, diceroller, scoreKeep, gameController, endGame);
            }
            else
            {
                scoreKeep.KeepScore(player, computer, diceroller, scoreKeep, gameController, endGame);
            }
        }

        //Lets other classes get the players roll
        internal int GetPlayerRoll()
        {
            return playerRoll;
        }
        //Lets other classes get the amount of sides the player has left
        internal int GetPlayerSidesLeft()
        {
            return playerSidesLeft;
        }
        //Lets other classes get the players score
        internal int GetPlayerScore()
        {
            return playerScore;
        }
    }
}
