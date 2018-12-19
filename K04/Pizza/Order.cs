using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    public class Order : IOrder
    {
        public List<OrderItem> Positions { get; }
        public Order()
        {
            Positions = new List<OrderItem>();
        }


        public void Add(OrderItem orderItem)
        {
            Positions.Add(orderItem);
        }

        public bool IsValid()
        {
            if (Positions.GroupBy(x => x.PizzaName).Any(pizza => pizza.Select(x => x.Pieces).Sum() % 4 != 0))
            {
                return false;
            }

            var piecesNumber = Positions.Select(x => x.Pieces).Sum();
            return piecesNumber > 0 && piecesNumber % 8 == 0;
        }
    }
}