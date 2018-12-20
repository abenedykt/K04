using FluentAssertions;
using Pizza;
using Xunit;

namespace PizzaTest
{
    public class PappaJonesPizzaFactoryTest
    {
        private PappaJonesPizzaFactory factory;

        public PappaJonesPizzaFactoryTest()
        {
            factory = new PappaJonesPizzaFactory();
        }

        [Fact]
        public void Menu_should_return_instance_of_menu()
        {
            factory.Menu().Should().NotBeNull();
            factory.Menu().Should().BeOfType<PappaJonesMenu>();
        }

        [Fact]
        public void OrderCalculator_should_return_instance_of_OrderCalculator()
        {
            factory.OrderCalculator().Should().NotBeNull();
            factory.OrderCalculator().Should().BeOfType<PappaJonesOrderCalculator>();
        }
    }
}
