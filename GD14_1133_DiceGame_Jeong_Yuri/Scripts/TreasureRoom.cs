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
        internal override void RoomDescription()
        {
            Console.WriteLine("A room with a cool rock in it");
        }
        internal override void OnRoomEntered(Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            Console.WriteLine("You have entered a room");
            Console.WriteLine("There is a rock that looks valuable, time to start digging!");
            rock.RockHealth(player, rock, diceroller, scoreKeep, gameController, endGame);
            scoreKeep.KeepScore(player, rock, diceroller, scoreKeep, gameController, endGame);
        }
        internal override void OnRoomSearched(Player player)
        {
            Console.WriteLine("There used to be a rock here");

        }
        internal override void OnRoomExit()
        {
            Console.WriteLine("You left the treasure room");
        }
    }
}
