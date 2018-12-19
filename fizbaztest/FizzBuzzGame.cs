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
            switch (x)
            {
                case uint b when b % 15 == 0:
                    return "FizzBuzz";
                case uint b when b % 3 == 0:
                    return "Fizz";
                case uint b when b % 5 == 0:
                    return "Buzz";
                default:
                    return x.ToString();
            }
        }
    }
}