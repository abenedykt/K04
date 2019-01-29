using Pizza.Abstract;
using System;

namespace Pizza
{
    public class MyPizzaApp : IMyPizzaApp
    {
        private readonly IPizzaFactory _factory;
        private readonly IOrdersRepository _orders;

        public MyPizzaApp(IPizzaFactory factory, IOrdersRepository ordersRepository)
        {
            _factory = factory;
            _orders = ordersRepository;
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
            _orders.Find(order.Value).Add(new OrderItem("", pieces, menuItem.Name));
        }
        public void SendOrder(IClientOrder clientOrder)
        {
            var order = _orders.Find(clientOrder.Value);

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
