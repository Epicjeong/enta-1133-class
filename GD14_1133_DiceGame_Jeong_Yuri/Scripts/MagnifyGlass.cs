using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The subclass for the magnifying glass
    /// Resets a room and runs the code for entering the room
    /// </summary>
    internal class MagnifyGlass : UtilItem
    {
        //What the item does
        internal override void ItemAction(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            //Resets code in map because its easier to do room code there
            map.ResetRoom(player, rock, random, diceroller, scoreKeep, endGame, map);
        }
    }
}
