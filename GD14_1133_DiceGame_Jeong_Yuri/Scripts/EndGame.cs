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
        internal void PlayerWin(Player player, ScoreKeeper scorekeep)
        {
            int totalValue = scorekeep.GetPlayerPoints() + player.GetValueFromGems() + player.GetHasEgg();
            //Displays stats
            Console.WriteLine("You left the mine with $" + totalValue + " in rocks, and you pickaxe still has " + player.GetPlayerSidesLeft() + " durability left.");
            //If you reach the goal
            if (scorekeep.GetPlayerPoints() >= 30)
            {
                Console.WriteLine("You have reached your goal of $30, go spend you hard earned rocks on something nice, you deserve it");
            }
            //If you fail to reach the goal
            else if (scorekeep.GetPlayerPoints() < 30 && scorekeep.GetPlayerPoints() > 0)
            {
                Console.WriteLine("You didn't make $30, but at least you still have something");
            }
            //If you have no durability and $0 in value
            else if (scorekeep.GetPlayerPoints() == 0)
            {
                Console.WriteLine("What a shame, you left with nothing but your pickaxe to show for your work");
            }
            Console.WriteLine("Would you like to play again?");
        }
    }
}
