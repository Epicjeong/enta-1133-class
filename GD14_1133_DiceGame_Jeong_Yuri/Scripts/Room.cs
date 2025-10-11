using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The abstract room
    /// The base template for other rooms
    /// </summary>
    internal abstract class Room
    {
        //Creates the directions, rows, and columns for the linking of rooms
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }
        public int Row;
        public int Column;
        public Room(int row, int column)
        {
            Row = row;
            Column = column;
        }


        bool hasVisited;
        internal abstract void RoomDescription();
        internal abstract void OnRoomEntered(Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame);
        internal abstract void OnRoomSearched(Player player);
        internal abstract void OnRoomExit();

    }
}
