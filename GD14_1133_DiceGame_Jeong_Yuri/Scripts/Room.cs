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

        //Checks if the room is visited or not
        public bool hasVisited = false;

        //Description for the room
        internal abstract void RoomDescription();
        //When the room is entered
        internal virtual void OnRoomEntered(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            hasVisited = true;
        }
        //When the room is searched
        internal abstract void OnRoomSearched(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map);
        //When the room is exited
        internal abstract void OnRoomExit();

    }
}
