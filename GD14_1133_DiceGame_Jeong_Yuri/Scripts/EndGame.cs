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
        //Player win message
        internal void PlayerWin(Player player, ScoreKeeper scorekeep)
        {
            Console.WriteLine("You left the mine with $" + scorekeep.GetPlayerPoints() + " in rocks, and you pickaxe still has ");
            //This line can be read as sarcastic or genuine based on the value of rocks you ended with
            Console.WriteLine(player.GetPlayerSidesLeft() + " durability left. Go spend you hard earned rocks on something nice, you deserve it");
        }
    }
}
