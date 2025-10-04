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
        //Readies the classes that are used in other classes
        //Not in the order they appear but it looks more satisfying this way
        Player player;
        EndGame endGame;
        Computer computer;
        DiceRolls diceroller;
        ScoreKeeper scoreKeep;
        GameController gameController;

        internal void StartGame()
        {
            //Instantiates every class that is used across classes
            player = new Player();
            endGame = new EndGame();
            computer = new Computer();
            diceroller = new DiceRolls();
            scoreKeep = new ScoreKeeper();
            gameController = new GameController();
            //Welcomes the player and creates and the instance of the players class, which asks the players name
            Console.WriteLine("Welcome, I am Yuri Jeong writing this at October 3, 2025. What is your name?");
            //Asks the players name
            playerName = Console.ReadLine();
            //Funny secret to people who decide not to input anything
            if (playerName == "")
            {
                Console.WriteLine("Well its rude to judge a name, or a lack of one at that matter");
            }
            //Asks if the player wants to play
            Console.WriteLine("Hello " + playerName + ", are you Prepared to Die? Please enter y for yes, n for no");
            AskToPlay playmygame = new AskToPlay();
            playmygame.PlayMyGame(player, computer, diceroller, scoreKeep, gameController, endGame);
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
