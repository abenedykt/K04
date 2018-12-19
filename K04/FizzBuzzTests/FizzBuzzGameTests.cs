using Xunit;

namespace FizzBuzzTests
{
    public class FizzBuzzGameTests
    {
        [Fact]
        public void When_play_1_returns_1()
        {
            // arrange
            var game = new FizzBuzzGame();

            // act
            var result = game.Play(1);

            //assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_play_2_returns_2()
        {
            // arrange
            var game = new FizzBuzzGame();

            // act
            var result = game.Play(2);

            //assert
            Assert.Equal("2", result);
        }

        [Fact]
        public void When_play_3_returns_Fizz()
        {
            // arrange
            var game = new FizzBuzzGame();

            // act
            var result = game.Play(3);

            //assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void When_play_4_returns_4()
        {
            var game = new FizzBuzzGame();
            var result = game.Play(4);
            Assert.Equal("4", result);
        }

        [Fact]
        public void When_play_5_returns_Buzz()
        {
            var game = new FizzBuzzGame();
            var result = game.Play(5);
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void When_play_15_returns_FizzBuzz()
        {
            var game = new FizzBuzzGame();
            var result = game.Play(15);
            Assert.Equal("FizzBuzz", result);
        }
    }
}
