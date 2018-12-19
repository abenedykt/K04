using FluentAssertions;
using Xunit;

namespace Pizza
{
    public class PizzaTests
    {
        private Order order;

        public PizzaTests()
        {
            order = new Order();
        }

        [Fact]
        public void Empty_order_should_be_invalid()
        {
            order.IsValid()
                .Should().BeFalse();
        }
      
        [Fact]
        public void Order_with_one_whole_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 8, "Pepperoni"));

            order.IsValid()
                .Should().BeTrue();
        }

        [Fact]
        public void Order_with_7_pieces_is_not_valid()
        {
            order.Add(new OrderItem("Arek", 7, "Pepperoni"));

            order.IsValid().Should().BeFalse();
        }

        [Fact]
        public void Order_with_two_halves_of_same_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 4, "Pepperoni"));
            order.Add(new OrderItem("Mrek", 4, "Pepperoni"));

            order.IsValid().Should().BeTrue();
        }

        [Fact]
        public void Order_with_two_uneven_halves_of_different_pizza_is_not_valid()
        {
            order.Add(new OrderItem("Arek", 6, "Pepperoni"));
            order.Add(new OrderItem("Mrek", 2, "Hawajska"));

            order.IsValid().Should().BeFalse();
        }
    }
}
