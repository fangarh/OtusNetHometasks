namespace GameLogic.Helpers
{
    public class BonesRandomGenerator:RandomNumberGenerator
    {
        private readonly int _bonesNumber;

        public new int RandomNumber => DropBones();

        public BonesRandomGenerator(int bonesNumber = 2)
        {
            _bonesNumber = bonesNumber;
            _random = new Random();
        }

        private int DropBones()
        {
            int result = 0;

            for (int i = 0; i < _bonesNumber; i++)
            {
                result += _random.Next(6);
            }

            return result;
        }
    }
}
