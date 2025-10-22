using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The final calculations
    /// Shows the stats of the player
    /// </summary>
    internal class EndGame
    {
        //Displays the stats after the player leaves the mine
        internal void PlayerWin(Player player, ScoreKeeper scorekeep, Map map)
        {
            int totalValue = scorekeep.GetPlayerPoints() + player.GetValueFromGems() + player.GetHasEgg();
            //Displays stats
            Console.WriteLine("You left the mine with $" + totalValue + " in rocks, and you pickaxe still has " + player.GetPlayerSidesLeft() + " durability left.");
            //If you reach the goal
            if (totalValue >= 30)
            {
                Console.WriteLine("You have reached your goal of $30, go spend you hard earned rocks on something nice, you deserve it");
            }
            //If you fail to reach the goal
            else if (totalValue < 30 && totalValue > 0)
            {
                Console.WriteLine("You didnt make $30, but at least you still have something");
            }
            //If you have $0 in value but any pickaxes durability
            else if (totalValue == 0 && player.GetPlayerSidesLeft() >= 0)
            {
                Console.WriteLine("You didnt make any money, but you atelast have your pickaxe");
            }
            //If you have no durability and $0 in value
            else if (totalValue == 0 && player.GetPlayerSidesLeft() == 0)
            {
                Console.WriteLine("What a shame, you left with nothing but your pickaxe to show for your work");
            }
            Console.WriteLine("Would you like to play again?");
        }
    }
}
