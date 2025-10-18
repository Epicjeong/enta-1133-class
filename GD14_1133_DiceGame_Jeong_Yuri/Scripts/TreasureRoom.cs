using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The treasure room
    /// Inherits from Room, contains the loop for the dice game
    /// </summary>
    internal class TreasureRoom : Room
    {
        //Allows use for the rows and columns used to link rooms
        public TreasureRoom(int row, int column) : base(row, column)
        {
            Row = row;
            Column = column;
        }

        //Description for the room
        internal override void RoomDescription()
        {
            Console.WriteLine("Its a room with a cool rock in it");
        }
        //When the room is entered
        internal override void OnRoomEntered(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            Console.WriteLine("You have entered a room");
            if (hasVisited == false)
            {
                RoomDescription();
                Console.WriteLine("There is a rock that looks valuable, time to start digging!");
                rock.RockHealth(player, rock, diceroller, scoreKeep, endGame);
                scoreKeep.KeepScore(player, rock, random, diceroller, scoreKeep, endGame, map);
                base.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
            }
            else
            {
                //If already mined
                Console.WriteLine("An empty room");
            }
        }
        //When the room is searched
        internal override void OnRoomSearched(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            Console.WriteLine("There used to be a rock here");
        }
        //When the room is exited
        internal override void OnRoomExit()
        {
            Console.WriteLine("You left the treasure room");
        }
    }
}
