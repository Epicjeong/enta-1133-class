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
        internal void PlayMyGame(Map map, Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Gets the players answer
            string answer = Console.ReadLine();
            //If yes, explains the rules
            if (answer == "y")
            {
                Console.WriteLine("Excellent, now we explain the rules");
                Console.WriteLine("");
                Console.WriteLine("You will be placed into a randomly generated mine with a pickaxe that has a certain amount of durability");
                Console.WriteLine("The mine is a grid, each square on that grid can be a treasure room or an item room");
                Console.WriteLine("In an item room, you could find items that help you in your mining, like duct tape to restore durability");
                Console.WriteLine("In a treasure room, you will find a cool rock that has value to it, and commence the mining");
                Console.WriteLine("");
                Console.WriteLine("When mining, the rock has a random amount of health that you must deplete by using your durability");
                Console.WriteLine("You can choose how much durability to use at a time, then the amount of durability you chose will roll a dice");
                Console.WriteLine("The durability you chose wil be the highest possible roll of the dice, so if you chose 7 the max roll is 7");
                Console.WriteLine("");
                Console.WriteLine("Once the rocks health is depleted, you will gain the rocks max health as value in $");
                Console.WriteLine("When you leave the mine, your total value will be displayed and the game will end");
                Console.WriteLine("If you ever reach 0 durability, you will automatically leave the mine and end the game");
                Console.WriteLine("With that explained, we can almost start the game");
                Console.WriteLine("");
                Console.WriteLine("But first, choose how much durability to start with (minimum starting durability is 10)");
                //Sets the amount of sides the player starts with
                player.SetPlayerSides();
                //Begins the players first turn
                map.CreateMap(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
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
                PlayMyGame(map, player, rock, diceroller, scoreKeep, gameController, endGame);
            }
        }
    }
}
