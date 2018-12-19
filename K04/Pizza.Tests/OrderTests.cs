using FluentAssertions;
using Xunit;

namespace Pizza.Tests
{
    public class OrderTests
    {
        private Order order;

        public OrderTests()
        {
            order = new Order();
        }

        [Fact]
        public void IsValid_WhenOrderIsOneWholePizza_ReturnsTrue()
        {
            order.Add(new OrderItem("Arek", 8, "Pepperoni"));

            order.IsValid().Should().BeTrue();
        }

        [Fact]
        public void IsValid_WithEmptyOrder_ReturnsFalse()
        {
            order.IsValid().Should().BeFalse();
        }

        [Fact]
        public void IsValid_GivenOrderWith7Pieces_ReturnsFalse()
        {
            order.Add(new OrderItem("Arek", 7, "Pepperoni"));
            order.IsValid().Should().BeFalse();
        }

        [Fact]
        public void IsValid_GivenOrderWith2HalvesOfSamePizza_ReturnsTrue()
        {
            order.Add(new OrderItem("Arek", 4, "Pepperoni"));
            order.Add(new OrderItem("Marek", 4, "Pepperoni"));

            order.IsValid().Should().BeTrue();
        }

        [Fact]
        public void IsValid_GivenOrderWith2HalvesOfDifferentPizza_ReturnsFalse()
        {
            order.Add(new OrderItem("Arek", 6, "Pepperoni"));
            order.Add(new OrderItem("Marek", 2, "Hawai"));

            order.IsValid().Should().BeFalse();
        }
    }
}