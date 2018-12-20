using Pizza.Abstract;

namespace Pizza.PappaJones
{
    public class PappaJonesPizzaFactory
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
