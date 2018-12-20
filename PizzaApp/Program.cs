using System;
using System.Linq;
using Pizza;
using PizzaAbstract;

namespace PizzaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // wyswietlic menu
            // wybrac elementy do zamowienia
            // wyslac (?) zamowienie

            var app = new MyPizzaApp();
            var order = app.StartOrder();

            var menu = app.GetMenu();

            var list = menu.items.ToList();

            Show(menu);

            int choice = 0;
            int pieces = 0;
            do
            {
                Console.Write("Your option: ");

                choice = int.Parse(Console.ReadLine());
                if (choice != 0)
                {
                    Console.Write("How many pieces?: ");
                    pieces = int.Parse(Console.ReadLine());
                    
                    app.AddToOrder(order, list[choice-1], pieces);
                }

            } while (choice != 0);

            bool success = true;
            try
            {
                app.SendOrder(order);
            }
            catch (ArgumentException ex)
            {
                success = false;
                Console.WriteLine("Could not parse order.");
            }

            if (success)
            {
                Console.WriteLine("Order valid and taken.");
            }


            Console.WriteLine("The End! Press any key to continue.");
            Console.ReadKey();
        }

        private static void Show(IMenu menu)
        {
            int i = 1;
            foreach (var menuItem in menu.items)
            {
                Console.WriteLine($"{i++} Pizza: {menuItem.Name}, {menuItem.Price}");
            }

            Console.WriteLine($"\n0 Exit.");
        }

        //private static int Choice()
        //{
        //Console.Write("Your option: ");
        //string temp = Console.ReadLine();
        //if (temp != "0")
        //{
        //    Console.Write("How many pieces?: ");
        //    string temp = Console.ReadLine();
        //}

        //return int.Parse(temp);
        //}

        //AddToOrder()
    }
}
