using System;

namespace Pizza
{
    public class OrderItem : IOrderItem
    {
        public string Name { get; }
        public int Pieces { get; }
        public string PizzaName { get; }

        public OrderItem(string name, int pieces, string pizzaName)
        {
            if (pieces <= 0) throw new ArgumentException(nameof(pieces));
            Name = name;
            Pieces = pieces;
            PizzaName = pizzaName;
        }
    }
}