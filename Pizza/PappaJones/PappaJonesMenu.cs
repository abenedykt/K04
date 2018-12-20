using PizzaAbstract;
using System;
using System.Collections.Generic;

namespace Pizza
{
    public class PappaJonesMenu : IMenu
    {
        public PappaJonesMenu()
        {
            items = new IMenuItem[]
            {
                new MenuItem()
                {
                    Name = "pepperoni",
                    Price = 30
                },
                new MenuItem()
                {
                    Name = "habanero",
                    Price = 20
                },
                new MenuItem()
                {
                    Name = "capricosa",
                    Price = 10
                }
            };
        }

        public IPrice PizzaPrice(string pizzaName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMenuItem> items { get; set; }
        public IMenuItem GetMenuItem()
        {
            throw new NotImplementedException();
        }
    }
}
