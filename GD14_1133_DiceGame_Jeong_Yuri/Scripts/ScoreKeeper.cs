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
        //Keeps track of points, which is the value of the rocks mined
        int playerPoints = 0;
        //How many swings the player has taken
        int roundNumber;
        internal void KeepScore(Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Gets the rolls for the round
            int playerRoll = player.GetPlayerRoll();
            int rockMaxHealth = rock.GetRockMaxHealth();
            int rockHealth = rockMaxHealth;
            

            //Loops mining the rock until it either breaks or the pickaxe runs out of durability
            while (rockHealth > 0 && player.GetPlayerSidesLeft() > 0)
            {
                roundNumber++;
                Console.WriteLine("This is swing number " + roundNumber);
                //Puts breaks every now and again so the player has time to read
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                player.PlayerTurn(player, rock, diceroller, scoreKeep, gameController, endGame);
                rock.BreakRock(player);
                rockHealth = rock.GetRockHealth();
                Console.WriteLine(rockHealth);
                if (rockHealth >= rockMaxHealth / 2)
                {
                    Console.WriteLine("The rock looks not too damaged");
                }
                else if (rockHealth <= rockMaxHealth / 2)
                {
                    Console.WriteLine("The rock looks much worse for wear");
                }
            }
            Console.WriteLine("You've broken the rock! You have obtained $" + rockMaxHealth + " worth of rocks");
            playerPoints = playerPoints + rock.GetRockMaxHealth();
            Console.WriteLine("You now have $" + playerPoints + " worth of rocks");
        }

        //Lets other classes get the pp
        //I am incredibly mature
        internal int GetPlayerPoints()
        {
            return playerPoints;
        }
        //Lets other classes get the round number
        internal int GetRounds()
        {
            return roundNumber;
        }
    }
}
