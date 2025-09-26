using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    internal class GameController
    {
        //Keeps track of points
        int playerPoints = 0;
        int computerPoints = 0;

        internal void PlayGame()
        {
            //Welcomes the player and creates and the instance of the player's class, which asks the players name
            Console.WriteLine("Welcome, I am Yuri Jeong writing this at September 23, 2025. What is your name?");
            Player player = new Player();
            player.PlayerTurn();
            string playerName = player.GetPlayerName();

            //Starts the computer's turn and creates the instance of the computers class
            Console.WriteLine("Now it is the computer's turn, who will also choose from the same dice you chose form");
            //playerTurn = false;
            Computer computer = new Computer();
            computer.ComputerTurn();

            //Compares the rolls of the player and the computer
            int playerRoll = player.GetPlayerRoll();
            int computerRoll = computer.GetComputerRoll();
            //Player win
            if (playerRoll > computerRoll)
            {
                Console.WriteLine("You rolled " + playerRoll +", which is greater than " + computerRoll + ", which the computer rolled so you get a point");
                playerPoints++;
                Console.WriteLine("You now have " + playerPoints + " points");
            }
            //Computer win
            if (playerRoll < computerRoll)
            {
                Console.WriteLine("The computer rolled " + computerRoll +", which is greater than " + playerRoll + ", which you rolled so the computer gets a point");
                computerPoints++;
                Console.WriteLine("The computer now has " + computerPoints + " points");
            }
            //Tie
            if (playerRoll == computerRoll)
            {
                Console.WriteLine("As it is a tie, no points will be awarded");
            }

            //Displays the current points
            Console.WriteLine("The score is now " + playerPoints + " for " + playerName + " and " + computerPoints + " for the computer");
            Console.WriteLine("Goodbye");
        }
    }
}
