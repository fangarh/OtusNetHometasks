using BusinessContracts.Game;
using BusinessContracts.Logger;
using GameLogic.Logger;

namespace GameLogic.Game
{
    public class GuessChecker:IGuessChecker
    {
        private int _guessingNumber;
        private bool _initialized;
        private readonly IMyLogger _logger;

        public int TryCount { get; private set; } = 0;

        public GuessChecker(IMyLogger logger = null)
        {
            _guessingNumber = -1;
            _logger = logger ?? new MyMemoryLogger();
            _initialized = false;
        }

        public GuessResult TryGuess(int number)
        {
            if (!_initialized)
            {
                _logger?.Log("Game checker not initialized");
                return GuessResult.Unknown;
            }

            TryCount ++;
            
            _logger?.Log($"Checking value:{number}, correct:{_guessingNumber} try: {TryCount}");

            if (number < _guessingNumber)
                return GuessResult.Less;
            
            if (number > _guessingNumber)
                return GuessResult.More;

            return GuessResult.Equals;
        }

        public void Initialize(int guessNumber)
        {
            _guessingNumber = guessNumber;
            TryCount = 0;
        }
    }
}
