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
    internal class ItemRoom : Room
    {
        //Allows use for the rows and columns used to link rooms
        public ItemRoom(int row, int column) : base(row, column)
        {
            Row = row;
            Column = column;
        }

        //Description for the room
        internal override void RoomDescription()
        {
            if (hasVisited == false)
            {
                Console.WriteLine("Its a room with some items in it");
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
            Console.WriteLine("You have entered a room");
            RoomDescription();
        }
        //When the room is searched
        internal override void OnRoomSearched(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            if (hasVisited == false)
            {
                Console.WriteLine("There are some items laying around");
                player.GainItems(player, rock, random, diceroller, scoreKeep, endGame, map);
                base.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);

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
            Console.WriteLine("You left the item room");
        }
    }
}
