using System;
using PizzaAbstract;

namespace Pizza
{
    public class OrderItem : IOrderItem
    {
        private string who;
        public int howMany;
        public string which;

        public int Pieces => howMany;
        public string PizzaName => which;

        public OrderItem(string who, int howMany, string which)
        {
            if (howMany <= 0) throw new ArgumentException();

            this.who = who;
            this.howMany = howMany;
            this.which = which;
        }
    }
}