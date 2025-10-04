using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The final calculations
    /// Decides the winner of the game
    /// Even MORE tiebreakers
    /// </summary>
    internal class EndGame
    {
        int playerFinalRoll;
        int computerFinalRoll;
        internal void DeclareVictory(Player player, Computer computer, ScoreKeeper scoreKeeper)
        {
            //Declares the player the victor
            if (scoreKeeper.GetPlayerPoints() > scoreKeeper.GetComputerPoints())
            {
                //So we can reuse the player win message
                PlayerWin(player);
            }
            //Declares the Computer the victor, forfieting the players soul to the olde ones
            if (scoreKeeper.GetComputerPoints() > scoreKeeper.GetPlayerPoints())
            {
                //So we can reuse the computer win message
                ComputerWin(player, computer);
            }
            //Incase of a tie
            if (scoreKeeper.GetPlayerPoints() == scoreKeeper.GetComputerPoints())
            {
                //Proceeds to the tie breaker
                TieBreaker(player, computer);
            }
        }
        //Player win message
        internal void PlayerWin(Player player)
        {
            Console.WriteLine("YOU WON! Excellent job, your total rolls added to " + player.GetPlayerScore() + " and you still have");
            //This line can be read as sarcastic or genuine based on how many sides you ended with
            Console.WriteLine(player.GetPlayerSidesLeft() + " sides in reserve. Go spend them on something nice, you deserve it");
        }
        //Computer win message
        internal void ComputerWin(Player player, Computer computer)
        {
            Console.WriteLine("It seems you lost, a shame too. You still had " + player.GetPlayerSidesLeft() + " in reserve while the computer still had");
            Console.WriteLine(computer.GetComputerSidesLeft() + " sides left");
        }
        //Decides who wins if both points are the same
        internal void TieBreaker(Player player, Computer computer)
        {
            Console.WriteLine("It seems that you and the computer have reached the end with the same amount of points");
            Console.WriteLine("So now we will take the total of both you and the computers rolls, the lower total will win");
            //Puts breaks every now and again so the player has time to read
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            //Player tie win
            if (player.GetPlayerScore() < computer.GetComputerScore())
            {
                Console.WriteLine("And that would be you, with a score of " + player.GetPlayerScore() + " compared to the computers " + computer.GetComputerScore());
                PlayerWin(player);
            }
            //Computer tie win
            if (computer.GetComputerScore()  < player.GetPlayerScore())
            {
                Console.WriteLine("And that would be the computer, with a score of " + computer.GetComputerScore() + " compared to your " + player.GetPlayerScore());
                ComputerWin(player, computer);
            }
            //Incase they somehow tie again
            if (computer.GetComputerScore() == player.GetPlayerScore())
            {
                Console.WriteLine("How did you manage to get the same score as each other???");
                Console.WriteLine("Guess we'll be rolling with the sides you have left then");
                //Puts breaks every now and again so the player has time to read
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                HowDidYourManageToTieTwice(player, computer);
            }
        }
        //The second tiebreaker
        internal void HowDidYourManageToTieTwice(Player player, Computer computer)
        {
            //If the player has 0 sides left they instantly lose
            if (player.GetPlayerSidesLeft() == 0)
            {
                Console.WriteLine("But as you have 0 sides left, you lose by default!");
                //Just adding 1 to the computers final roll and leaving the players at 0 needs the least code to insta lose
                playerFinalRoll = 0;
                computerFinalRoll = 1;
            }
            //Rolls with the sides unused, which is why the computer not being able to use all of its points is important
            else
            {
                Random random = new Random();
                int playerMaxRoll = player.GetPlayerSidesLeft();
                playerFinalRoll = random.Next(1, playerMaxRoll);
                int computerMaxRoll = computer.GetComputerSidesLeft();
                computerFinalRoll = random.Next(1, computerMaxRoll);
                //Displays the final rolls
                Console.WriteLine("Your final roll was " + playerFinalRoll + " and the computers was " + computerFinalRoll);
            }
            //Player 2nd tiebreaker win
            if (playerFinalRoll > computerFinalRoll)
            {
                PlayerWin(player);
            }
            //Computer 2nd tiebreaker win
            if (computerFinalRoll > playerFinalRoll)
            {
                ComputerWin(player, computer);
            }
            //If you somehow tie again
            if (computerFinalRoll == playerFinalRoll)
            {
                Console.WriteLine("No, we are not making a THIRD tiebreaker, roll again");
                HowDidYourManageToTieTwice(player, computer);
            }

        }
    }
}
