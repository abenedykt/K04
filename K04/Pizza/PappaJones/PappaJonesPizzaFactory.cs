using Pizza.Abstract;
using System.Net.Http;

namespace Pizza.PappaJones
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

        public IOrderSender Sender()
        {
            return new PappaJonesRestApiClient(new HttpClient());
        }
    }
}
