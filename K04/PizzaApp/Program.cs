using Pizza;
using Pizza.Abstract;
using Pizza.PappaJones;
using System;
using System.Linq;

namespace PizzaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PappaJonesPizzaFactory();
            var app = new MyPizzaApp(factory);

            var menu = app.GetMenu();
            Show(menu);

            var order1 = app.StartOrder();
            app.AddToOrder(order1, menu.Positions.First(),2);
            app.AddToOrder(order1, menu.Positions.First(),2);
            app.AddToOrder(order1, menu.Positions.Last(),4);

            app.SendOrder(order1);

            var order2 = app.StartOrder();
            app.AddToOrder(order2, menu.Positions.First(), 8);
            app.AddToOrder(order2, menu.Positions.Last(), 8);

            app.SendOrder(order2);
        }

        private static void Show(IMenu menu)
        {
            foreach (var p in menu.Positions)
            {
                Console.WriteLine($"{p.Name} {p.Price.Value}");
            }
        }
    }
}
