using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class Computer
    {
        //Keeps track of the computer's dice rolls and the total of all dice rolls
        private int computerRoll;
        private int computerScore;
        internal void ComputerTurn()
        {
            //Creates the instance of diceroller so the computer can roll dice
            DiceRolls diceroller = new DiceRolls();
            diceroller.ComputerDice();

            //Gets the dice result from the diceroller and adds it to the computers total rolls
            int diceresult = diceroller.GetDiceResult();
            computerRoll = diceresult;
            computerScore = computerScore + computerRoll;
            Console.WriteLine("The Computer's total score is now " + computerScore);
        }

        //Allows other classes to get the computers roll
        internal int GetComputerRoll()
        {
            return computerRoll;
        }
    }
}
