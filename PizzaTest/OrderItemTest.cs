using FluentAssertions;
using System;
using Xunit;

namespace PizzaTest
{
    public class OrderItemTest
    {
        Action act2;
        public OrderItemTest()
        {
            act2 = () => new Pizza.OrderItem("who", -2, "which");
        }

        [Fact]
        public void Empty_order_is_not_valid()
        {
            act2.Should().Throw<ArgumentException>();
        }
    }
}
