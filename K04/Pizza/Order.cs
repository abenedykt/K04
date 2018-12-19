using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    public class Order : IOrder
    {
        private readonly List<OrderItem> _items;

        public Order()
        {
            _items = new List<OrderItem>();

        }

        public IEnumerable<IOrderItem> Positions => _items;

        public void Add(OrderItem orderItem)
        {
            _items.Add(orderItem);
        }

        public bool IsValid()
        {
            return _items.Any() && 
                    _items.GroupBy(p => p.PizzaName)
                            .Select(g => new
                            {
                                Kind = g.Key,
                                Pieces = g.Sum(x => x.Pieces)
                            })
                            .All(x => x.Pieces % 4 == 0);
        }
    }
}
