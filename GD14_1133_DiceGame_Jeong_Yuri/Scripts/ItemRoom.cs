using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    internal class ItemRoom : Room
    {
        /// <summary>
        /// The item room
        /// Inherits from Room, contains items that restore durability
        /// </summary>

        //Allows use for the rows and columns used to link rooms
        public ItemRoom(int row, int column) : base(row, column)
        {
            Row = row;
            Column = column;
        }

        internal override void RoomDescription()
        {
            Console.WriteLine("A room with some items in it");
        }
        internal override void OnRoomEntered(Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            Console.WriteLine("You have entered a room");
        }
        internal override void OnRoomSearched(Player player)
        {
            Console.WriteLine("There are some items laying around");
            player.GainItems();
        }
        internal override void OnRoomExit()
        {
            Console.WriteLine("You left the item room");
        }
    }
}
