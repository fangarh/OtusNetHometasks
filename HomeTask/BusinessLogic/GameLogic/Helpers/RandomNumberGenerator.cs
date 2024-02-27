using BusinessContracts.Helpers;

namespace GameLogic.Helpers
{
    public class RandomNumberGenerator : IRandomNumberGenerator 
    {
        protected Random _random;

        public int RandomNumber => _random.Next();

        public RandomNumberGenerator()
        {
            _random = new Random();
        }
    }
}
