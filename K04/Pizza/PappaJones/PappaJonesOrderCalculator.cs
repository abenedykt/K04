using Pizza.Abstract;
using System.Linq;

namespace Pizza.PappaJones
{
    public class PappaJonesOrderCalculator : IOrderCalculator
    {
        private readonly IMenu menu;

        public PappaJonesOrderCalculator(IMenu menu)
        {
            this.menu = menu;
        }

        public IPrice Calculate(IOrder order)
        {
            var total = order.Positions
                .Sum(x => x.Pieces * PriceForPiece(x.PizzaName).Value);

            return new Price(total);
        }

        private IPrice PriceForPiece(string pizzaName)
        {
            return new Price(menu.PizzaPrice(pizzaName).Value / 8.0);
        }
    }
}
