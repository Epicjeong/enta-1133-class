using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The players class
    /// Proceeds through the players turn
    /// Stores some player specific values
    /// </summary>
    internal class Player
    {
        //The number the player rolled
        private int playerRoll;
        //The value of what the player has collected
        private int playerScore;
        //The pickaxes durability
        private int playerSidesLeft;

        internal void SetPlayerSides()
        {
            //Sets the amount of durability the player starts with
            int.TryParse(Console.ReadLine(), out int startingSides);
            if (startingSides >= 10)
            {
                playerSidesLeft = startingSides;
            }
            //The reason the minimum is 10 is because I feel any below that would be unfun, at 10 there is at least some sembalence of chance
            else
            {
                Console.WriteLine("Please input a valid number");
                SetPlayerSides();
            }
        }

        //The players turn
        internal void PlayerTurn(Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            //Starts the dice roller aslong as you have durability left
            if ( playerSidesLeft == 0)
            {
                Console.WriteLine("As you have 0 durability you will now leave the mine");
                playerRoll = 0;
                endGame.PlayerWin(player, scoreKeep);
            }
            else
            {
                diceroller.RollDice(player);
                playerRoll = diceroller.GetDiceResult();
                int sidesUsed = diceroller.GetSidesUsed();
                playerSidesLeft = playerSidesLeft - sidesUsed;
                Console.WriteLine("You used " + sidesUsed + " of your durability, your pickaxe has " + playerSidesLeft + " more durability");
                //Puts breaks every now and again so the player has time to read
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }

        //Keeps track of what items have been obtained
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            {"Duct tape", 0 },
            {"Weird glue", 0 }
        };

        //Obtains items
        internal void GainItems()
        {
            //Randomizes which items are gained
            Random random = new Random();
            int randomItem = random.Next(1, 10);
            if (randomItem <= 5)
            {
                //Duct tape heals durability
                inventory["Duct tape"]++;
                Console.WriteLine("You now have " + inventory["Duct tape"] + " duct tape");
            }
            else if (randomItem > 5)
            {
                //Weird glue heals durability but is more random
                inventory["Weird glue"]++;
                Console.WriteLine("You now have " + inventory["Weird glue"] + " weird glue");
            }
        }

        internal void UseInventory()
        {
            int inventoryChoice;
            Console.WriteLine("You currently have " + inventory["Duct tape"] + " and " + inventory["Weird glue"] + " weird glue");
            Console.WriteLine("Press 1 to use duct tape (if any), 2 for weird glue (if any) and anything else to exit inventory");
            int.TryParse(Console.ReadLine(), out inventoryChoice);
            Random random = new Random();
            int durabilityHealed;
            if (inventoryChoice == 1 && inventory["Duct tape"] > 0)
            {
                durabilityHealed = random.Next(5, 10);
                playerSidesLeft = playerSidesLeft + durabilityHealed;
                Console.WriteLine("Your pickaxe healed " + durabilityHealed + " durability");
                Console.WriteLine("Your pickaxe now has " + playerSidesLeft + " durability");
                inventory["Duct tape"]--;
                Console.WriteLine("You have " + inventory["Duct tape"] + " duct tape left");
            }
            else if (inventoryChoice == 2 && inventory["Weird glue"]  > 0)
            {
                durabilityHealed = random.Next(1, 15);
                playerSidesLeft = playerSidesLeft + durabilityHealed;
                Console.WriteLine("Your pickaxe healed " + durabilityHealed + " durability");
                Console.WriteLine("Your pickaxe now has " + playerSidesLeft + " durability");
                inventory["Weird glue"]--;
                Console.WriteLine("You have " + inventory["Weird glue"] + " weird glue left");
            }
        }

        //Lets other classes get the players roll
        internal int GetPlayerRoll()
        {
            return playerRoll;
        }
        //Lets other classes get the amount of sides the player has left
        internal int GetPlayerSidesLeft()
        {
            return playerSidesLeft;
        }
        //Lets other classes get the players score
        internal int GetPlayerScore()
        {
            return playerScore;
        }
    }
}
