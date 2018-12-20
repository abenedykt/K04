using System;
using PizzaAbstract;

namespace Pizza
{
    public class OrderItem : IOrderItem
    {
        private string who;

        public int Pieces { get; }
        public string PizzaName { get; }

        public OrderItem(string who, int howMany, string which)
        {
            if (howMany <= 0) throw new ArgumentException();

            this.who = who;
            Pieces = howMany;
            PizzaName = which;
        }
    }
}