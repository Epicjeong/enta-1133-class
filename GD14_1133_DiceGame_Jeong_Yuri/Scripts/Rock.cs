using GD14_1133_DiceGame_Jeong_Yuri.Scripts;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The rocks class
    /// Sets the rocks health
    /// </summary>
    internal class Rock
    {
        //Stores the rocks max hp
        private int rockMaxHealth;
        //Keeps track of how close the rock is to breaking
        private int rockHealth;
        internal void RockHealth(Player player, Rock rock, DiceRolls diceroller, ScoreKeeper scoreKeep, GameController gameController, EndGame endGame)
        {
            diceroller.ComputerDice(rock);

            //Gets the dice result from the diceroller and adds it to the computers total rolls
            int diceresult = diceroller.GetDiceResult();
            rockHealth = diceresult;
            rockMaxHealth = rockHealth;
        }

        internal void BreakRock(Player player)
        {
            Console.WriteLine(rockHealth);
            rockHealth = rockHealth - player.GetPlayerRoll();
            Console.WriteLine(rockHealth);
        }

        //Lets other classes get the rocks health
        internal int GetRockHealth()
        {
            return rockHealth;
        }
        //Lets other classes get the rocks max health
        internal int GetRockMaxHealth()
        {
            return rockMaxHealth;
        }
    }
}
