using NSubstitute;
using Pizza;
using Pizza.Abstract;
using Pizza.PappaJones;
using System.Linq;
using Xunit;

namespace PizzaApp.Tests
{
    public class Class1
    {
        [Fact]
        public void IntegrationTest()
        {
            var factory = Substitute.For<IPizzaFactory>();
            var fakeSender = Substitute.For<IOrderSender>();
            factory.Menu().Returns(new PappaJonesMenu());
            factory.OrderCalculator().Returns(new PappaJonesOrderCalculator(new PappaJonesMenu()));
            factory.Sender().Returns(fakeSender);


            var orderRepository = new OrdersRepository();
            var app = new MyPizzaApp(factory, orderRepository);

            var menu = app.GetMenu();

            var order1 = app.StartOrder();
            app.AddToOrder(order1, menu.Positions.First(), 2);
            app.AddToOrder(order1, menu.Positions.First(), 2);
            app.AddToOrder(order1, menu.Positions.Last(), 4);

            app.SendOrder(order1);

            var order2 = app.StartOrder();
            app.AddToOrder(order2, menu.Positions.First(), 8);
            app.AddToOrder(order2, menu.Positions.Last(), 8);

            app.SendOrder(order2);
            
            fakeSender.Received(2).Send(Arg.Any<IOrder>());
        }
    }
}
