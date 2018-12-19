using FluentAssertions;
using NSubstitute;
using System.Linq;
using Xunit;

namespace Pizza
{
    public class OrderPriceTests
    {
        [Fact]
        public void NewTest()
        {
            // Order
            // 4 kawałki pepperoni (30 pln za pizze)
            // 4 kawałki hawajskiej (40 pln za pizze)
            // 8 kawałki 4 sery (50 za pizze)
            // 85 

            var order = Substitute.For<IOrder>();
            var menu = Substitute.For<IMenu>();
            menu.PizzaPrice("Pepperoni").Returns(new Price(30));
            menu.PizzaPrice("Hawajska").Returns(new Price(40));
            menu.PizzaPrice("4 Sery").Returns(new Price(50));

            order.Positions.Returns(new[]{
                new OrderItem("Jan", 4, "Pepperoni"),
                new OrderItem("Mateusz", 4, "Hawajska"),
                new OrderItem("Marek", 8, "4 Sery"),
            });

            var calculator = new OrderCalculator(menu);
            var price = calculator.Calculate(order);
            price.Value.Should().Be(85);
        }
    }

    internal class OrderCalculator
    {
        private readonly IMenu menu;

        public OrderCalculator(IMenu menu)
        {
            this.menu = menu;
        }

        internal IPrice Calculate(IOrder order)
        {
            var total = order.Positions
                .Sum(x => x.Pieces * PriceForPiece(x.PizzaName).Value);

            return new Price(total);
        }

        private IPrice PriceForPiece(string pizzaName)
        {
            return new Price(menu.PizzaPrice(pizzaName).Value / 8.0);
        }
    }

    public class Price : IPrice
    {
        public Price(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }

    public interface IPrice
    {
        double Value { get; }
    }

    public interface IMenu
    {
        IPrice PizzaPrice(string pizzaName);
    }
}
