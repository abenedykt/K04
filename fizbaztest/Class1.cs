using System;
using Xunit;

namespace fizbaztest
{
    public class FizzBuzzTests
    {
        private readonly FizzBuzzGame game;
        private readonly Func<uint, string> act;

        public FizzBuzzTests()
        {
            game = new FizzBuzzGame();
            act = (i) => game.Play(i);
        }

        [Theory, InlineData(1, "1"), InlineData(2, "2"), InlineData(3, "Fizz"), InlineData(5, "Buzz"), InlineData(15, "FizzBuzz")]

        public void Returns_values_according_to_Fixx_Buzz_game_rules(uint input, string expected)
        {
            //act
            var result = act(input);

            //assert
            Assert.Equal(expected, result);
        }
    }

}
