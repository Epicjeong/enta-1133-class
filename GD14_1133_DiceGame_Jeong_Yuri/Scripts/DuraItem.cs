using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The subclass for durability items
    /// Shortened to dura for length
    /// A template for items that restore durability
    /// </summary>
    internal class DuraItem : Item
    {
        //Minimum, max, and the actual amount of durability restored
        public int minDuraRestored;
        public int maxDuraRestored;
        public int duraRestored;

        //What the item does
        internal override void ItemAction(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {

        }
    }
}
