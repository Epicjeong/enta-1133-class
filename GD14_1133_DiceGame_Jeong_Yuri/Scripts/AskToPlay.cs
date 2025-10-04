using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// Asks to play the game
    /// Yeah thats about it
    /// </summary>
    internal class AskToPlay
    {
        internal void PlayMyGame(Player player, Computer computer, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Instantiates the player
            string answer = Console.ReadLine();
            //If yes, explains the rules
            if (answer == "y")
            {
                Console.WriteLine("Excellent, now we explain the rules");
                Console.WriteLine("");
                Console.WriteLine("You and your computer opponent will start with a number sides, each turn you will decide how many sides you wish to use");
                Console.WriteLine("The amount of sides you use is how many sides the dice you will be rolling has, so with 7 sides your highest score is 7");
                Console.WriteLine("After you both roll, whoever has the highest score wil be awarded a point. Whoever gets more points in 4 rounds wins");
                Console.WriteLine("");
                Console.WriteLine("If both die roll the same result then no points will be awarded and your sides will not be refunded");
                Console.WriteLine("If both amount of points by the end are the same, the winner will be whoever has the lowest total rolls");
                Console.WriteLine("If both total rolls are the same, the remaining sides will be used for a final roll to decide thw winner");
                Console.WriteLine("If you have 0 points at the start of a new round, you will automatically lose that round");
                //The player goes first so they get the instructions before the computer does anything
                Console.WriteLine("");
                Console.WriteLine("As you are the person entering the game, you will choose how much sides you will roll with first");
                Console.WriteLine("But first, choose how many points to start with (minimum starting sides are 10, the computer will always start with 50)");
                //Sets the amount of sides the player starts with
                player.SetPlayerSides();
                //Begins the players first turn
                //Because the scorekeeper loops using PlayerTurn, using PlayerTurn here would add additional rounds of the game, hence why a different function is called
                player.PlayerTurn(player, computer, diceroller, scoreKeep, gameController, endGame);
            }
            //Can't exactly do much if you don't want to play
            else if (answer == "n")
            {
                Console.WriteLine("ok");
            }
            //If you didn't input one of the 2 options
            else
            {
                Console.WriteLine("Please enter a valid option");
                PlayMyGame(player, computer, diceroller, scoreKeep, gameController, endGame);
            }
        }
    }
}
