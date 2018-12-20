using PizzaAbstract;

namespace Pizza
{
    public class PappaJonesPizzaFactory : IPizzaFactory
    {
        public IMenu Menu()
        {
            return new PappaJonesMenu();
        }

        public IOrderCalculator OrderCalculator()
        {
            return new PappaJonesOrderCalculator(new PappaJonesMenu());
        }
    }
}
