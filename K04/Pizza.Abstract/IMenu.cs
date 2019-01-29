using System.Collections.Generic;

namespace Pizza.Abstract
{
    public interface IMenu
    {
        IEnumerable<IMenuItem> Positions { get; }

        IPrice PizzaPrice(string pizzaName);
    }
}