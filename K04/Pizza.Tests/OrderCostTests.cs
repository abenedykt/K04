using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Pizza.Tests
{
    public class OrderCostTests
    {
        [Fact]
        public void NewTest()
        {
            //4 kawalki pepperoni 30pln/pizza
            //4 kawalki hawajskiej 40pln/pizza
            //8 kawalki 4sery 50pln/pizza

            var menu = Substitute.For<IMenu>();
            menu["4sery"].Returns(new Price(50));
            menu["Hawajska"].Returns(new Price(40));
            menu["Pepperoni"].Returns(new Price(30));
            var sut = new OrderCalculator(menu);

            var order = Substitute.For<IOrder>();
            order.Positions.Returns(new List<OrderItem>
            {
                new OrderItem("Adam", 4, "Pepperoni"),
                new OrderItem("Seba", 4, "Hawajska"),
                new OrderItem("Udon", 8, "4sery")
            });

            var price = sut.Calculate(order);
            price.Should().Be(new Price(85));
        }
    }

    internal class OrderCalculator
    {
        private IMenu Menu { get; }

        public OrderCalculator(IMenu menu)
        {
            Menu = menu;
        }

        public IPrice Calculate(IOrder order)
        {
            var total = order.Positions.Sum(x => x.Pieces * PriceForPiece(x.PizzaName).Value);
            return new Price(total);
        }

        private IPrice PriceForPiece(string pizzaName)
        {
            return new Price(Menu[pizzaName].Value / 8);
        }
    }

    internal interface IMenu
    {
        IPrice this[string pizzaName] { get; }
    }
}

public interface IPrice
{
    decimal Value { get; }
}

internal class Price : IPrice
{
    public Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }
}

