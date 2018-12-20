using FluentAssertions;
using NSubstitute;
using Pizza.Abstract;
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

            var menu = Substitute.For<IMenu>();
            menu.PizzaPrice("Pepperoni").Returns(new Price(30));
            menu.PizzaPrice("Hawajska").Returns(new Price(40));
            menu.PizzaPrice("4 Sery").Returns(new Price(50));

            var order = Substitute.For<IOrder>();
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
}