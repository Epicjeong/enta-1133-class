using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// Map created and radomized here
    /// </summary>
    internal class Map
    {
        int x = 3, y = 3;
        //Initial initialization of rooms on a map
        private Room[,] map;

        //Creates a 3 by 3 map where the rooms are placed
        internal void CreateMap(int selection,int direction, Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            map = new Room[3, 3];
            Random random = new Random();
            Room room;

            for (int i = 0; i < x; i++)
            {
                //Initializes the rooms and the random decision to choose which room
                int roomType = random.Next(1, 6);
                //Randomly decides between a treasure or item room
                if (roomType >= 3)
                {
                    room = new TreasureRoom(0, i);
                }
                else
                {
                    room = new ItemRoom(0, i);
                }
                map[0, i] = room;
                for (int j = 0; j < y; j++)
                {
                    //Initializes the rooms and the random decision to choose which room
                    roomType = random.Next(1, 6);
                    //Randomly decides between a treasure or item room
                    if (roomType >= 3)
                    {
                        room = new TreasureRoom(i, j);
                    }
                    else
                    {
                        room = new ItemRoom(i, j);
                    }
                    map[i, j] = room;
                }
            }

            //Link rooms together so you can move between them
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Room currentRoom = map[i, j];
                    //Links the room to the north
                    if (j > 0)
                    {
                        currentRoom.North = map[i, j - 1];
                    }
                    //Links east room
                    if (i < 3)
                    {
                        currentRoom.East = map[i, j];
                    }
                    //Links south room
                    if (j < 3)
                    {
                        currentRoom.South = map[i, j];
                    }
                    //Links west room
                    if (i > 0)
                    {
                        currentRoom.West = map[i - 1, j];
                    }
                }
            }
            Room current = map[x = 1, y = 1];
            current.OnRoomEntered(player, rock, diceroller, scoreKeep, gameController, endGame);
            //Lets the player start to move around
            PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
        }
        //Gives the choice to move, search the room, check the inventory, or leave the mine
        internal void PlayerChoice(int selection, int direction, Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Checks the current room
            Room currentRoom = map[x, y];
            Console.WriteLine("What would you like to do? (1 to move to a different room, 2 to search the room you are in, 3 to check your inventory)");
            Console.WriteLine("If you're ready to exit the mine, press 4 instead");
            //Receives input
            int.TryParse(Console.ReadLine(), out selection);
            //Move
            if (selection == 1)
            {
                MoveFromRoom(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
            }
            //Search
            else if (selection == 2)
            {
                currentRoom.OnRoomSearched(player);
                PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
            }
            //Inventory
            else if (selection == 3)
            {
                player.UseInventory();
                PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
            }
            //Leave
            else if (selection == 4)
            {
                endGame.PlayerWin(player, scoreKeep);
            }
            //For invalid inputs
            else
            {
                Console.WriteLine("Please enter a valid option");
                PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
            }
        }

        //Moves the player from room to room
        internal void MoveFromRoom(int selection, int direction, Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Initializes the current room
            Room currentRoom = map[x, y];
            Console.WriteLine("Which direction would you like to move? (1 is north, 2 is east, 3 is south, 4 is west");
            Console.WriteLine("Or press anything else to do something else)");
            //Gets the input that controls where to move
            int.TryParse(Console.ReadLine(), out direction);
            //Moves to the room north of the current room
            if (direction == 1)
            {
                if (y == 0)
                {
                    //If you cant go further north
                    Console.WriteLine("You can not go any further north");
                    MoveFromRoom(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                }
                else
                {
                    currentRoom.OnRoomExit();
                    currentRoom = map[x, y = y - 1];
                    currentRoom.OnRoomEntered(player, rock, diceroller, scoreKeep, gameController, endGame);
                    if (player.GetPlayerSidesLeft() == 0)
                    {
                        endGame.PlayerWin(player, scoreKeep);
                    }
                    else
                    {
                        PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                    }
                }
            }
            //Moves east
            else if (direction == 2)
            {
                if (x == 2)
                {
                    //If you cant
                    Console.WriteLine("You can not go any further east");
                    MoveFromRoom(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                }
                else
                {
                    currentRoom.OnRoomExit();
                    currentRoom = map[x = x - 1, y];
                    currentRoom.OnRoomEntered(player, rock, diceroller, scoreKeep, gameController, endGame);
                    if (player.GetPlayerSidesLeft() == 0)
                    {
                        endGame.PlayerWin(player, scoreKeep);
                    }
                    else
                    {
                        PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                    }
                }
            }
            //Moves south
            else if (direction == 3)
            {
                //If you cant
                if (y == 2)
                {
                    Console.WriteLine("You can not go any further south");
                    MoveFromRoom(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                }
                else
                {
                    currentRoom.OnRoomExit();
                    currentRoom = map[x, y = y + 1];
                    currentRoom.OnRoomEntered(player, rock, diceroller, scoreKeep, gameController, endGame);
                    if (player.GetPlayerSidesLeft() == 0)
                    {
                        endGame.PlayerWin(player, scoreKeep);
                    }
                    else
                    {
                        PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                    }
                }
            }
            //Moves west
            else if (direction == 4)
            {
                //If you cant
                if (y == 0)
                {
                    Console.WriteLine("You can not go any further west");
                    MoveFromRoom(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                }
                else
                {
                    currentRoom.OnRoomExit();
                    currentRoom = map[x = x + 1, y];
                    currentRoom.OnRoomEntered(player, rock, diceroller, scoreKeep, gameController, endGame);
                    if (player.GetPlayerSidesLeft() == 0)
                    {
                        endGame.PlayerWin(player, scoreKeep);
                    }
                    else
                    {
                        PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
                PlayerChoice(selection, direction, player, rock, diceroller, scoreKeep, gameController, endGame);
            }
        }
        //Lets other classes get the currently occupied room
        internal Room GetRoom(int x, int y)
        {
            return map[x, y];
        }
    }
}
