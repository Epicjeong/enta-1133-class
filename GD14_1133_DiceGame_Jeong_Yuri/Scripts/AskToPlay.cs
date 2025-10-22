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
        //If these ints were with the others in the PlayerChoice call it would cause errors
        int direction;
        int selection;
        string answer;
        internal void PlayMyGame(Map map, Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame)
        {
            while (answer != "n")
            {
                //Gets the players answer
                answer = Console.ReadLine();
                //If yes, explains the rules
                if (answer == "y")
                {
                    //Minimum is 30 because the game is theoretically impossible otherwise
                    Console.WriteLine("Excellent, now choose how much durability to start with (minimum starting durability is 30, 50 is reccomended)");
                    //Sets the amount of sides the player starts with
                    player.SetPlayerSides();
                    //Generates the map
                    map.CreateMap(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
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
                }
            }
        }
    }
}
