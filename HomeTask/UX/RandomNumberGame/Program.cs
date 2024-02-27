using GameLogic.Helpers;

namespace RandomNumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExtRandomNumberGenerator erd = new();
            BonesRandomGenerator brd = new(3);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ER: {erd.RandomNumber} BR: {brd.RandomNumber}");
            }

            Console.ReadKey();
        }
    }
}
