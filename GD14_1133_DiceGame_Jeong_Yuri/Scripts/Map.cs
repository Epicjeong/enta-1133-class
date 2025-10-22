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
        //Sets size of the map
        const int x = 3, y = 3;
        //Initial initialization of rooms on a map
        private Room[,] layout;
        bool exploring;
        private Room currentRoom;

        //Keeps track of the amount of unique rooms visited
        int roomsUsed;

        //Creates a 3 by 3 map where the rooms are placed
        internal void CreateMap(int selection,int direction, Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            //Sets up the layout of the rooms and the rooms
            layout = new Room[3, 3];
            Room room;

            for (int i = 0; i < x; i++)
            {
                //Initializes the rooms and the random decision to choose which room
                //int roomType = random.Next(1, 133);
                int roomType = 66;
                //Randomly decides between a treasure or item room
                if (roomType > 66)
                {
                    room = new TreasureRoom(0, i);
                }
                else if (roomType < 66)
                {
                    room = new ItemRoom(0, i);
                }
                else
                {
                    room = new Man(0, i);
                }
                layout[0, i] = room;
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
                    layout[i, j] = room;
                }
            }


            //Link rooms together so you can move between them
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Room? currentRoom = layout[i, j];
                    //Links the room to the north
                    if (j > 0)
                    {
                        currentRoom.North = layout[i, j - 1];
                    }
                    else
                    {
                        currentRoom.North = null;
                    }
                    //Links east room
                    if (i < 2)
                    {
                        currentRoom.East = layout[i + 1, j];
                    }
                    else
                    {
                        currentRoom.East = null;
                    }
                    //Links south room
                    if (j < 2)
                    {
                        currentRoom.South = layout[i, j + 1];
                    }
                    else
                    {
                        currentRoom.South = null;
                    }
                    //Links west room
                    if (i > 0)
                    {
                        currentRoom.West = layout[i - 1, j];
                    }
                    else
                    {
                        currentRoom.West = null;
                    }
                }
            }

            //Allows the game to loop after its finished
            exploring = true;
            roomsUsed = 0;
            //Starts the player at the centre of the grid
            currentRoom = layout[1, 1];
            currentRoom.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
            //Lets the player start to move around
            PlayerChoice(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
        }
        //Gives the choice to move, search the room, check the inventory, or leave the mine
        internal void PlayerChoice(int selection, int direction, Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            while (exploring == true)
            {
                Console.WriteLine("What would you like to do? (1 to move to a different room, 2 to search the room you are in, 3 to check your inventory)");
                Console.WriteLine("If you're ready to exit the mine, press 4 instead");
                //Receives input
                int.TryParse(Console.ReadLine(), out selection);
                switch (selection)
                {
                    case 1:
                        MoveFromRoom(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
                        break;
                    case 2:
                        currentRoom.OnRoomSearched(player, rock, random, diceroller, scoreKeep, endGame, map);
                        break;
                    case 3:
                        player.UseInventory(player, rock, random, diceroller, scoreKeep, endGame, map);
                        break;
                    case 4:
                        exploring = false;
                        endGame.PlayerWin(player, scoreKeep, map);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
                if (currentRoom.hasVisited == true)
                {
                    roomsUsed++;
                }
                //Automatically ends the game if every room is explored
                if (roomsUsed >= 9 || player.GetPlayerSidesLeft() <= 0)
                {
                    if (roomsUsed >= 9)
                    { 
                    Console.WriteLine("You have acquired everything in the mines, and will now leave");
                    }
                    else if (player.GetPlayerSidesLeft() <= 0)
                    {
                        Console.WriteLine("As you are out of durability, you will now leave the mine");
                    }
                    exploring = false;
                    endGame.PlayerWin(player, scoreKeep, map);
                }
            }
        }

        //Moves the player from room to room
        internal void MoveFromRoom(int selection, int direction, Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            Console.WriteLine("Which direction would you like to move? (1 is north, 2 is east, 3 is south, 4 is west");
            Console.WriteLine("Or press anything else to do something else)");
            //Gets the input that controls where to move
            int.TryParse(Console.ReadLine(), out direction);
            //Moves to the room north of the current room
            switch (direction)
            {
                case 1:
                    if (currentRoom.North == null)
                    {
                        //If you cant go further north
                        Console.WriteLine("You can not go any further north");
                        MoveFromRoom(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
                    }
                    else
                    {
                        currentRoom.OnRoomExit();
                        currentRoom = currentRoom.North;
                        currentRoom.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
                    }
                    break;
                case 2:
                    if (currentRoom.East == null)
                    {
                        //If you cant
                        Console.WriteLine("You can not go any further east");
                        MoveFromRoom(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
                    }
                    else
                    {
                        currentRoom.OnRoomExit();
                        currentRoom = currentRoom.East;
                        currentRoom.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
                    } 
                    break;
                case 3:
                    if (currentRoom.South == null)
                    {
                        //If you cant
                        Console.WriteLine("You can not go any further south");
                        MoveFromRoom(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
                    }
                    else
                    {
                        currentRoom.OnRoomExit();
                        currentRoom = currentRoom.South;
                        currentRoom.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
                    } 
                    break;
                case 4:
                    if (currentRoom.West == null)
                    {
                        //If you cant
                        Console.WriteLine("You can not go any further west");
                        MoveFromRoom(selection, direction, player, rock, random, diceroller, scoreKeep, endGame, map);
                    }
                    else
                    {
                        currentRoom.OnRoomExit();
                        currentRoom = currentRoom.West;
                        currentRoom.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
                    }
                    break;
            }
        }
        //Resets the current room like it was entered for the first time
        internal void ResetRoom(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            Console.WriteLine("The magnifying glass reveals a rock you didnt see");
            roomsUsed--;
            currentRoom.hasVisited = true;
            currentRoom.OnRoomEntered(player, rock, random, diceroller, scoreKeep, endGame, map);
        }
    }
}
