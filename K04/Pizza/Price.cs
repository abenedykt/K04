using Pizza.Abstract;

namespace Pizza
{
    public class Price : IPrice
    {
        public Price(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}
