using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Helpers
{
    public class ExtRandomNumberGenerator:RandomNumberGenerator
    {
        private int _upperVal;
        public new int RandomNumber => _random.Next(_upperVal);

        public ExtRandomNumberGenerator(int upperVal = 1000)
        {
            _random = new Random();
            _upperVal = upperVal;
        }
    }
}
