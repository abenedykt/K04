using FluentAssertions;
using NSubstitute;
using Pizza.Abstract;
using Pizza.PappaJones;
using Xunit;

namespace Pizza
{
    public class OrderPriceTests
    {
        [Fact]
        public void Based_on_menu_and_order_final_price_should_be_calculated()
        {
            IMenu menu = PrepareTestMenu();
            IOrder order = PrepareTestOrder();

            var calculator = new PappaJonesOrderCalculator(menu);
            var price = calculator.Calculate(order);
            price.Value.Should().Be(85);
        }

        private IOrder PrepareTestOrder()
        {
            IOrder order = Substitute.For<IOrder>();
            order.Positions.Returns(new[]{
                new OrderItem("Jan", 4, "Pepperoni"),
                new OrderItem("Mateusz", 4, "Hawajska"),
                new OrderItem("Marek", 8, "4 Sery"),
            });
            return order;
        }

        private IMenu PrepareTestMenu()
        {
            var menu = Substitute.For<IMenu>();
            menu.PizzaPrice("Pepperoni").Returns(new Price(30));
            menu.PizzaPrice("Hawajska").Returns(new Price(40));
            menu.PizzaPrice("4 Sery").Returns(new Price(50));
            return menu;
        }
    }
}