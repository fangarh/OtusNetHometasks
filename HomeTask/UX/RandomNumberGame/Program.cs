using GameLogic.Game;
using GameLogic.Helpers;
using GameLogic.Logger;

namespace RandomNumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new MyMemoryLogger();
            var guessChecker = new GuessChecker(logger);
            var rnd = new BonesRandomGenerator(4);
            GuessNumberGame game = new(guessChecker, rnd, logger);
            game.Play(5,2);
        }
    }
}
