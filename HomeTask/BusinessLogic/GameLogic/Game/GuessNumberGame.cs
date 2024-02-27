using BusinessContracts.Game;
using BusinessContracts.Helpers;
using BusinessContracts.Logger;
using GameLogic.Helpers;

namespace GameLogic.Game
{
    public class GuessNumberGame:IGuessNumberGame
    {
        private readonly IGuessChecker _checker;
        private readonly IRandomNumberGenerator _randomizer;
        private readonly IMyLogger _logger;

        public GuessNumberGame(IGuessChecker checker = null, IRandomNumberGenerator randomizer = null, IMyLogger logger = null)
        {
            _checker = checker ?? new GuessChecker();
            _randomizer = randomizer;
            _logger = logger;
        }

        public void Play(int tryCount, int roundCount = 1)
        {
            throw new NotImplementedException();
        }
    }
}
