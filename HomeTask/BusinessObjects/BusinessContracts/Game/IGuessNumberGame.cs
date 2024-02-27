namespace BusinessContracts.Game
{
    public interface IGuessNumberGame
    {
        public int WinCount { get; }
        public int LooseCount { get; }
        void Play(int tryCount, int roundCount = 1);
    }
}
