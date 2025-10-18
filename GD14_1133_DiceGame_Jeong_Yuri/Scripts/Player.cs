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
        //The durability restored by items
        int durabilityRestoreded;
        //The value you have obtained from gems
        int valueFromGems;
        //Egg
        int hasEgg;

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
        internal void PlayerTurn(Player player, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame)
        {
            //Starts the dice roller aslong as you have durability left
            if ( playerSidesLeft == 0)
            {
                Console.WriteLine("As you are out of durability, you will now exit the mine");
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
            {"Weird glue", 0 },
            {"Gem", 0 },
            {"Magnifying glass", 0 }
        };

        //Obtains items
        internal void GainItems(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            //Randomizes which items are gained
            int randomItem = random.Next(1, 4);
            if (randomItem == 1)
            {
                //Duct tape heals durability
                Console.WriteLine("You got duct tape, it can restore some of your pickaxes durability");
                inventory["Duct tape"]++;
                Console.WriteLine("You now have " + inventory["Duct tape"] + " duct tape");
            }
            else if (randomItem == 2)
            {
                //Weird glue heals durability but is more random
                Console.WriteLine("You got weird glue, it can restore a more random of your pickaxes durability");
                inventory["Weird glue"]++;
                Console.WriteLine("You now have " + inventory["Weird glue"] + " weird glue");
            }
            else if (randomItem == 3)
            {
                //Gems adds more to total value of rocks
                Console.WriteLine("You got a gem, which adds to your total rock value");
                inventory["Gem"]++;
                Gem gem = new Gem();
                gem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
                Console.WriteLine("The gem was worth " + gem.gemValue);
                valueFromGems = valueFromGems + gem.gemValue;
                Console.WriteLine("You now have " + valueFromGems + " value from gems");
                Console.WriteLine("You now have " + inventory["Gem"] + " gem");
            }
            else if (randomItem == 4)
            {
                //Magnifying glass resets a room as if it has not been used
                Console.WriteLine("You got a magnifying glass, which finds more items or rocks depending on the room");
                inventory["Magnifying glass"]++;
                Console.WriteLine("You now have " + inventory["Magnifying glass"] + " magnifying glass");
            }
        }

        //Uses the items the player has in the inventory
        internal void UseInventory(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        {
            int inventoryChoice;
            Console.WriteLine("You currently have " + inventory["Duct tape"] + " duct tape, " + inventory["Weird glue"] + " weird glue and " + inventory["Magnifying glass"] + " magnifying glass");
            Console.WriteLine("You have " + inventory["Gem"] + " gem that add to $" + valueFromGems + " in additional value");
            Console.WriteLine("Press 1 to use duct tape (if any), 2 for weird glue (if any) and anything else to exit inventory");
            //This prevents using the magnifying glass while mining and the pandoras box that would open
            if (rock.GetRockHealth() <= 0)
            {
                Console.WriteLine("Or if you have a magnifying glass and not currently mining, press 3 to use a magnifying glass");
            }
            int.TryParse(Console.ReadLine(), out inventoryChoice);
            if (inventory["Duct tape"] > 0 || inventory["Weird glue"] > 0)
            {
                //Use duct tape
                if (inventoryChoice == 1 && inventory["Duct tape"] > 0)
                {
                    DuraItem selectedItem;
                    selectedItem = new DuctTape();
                    selectedItem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
                    durabilityRestoreded = selectedItem.duraRestored;
                    inventory["Duct tape"]--;
                    Console.WriteLine("You have " + inventory["Duct tape"] + " duct tape left");
                }
                //Use weird glue
                else if (inventoryChoice == 2 && inventory["Weird glue"] > 0)
                {
                    DuraItem selectedItem;
                    selectedItem = new WeirdGlue();
                    selectedItem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
                    durabilityRestoreded = selectedItem.duraRestored;
                    inventory["Weird glue"]--;
                    Console.WriteLine("You have " + inventory["Weird glue"] + " weird glue left");
                }
                playerSidesLeft = playerSidesLeft + durabilityRestoreded;
                Console.WriteLine("Your pickaxe restored " + durabilityRestoreded + " durability");
                Console.WriteLine("Your pickaxe now has " + playerSidesLeft + " durability");
            }
            //Use magnifying glass
            if (inventoryChoice == 3 && inventory["Magnifying glass"] > 0 && rock.GetRockHealth() <= 0)
            {
                inventory["Magnifying glass"]--;
                Console.WriteLine("You have " + inventory["Magnifying glass"] + " magnifying glass left");
                UtilItem selectedItem;
                selectedItem = new MagnifyGlass();
                selectedItem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
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
        //Lets other classes get the value from gems
        internal int GetValueFromGems()
        {
            return valueFromGems;
        }
        internal int GetHasEgg()
        {
            return hasEgg;
        }
        internal int SetHasEgg()
        {
            hasEgg = 1;
            return hasEgg;
        }
    }
}
