using Pizza.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Pizza.PappaJones
{
    public class PappaJonesMenu : IMenu
    {
        public IEnumerable<IMenuItem> Positions { get; } = new[]
        {
            new MenuItem("Pepperoni", 30),
            new MenuItem("5 Serów", 50),
            new MenuItem("Kebabowa", 40),
            new MenuItem("Hawajska", 80)
        };

        public IPrice PizzaPrice(string pizzaName)
        {
            return Positions.FirstOrDefault(p => p.Name == pizzaName).Price;
        }
    }
}
