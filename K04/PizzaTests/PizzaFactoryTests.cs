using FluentAssertions;
using Pizza.PappaJones;
using Xunit;

namespace Pizza
{
    public class PizzaFactoryTests
    {
        private PappaJonesPizzaFactory _factory;

        public PizzaFactoryTests()
        {
            _factory = new PappaJonesPizzaFactory();
        }

        [Fact]
        public void Menu_should_retrun_instance_of_menu()
        {
            _factory.Menu().Should().NotBeNull();
            _factory.Menu().Should().BeOfType<PappaJonesMenu>();
        }

        [Fact]
        public void OrderCalculator_should_return_instance_of_order_calculator()
        {
            _factory.OrderCalculator().Should().NotBeNull();
            _factory.OrderCalculator().Should().BeOfType<PappaJonesOrderCalculator>();
        }

    }
}
