namespace BusinessContracts.Game
{
    public interface IGuessChecker
    {
        public int TryCount { get; }
        GuessResult TryGuess(int number);
        void Initialize(int guessNumber);
    }
}
