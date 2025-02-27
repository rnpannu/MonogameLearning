using MonogameLearning;
using MonogameLearning.src; // Ensure the correct namespace is used

namespace MonogameLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            using var game = new MonogameLearning.src.Game1(); // Ensure Game1 class is in the correct namespace
            game.Run();

        }
    }
}
