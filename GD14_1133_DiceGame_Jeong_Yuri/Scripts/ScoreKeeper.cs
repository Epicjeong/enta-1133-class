using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// Keeps track of the points of the player and computer
    /// Controls tiebreakers and starts the endgame
    /// </summary>
    internal class ScoreKeeper
    {
        //Keeps track of points
        int playerPoints = 0;
        int computerPoints = 0;
        int roundNumber = 1;
        bool enteredEndGame = false;
        internal void KeepScore(Player player, Computer computer, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Gets the rolls for the round
            int playerRoll = player.GetPlayerRoll();
            int computerRoll = computer.GetComputerRoll();

            //Player win round
            if (playerRoll > computerRoll)
            {
                Console.WriteLine("You rolled " + playerRoll + ", which is greater than " + computerRoll + ", which the computer rolled so you get a point");
                playerPoints++;
                Console.WriteLine("You now have " + playerPoints + " points");
                //Displays the current points
                Console.WriteLine("The score is now " + playerPoints + " for you and " + computerPoints + " for the computer");
            }
            //Computer win
            if (playerRoll < computerRoll)
            {
                Console.WriteLine("The computer rolled " + computerRoll + ", which is greater than " + playerRoll + ", which you rolled so the computer gets a point");
                computerPoints++;
                Console.WriteLine("The computer now has " + computerPoints + " points");
                //Displays the current points
                Console.WriteLine("The score is now " + playerPoints + " for you and " + computerPoints + " for the computer");
            }
            //Tie
            if (playerRoll == computerRoll)
            {
                Console.WriteLine("As it is a tie, no points will be awarded");
                //Displays the current points
                Console.WriteLine("The score is now " + playerPoints + " for you and " + computerPoints + " for the computer");
            }
            //Increases the round number and moves on to the next turn until either someone gets 3 points or it is not round 3
            while (roundNumber < 4 && playerPoints < 3 && computerPoints < 3)
            {
                roundNumber++;
                Console.WriteLine("It is now round " + roundNumber);
                if (playerPoints > computerPoints)
                {
                    Console.WriteLine("As you have more points, you will be going second");
                    //Puts breaks every now and again so the player has time to read
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    diceroller.ResetRolls();
                    computer.ComputerTurn(player, computer, diceroller, scoreKeep, gameController, endGame);
                }
                else if (playerPoints < computerPoints)
                {
                    Console.WriteLine("As you have less points, you will be going first");
                    //Puts breaks every now and again so the player has time to read
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    diceroller.ResetRolls();
                    player.PlayerTurn(player, computer, diceroller, scoreKeep, gameController, endGame);
                }
                else if(playerPoints == computerPoints)
                {
                    Console.WriteLine("As you have the same points, you will be going first as you were the challenger");
                    //Puts breaks every now and again so the player has time to read
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    diceroller.ResetRolls();
                    player.PlayerTurn(player, computer, diceroller, scoreKeep, gameController, endGame);

                }
            }
            //The EndGame class would be called twice before adding this, this is to stop that
            if (!enteredEndGame)
            {
                enteredEndGame = true;
                endGame.DeclareVictory(player, computer, scoreKeep);
            }

        }

        //Lets other classes get the pp
        //I am incredibly mature
        internal int GetPlayerPoints()
        {
            return playerPoints;
        }
        //Lets other classes get the computers points
        internal int GetComputerPoints()
        {
            return computerPoints;
        }
        //Lets other classes get the round number
        internal int GetRounds()
        {
            return roundNumber;
        }
    }
}
