using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// Actually starts the game
    /// Gets the players name
    /// Instantiates the classes used throughout the game
    /// </summary>
    internal class GameController
    {
        //Keeps track of player name
        private string playerName;
        //Readies the custom classes that are used in other classes
        //Not in the order they appear but it looks more satisfying this way
        Map map;
        Rock rock;
        Random random;
        Player player;
        EndGame endGame;
        DiceRolls diceroller;
        ScoreKeeper scoreKeep;


        internal void StartGame()
        {
            //Instantiates every class that is used across classes
            player = new Player();
            endGame = new EndGame();
            rock = new Rock();
            diceroller = new DiceRolls();
            scoreKeep = new ScoreKeeper();
            map = new Map();
            random = new Random();
            //Welcomes the player and creates and the instance of the players class, which asks the players name
            Console.WriteLine("Welcome, I am Yuri Jeong writing this at October 17, 2025. What is your name?");
            //Asks the players name
            playerName = Console.ReadLine();
            //Funny secret to people who decide not to input anything
            if (playerName == "")
            {
                Console.WriteLine("Well its rude to judge a name, or a lack of one at that matter");
            }
            //Explains rules and asks if the player wants to play
            Console.WriteLine("Hello " + playerName + ", let me explain the game that will be played");
            Console.WriteLine("");
            Console.WriteLine("You will be placed into a randomly generated mine with a pickaxe that has a certain amount of durability");
            Console.WriteLine("The mine is a grid, each square on that grid can be a treasure room or an item room");
            Console.WriteLine("In an item room, you could find items that help you in your mining, like duct tape to restore durability");
            Console.WriteLine("In a treasure room, you will find a cool rock that has value to it, and commence the mining");
            Console.WriteLine("");
            Console.WriteLine("When mining, the rock has a random amount of health that you must deplete by using your durability");
            Console.WriteLine("You can choose how much durability to use at a time, then the amount of durability you chose will roll a dice");
            Console.WriteLine("The durability you chose wil be the highest possible roll of the dice, so if you chose 7 the max roll is 7");
            Console.WriteLine("Using items found by searching item rooms, you can increase the durability of your pickaxe");
            Console.WriteLine("At the start of a swing, you can use 1 item if you have any, so dont worry about saving them up");
            Console.WriteLine("");
            Console.WriteLine("Once the rocks health is depleted, you will gain the rocks max health as value in $");
            Console.WriteLine("When you leave the mine, your total value will be displayed and the game will end");
            Console.WriteLine("Your end goal is to exit the mine with at least #30 in rocks");
            Console.WriteLine("If you ever reach 0 durability, you will automatically leave the mine and end the game");
            Console.WriteLine("Now with that explained, are you ready to Randominez? Please enter y for yes, n for no");
            AskToPlay playmygame = new AskToPlay();
            playmygame.PlayMyGame(map, player, rock, random, diceroller, scoreKeep, endGame);
            //Gonna say goodbye
            Console.WriteLine("Goodbye");
        }
        //Lets other classes get the players name
        internal string GetPlayerName()
        {
            Console.WriteLine(playerName);
            return playerName;
        }
    }
}
