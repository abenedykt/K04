using System.Collections;
using System.Collections.Generic;

namespace PizzaAbstract
{

    public interface IMenu
    {
        IPrice PizzaPrice(string pizzaName);
        IEnumerable<IMenuItem> items { get; set; }
        IMenuItem GetMenuItem();
    }
}
