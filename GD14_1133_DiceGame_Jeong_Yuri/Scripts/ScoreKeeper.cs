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
        internal void KeepScore(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
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
                //Allows use of items while mining
                player.UseInventory(player, rock, random, diceroller, scoreKeep, endGame, map);
                player.PlayerTurn(player, diceroller, scoreKeep, endGame, map);
                rock.BreakRock(player);
                rockHealth = rock.GetRockHealth();
                if (rockHealth >= rockMaxHealth / 2)
                {
                    Console.WriteLine("The rock looks not too damaged");
                }
                else if (rockHealth <= rockMaxHealth / 2)
                {
                    Console.WriteLine("The rock looks much worse for wear");
                }
            }
            //Because the durability reaching 0 doesnt mean the rock is broken, so this code makes sure the rock doesnt automatically break when durability is 0
            if (rockHealth <= 0)
            {
                Console.WriteLine("You've broken the rock! You have obtained $" + rockMaxHealth + " worth of rocks");
                playerPoints = playerPoints + rockMaxHealth;
                Console.WriteLine("You now have $" + playerPoints + " worth of rocks");
            }
            roundNumber = 0;
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
