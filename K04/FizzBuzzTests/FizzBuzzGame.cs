namespace FizzBuzzTests
{
    internal class FizzBuzzGame
    {
        internal string Play(int x)
        {
            return x % 3 == 0 ? x % 5 == 0 ? "FizzBuzz" : "Fizz" : x % 5 == 0 ? "Buzz" : x.ToString();
        }
    }
}