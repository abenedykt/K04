using System;

namespace fizbaztest
{
    internal class FizzBuzzGame
    {
        public FizzBuzzGame()
        {
        }

        internal string Play(uint x)
        {
            if (x % 15 == 0) return "FizzBuzz";
            if (x % 3 == 0) return "Fizz";
            if (x % 5 == 0) return "Buzz";
            
            return x.ToString();
        }
    }
}