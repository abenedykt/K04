﻿using System;
using Pizza.Abstract;

namespace Pizza
{
    public class MyPizzaApp : IMyPizzaApp
    {
        private readonly IPizzaFactory _factory;
        private readonly IOrdersRepository _orders;
        private CommandExecutor<IMenu> _executor;

        public MyPizzaApp(IPizzaFactory factory, IOrdersRepository ordersRepository)
        {
            _factory = factory;
            _orders = ordersRepository;
            _executor = new CommandExecutor<IMenu>();
        }

        public IMenu GetMenu()
        {
            return _executor.Execute(new CommandGetMenu(_factory));
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
