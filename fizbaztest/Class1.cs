using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace fizbaztest
{
    public class Class1
    {
        [Fact]
        public void When_1_Return_1()
        {
            //arrange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(1);

            //assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_2_Return_2()
        {
            //arrange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(2);

            //assert
            Assert.Equal("2", result);
        }

        [Fact]
        public void When_3_Return_Fizz()
        {
            //arrange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(3);

            //assert
            Assert.Equal("Fizz", result);
        }
        [Fact]
        public void When_4_Return_4()
        {
            //arrange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(4);

            //assert
            Assert.Equal("4", result);
        }
        [Fact]
        public void When_5_Return_Buzz()
        {
            //arrange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(5);

            //assert
            Assert.Equal("Buzz", result);
        }
        [Fact]
        public void When_15_Return_FizzBuzz()
        {
            //arrange
            var game = new FizzBuzzGame();

            //act
            var result = game.Play(15);

            //assert
            Assert.Equal("FizzBuzz", result);
        }
    }
}
