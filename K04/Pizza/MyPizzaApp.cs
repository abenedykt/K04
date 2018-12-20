using Pizza.Abstract;
using System;
using System.Collections.Generic;

namespace Pizza
{
    public class MyPizzaApp
    {
        private readonly IPizzaFactory _factory;
        private readonly IDictionary<string, IOrder> _orders = new Dictionary<string, IOrder>();

        public MyPizzaApp(IPizzaFactory factory)
        {
            _factory = factory;
        }

        public IMenu GetMenu()
        {
            return _factory.Menu();
        }

        public IClientOrder StartOrder()
        {
            var clientOrder = new ClientOrder(Guid.NewGuid().ToString()); ;
            _orders.Add(clientOrder.Value, new Order());

            return clientOrder;
        }

        public void AddToOrder(IClientOrder order, IMenuItem menuItem, int pieces)
        {
            _orders[order.Value].Add(new OrderItem("", pieces, menuItem.Name));
        }
        public void SendOrder(IClientOrder clientOrder)
        {
            var order = _orders[clientOrder.Value];

            if (order.IsValid())
            {
                _factory.Sender().Send(order);
                _orders.Remove(clientOrder.Value);
            } else
            {
                throw new OrderIsNotValidException();
            }

        }

        internal class OrderIsNotValidException : Exception
        {

        }

        internal class ClientOrder : IClientOrder
        {
            public string Value { get; }

            public ClientOrder(string guid)
            {
                Value = guid;
            }
        }
    }
}
