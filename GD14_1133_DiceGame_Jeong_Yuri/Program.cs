using GD14_1133_DiceGame_Jeong_Yuri.Scripts;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class Program
    {
        
        //Instanciates the game controller
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.PlayGame();
        }
    }
}
