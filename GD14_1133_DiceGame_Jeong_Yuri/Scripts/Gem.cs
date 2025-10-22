using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    internal class Gem : UtilItem
    {
        //The value of the found gem
        public int gemValue;

        //What the item does
        internal override void ItemAction(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            //Makes a random gem value
            gemValue = random.Next(4, 10);
        }
    }
}
