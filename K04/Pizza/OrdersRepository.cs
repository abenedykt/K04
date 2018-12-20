using Pizza.Abstract;
using System.Collections.Generic;

namespace Pizza
{
    public class OrdersRepository : IOrdersRepository
    {
        IDictionary<string, IOrder> _orders = new Dictionary<string, IOrder>();

        public void Add(string orderId, IOrder order)
        {
            _orders.Add(orderId, order);
        }

        public IOrder Find(string value)
        {
            return _orders[value];
        }

        public void Remove(string orderId)
        {
            _orders.Remove(orderId);
        }
    }
}
