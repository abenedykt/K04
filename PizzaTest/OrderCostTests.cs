using NSubstitute;
using Xunit;
using FluentAssertions;
using Pizza;
using PizzaAbstract;

namespace PizzaTest
{
    public class OrderCostTests
    {
        [Fact]
        public void Based_on_menu_and_order_final_price_should_be_calculated()
        {
            // Order, który ma dwie pizze
            // pizza 1 ma cene 30 (4piecs)
            // pizza 1 ma cene 40 (4piecs)
            // pizza 1 ma cene 50 (8piecs)
            // 85

            IOrder order = ExampleOrder();
            IMenu menu = ExampleMenu();

            var calculator = new OrderCalculator(menu);

            var price = calculator.Calculate(order);
            price.Should().BeEquivalentTo(new Price(85.0));
        }

        private static IMenu ExampleMenu()
        {
            var menu = Substitute.For<IMenu>();

            menu.PizzaPrice("Pepperoni").Returns(new Price(30));
            menu.PizzaPrice("Hawajska").Returns(new Price(40));
            menu.PizzaPrice("4 Sery").Returns(new Price(50));
            return menu;
        }

        private static IOrder ExampleOrder()
        {
            var order = Substitute.For<IOrder>();

            order.Positions.Returns(new[] {
                new OrderItem("one",4,"Pepperoni"),
                new OrderItem("two",4,"Hawajska"),
                new OrderItem("thr",8,"4 Sery"),
            });
            return order;
        }
    }

    public class OrderCalculator : IOrderCalculator
    {
        private readonly IMenu menu;
        public OrderCalculator(IMenu menu)
        {
            this.menu = menu;
        }

        internal IPrice Calculate(IOrder order)
        {
            double sum = 0.0;

            foreach (var item in order.Positions)
            {
                sum += item.Pieces * PriceForPiece(item.PizzaName).Value;
            }

            return new Price(sum);
        }

        private IPrice PriceForPiece(string pizzaName)
        {
            return new Price(menu.PizzaPrice(pizzaName).Value / 8);
        }
    }



    public class Price : IPrice
    {
        public double Value { get; }
        public Price(double value)
        {
            Value = value;
        }
    }
}
