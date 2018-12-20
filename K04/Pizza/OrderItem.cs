using Pizza.Abstract;
using System;

namespace Pizza
{
    public class OrderItem : IOrderItem
    {
        public OrderItem(string name, int pieces, string pizzaName)
        {
            if (pieces <= 0) throw new PiecesMustBeGreatherThanZeroException();
            Pieces = pieces;
            PizzaName = pizzaName;
        }

        public int Pieces { get; }
        public string PizzaName { get; }
    }

    internal class PiecesMustBeGreatherThanZeroException : Exception
    {
    }
}
