using Xunit;

namespace FizzBuzzTests
{
    public class FizzBuzzGameTest
    {
        [Fact]
        public void When_play_1_returns_1()
        {
            //arange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(1);

            //assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_play_2_returns_2()
        {
            //arange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(2);

            //assert
            Assert.Equal("2", result);
        }

        [Fact]
        public void When_play_3_returns_Fizz()
        {
            //arange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(3);

            //assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void When_play_4_returns_4()
        {
            //arange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(4);

            //assert
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

    public class FizzBuzzGame
    {
        public string Play(int i)
        {
            if (i % 15 == 0)
            {
                return "FizzBuzz";
            }

            if (i % 3 == 0)
            {
                return "Fizz";
            }

            if (i % 5 == 0)
            {
                return "Buzz";
            }


            return i.ToString();
        }
    }
}
