using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    internal class Order
    {
        private readonly List<OrderItem> _items;

        public Order()
        {
            _items = new List<OrderItem>();

        }

        internal void Add(OrderItem orderItem)
        {
            _items.Add(orderItem);
        }

        internal bool IsValid()
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
