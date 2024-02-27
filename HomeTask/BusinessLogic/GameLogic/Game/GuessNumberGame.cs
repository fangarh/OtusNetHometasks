using BusinessContracts.Game;
using BusinessContracts.Helpers;
using BusinessContracts.Logger;
using GameLogic.Helpers;
using GameLogic.Logger;

namespace GameLogic.Game
{
    public class GuessNumberGame:IGuessNumberGame
    {
        private readonly IGuessChecker _checker;
        private readonly IRandomNumberGenerator _randomizer;
        private readonly IMyLogger _logger;

        public int WinCount { get; }
        public int LooseCount { get; }

        public GuessNumberGame(IGuessChecker checker = null, IRandomNumberGenerator randomizer = null, IMyLogger logger = null)
        {
            _checker = checker ?? new GuessChecker();
            _randomizer = randomizer ?? new ExtRandomNumberGenerator(500);
            _logger = logger ?? new MyMemoryLogger();
        }

        public void Play(int tryCount, int roundCount = 1)
        {
            for (int i = 0; i < roundCount; i++)
            {
                int number = _randomizer.RandomNumber;
                Console.WriteLine($"Раунд №{i} начался. Для выхода введите '\\q' или '\\в'");

                switch (PlayRound(tryCount))
                {
                    
                }
            }
        }

        private RoundResult PlayRound(int tryCount)
        {
            for (int j = 0; j < tryCount; j++)
            {
                Console.WriteLine($"Введите число: ");
                var inStr = Console.ReadLine();

                if (!Int32.TryParse(inStr, out var choice))
                {

                }
            }

            return RoundResult.Loose;
        }
    }
}
