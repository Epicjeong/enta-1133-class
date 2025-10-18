using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The item room
    /// Inherits from Room, contains items that restore durability
    /// </summary>
    internal class Man : Room
    {
        //Allows use for the rows and columns used to link rooms
        public Man(int row, int column) : base(row, column)
        {
            Row = row;
            Column = column;
        }

        //Description for the room
        internal override void RoomDescription()
        {
            if (hasVisited == false)
            {
                Console.WriteLine("A room");
            }
            //If already searched
            else
            {
                Console.WriteLine("An empty room");
            }
        }
        //When the room is entered
        internal override void OnRoomEntered(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            RoomDescription();
        }
        //When the room is searched
        internal override void OnRoomSearched(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            if (hasVisited == false)
            {
                Console.WriteLine("Well, there is a man here");
                player.SetHasEgg();
                hasVisited = true;
            }
            //If already searched
            else
            {
                Console.WriteLine("Nothing left to take");
            }
        }
        //When the room is exited
        internal override void OnRoomExit()
        {
            if (hasVisited == false)
            {
                Console.WriteLine("You left the room");
            }
            else
            {
                Console.WriteLine("You left the item room");
            }
        }
    }
}
