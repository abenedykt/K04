using System.Collections.Generic;
using System.Linq;
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

    public class OrderItem
    {
        public string Name { get; }
        public int Pieces { get; }
        public string PizzaName { get; }

        public OrderItem(string name, int pieces, string pizzaName)
        {
            Name = name;
            Pieces = pieces;
            PizzaName = pizzaName;
        }
    }

    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        private List<OrderItem> OrderItems { get; }

        public void Add(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public bool IsValid()
        {
            if (OrderItems.GroupBy(x => x.PizzaName).Any(pizza => pizza.Select(x => x.Pieces).Sum() % 4 != 0))
            {
                return false;
            }

            var piecesNumber = OrderItems.Select(x => x.Pieces).Sum();
            return piecesNumber > 0 && piecesNumber % 8 == 0;
        }
    }
}