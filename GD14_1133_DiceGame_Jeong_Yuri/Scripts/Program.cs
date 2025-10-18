using GD14_1133_DiceGame_Jeong_Yuri.Scripts;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// Starts game
    /// </summary>
    internal class Program
    {
        
        //Instanciates the game controller and starts the game
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.StartGame();
        }
    }
}
