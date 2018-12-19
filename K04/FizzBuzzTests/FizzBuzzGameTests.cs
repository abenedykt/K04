using Xunit;

namespace FizzBuzzTests
{
    public class FizzBuzzGameTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]

        public void Play_GivenInteger_ReturnsValueMatchingGameRules(int input, string expected)
        {
            var game = new FizzBuzzGame();
            var result = game.Play(input);
            Assert.Equal(expected, result);
        }
    }
}
