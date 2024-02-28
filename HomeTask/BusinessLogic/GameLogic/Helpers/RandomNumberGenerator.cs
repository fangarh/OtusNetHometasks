using BusinessContracts.Helpers;

namespace GameLogic.Helpers
{
    public class RandomNumberGenerator : IRandomNumberGenerator 
    {
        public virtual int RandomNumber { get; }

        public RandomNumberGenerator()
        {
           
        }
    }
}
