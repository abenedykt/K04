using System;
using Xunit;

namespace FizzBuzzTests
{
    public class FizzBuzzGameTests_Refactored
    {
        private readonly FizzBuzzGame _game;
        private readonly Func<int, string> _act;

        public FizzBuzzGameTests_Refactored()
        {
            _game = new FizzBuzzGame();
            _act = (arg) => _game.Play(arg);
        }

        [Theory,
        InlineData(1,"1"),
        InlineData(2,"2"),
        InlineData(3,"Fizz"),
        InlineData(5,"Buzz"),
        InlineData(15,"FizzBuzz")
            ]
        public void When_play_1_returns_1(int input, string expected)
        {
            var result = _act(input);

            Assert.Equal(expected, result);
        }
    }
}
