using FluentAssertions;
using Xunit;
using Pizza;

namespace PizzaTest
{
    public class OrderTest
    {
        private Order order;
        public OrderTest()
        {
            order = new Order();
        }

        [Fact]
        public void Empty_order_is_not_valid()
        {
            order.isValid().Should().BeFalse();
        }

        [Fact]
        public void Order_With_One_whole_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 8, "pepperoni"));

            order.isValid().Should().BeTrue();
        }

        [Fact]
        public void Order_With_seven_pieces_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 7, "pepperoni"));

            order.isValid().Should().BeFalse();
        }

        [Fact]
        public void Order_with_Two_Halves_of_same_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 4, "pepperoni"));
            order.Add(new OrderItem("Arek", 4, "pepperoni"));

            order.isValid().Should().BeTrue();
        }

        [Fact]
        public void Order_with_Uneven_Halves_of_same_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 4, "pepperoni"));
            order.Add(new OrderItem("Arek2", 4, "pepperoni"));
            order.Add(new OrderItem("Arek3", 4, "pepperoni"));

            order.isValid().Should().BeFalse();
        }

        [Fact]
        public void Order_with_Two_Halves_of_different_pizza_is_valid()
        {
            order.Add(new OrderItem("Arek", 4, "pepperoni"));
            order.Add(new OrderItem("Mirek", 4, "havai"));

            order.isValid().Should().BeTrue();
        }

        [Fact]
        public void Order_with_Two_Not_Equal_Not_whole_pizzas_is_not_valid()
        {
            order.Add(new OrderItem("Arek", 6, "pepperoni"));
            order.Add(new OrderItem("Mirek", 2, "havai"));

            order.isValid().Should().BeFalse();
        }
    }
}
