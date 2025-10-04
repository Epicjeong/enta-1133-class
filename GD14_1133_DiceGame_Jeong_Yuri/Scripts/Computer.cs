using GD14_1133_DiceGame_Jeong_Yuri.Scripts;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The computers class
    /// Proceeds through the computers turn
    /// Stores some computer specific values
    /// </summary>
    internal class Computer
    {
        //Keeps track of the computer's dice rolls, the amount of sides it has left, and the total of all dice rolls
        private int computerRoll;
        private int computerScore;
        private int computerSidesLeft = 50;
        internal void ComputerTurn(Player player, Computer computer, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            diceroller.ComputerDice(computer);

            //Gets the dice result from the diceroller and adds it to the computers total rolls
            int diceresult = diceroller.GetDiceResult();
            computerRoll = diceresult;
            computerScore = computerScore + computerRoll;
            computerSidesLeft = computerSidesLeft - diceroller.GetSidesUsed();
            Console.WriteLine("The Computer's total score is now " + computerScore);
            Console.WriteLine("The Computer now has " + computerSidesLeft + " sides left");
            //Puts breaks every now and again so the player has time to read
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            //Continues to either the players turn or to compare the rolls if thats already happened
            if (diceroller.GetPlayerHasRolled() == false)
            {
                player.PlayerTurn(player, computer, diceroller, scoreKeep, gameController, endGame);
            }
            else
            {
                scoreKeep.KeepScore(player, computer, diceroller, scoreKeep, gameController, endGame);
            }
        }

        //Lets other classes get the computers roll
        internal int GetComputerRoll()
        {
            return computerRoll;
        }
        //Lets other classes get the amount of sides the computer has left
        internal int GetComputerSidesLeft()
        {
            return computerSidesLeft;
        }
        //Lets other classes get the computers score
        internal int GetComputerScore()
        {
            return computerScore;
        }
    }
}
